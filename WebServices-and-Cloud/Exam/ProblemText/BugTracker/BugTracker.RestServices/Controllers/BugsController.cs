namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Web.Http;
    using System.Linq;

    using BugTracker.Data.Models;
    using BugTracker.RestServices.BindingModels;
    using BugTracker.RestServices.DataModels;

    using Microsoft.AspNet.Identity;

    [RoutePrefix("api/bugs")]
    public class BugsController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetAllBugs()
        {
            var bugs = this.Data.Bugs
                .OrderByDescending(x => x.DateCreated)
                .Select(BugsDataModel.DataModel);

            return this.Ok(bugs);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBugById(int id)
        {
            // Id, Title, Description, Status, Author, DateCreated and Comments
            var comments =
                this.Data.Comments.Where(x => x.BugId == id)
                    .Select(
                        x => new CommentsDM { Id = x.Id, Text = x.Text, Author = x.Author.UserName, DateCreated = x.PublishDate }).ToList();

            var bug = this.Data.Bugs
                .Where(x => x.Id == id)
                .Select(x => new BugByIdDataModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Status = x.Status,
                    Author = x.Author.UserName,
                    DateCreated = x.DateCreated,
                    // Comments = comments
                })
                .FirstOrDefault();
            if (bug == null)
            {
                return this.NotFound();
            }

            return this.Ok(bug);
        }

        [HttpPost]
        public IHttpActionResult SubmitNewBug(BugBindingModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var bug = new Bug
            {
                Title = model.Title,
                Description = model.Description
            };

            if (this.User.Identity.IsAuthenticated)
            {
                var authorId = this.User.Identity.GetUserId();
                bug.Author = this.Data.Users.FirstOrDefault(x => x.Id == authorId);
            }

            this.Data.Bugs.Add(bug);
            this.Data.SaveChanges();

            if (this.User.Identity.IsAuthenticated)
            {
                return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "bugs", id = bug.Id },
                new { bug.Id, Author = bug.Author.UserName, Message = "User bug submitted." });
            }

            return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "bugs", id = bug.Id },
                new { bug.Id, Message = "Anonymous bug submitted." });
        }

        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult EditBug(int id, BugsPatchBindingModel bugData)
        {
            if (bugData == null || bugData.Title == string.Empty)
            {
                return this.BadRequest();
            }

            var bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (bugData.Status != null)
            {
                bug.Status = bugData.Status;
            }

            if (bugData.Title != null)
            {
                bug.Title = bugData.Title;
            }

            if (bugData.Description != null)
            {
                bug.Description = bugData.Description;
            }

            this.Data.SaveChanges();

            return this.Ok(
                new
                {
                    Message = string.Format("Bug #{0} patched.", bug.Id)
                });
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteBug(int id)
        {
            Bug bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            this.Data.Bugs.Remove(bug);
            this.Data.SaveChanges();

            return this.Ok(new
            {
                Message = "Bug #" + id + " deleted."
            });
        }

        [HttpGet]
        [Route("filter")]
        public IHttpActionResult GetBugsByFilter(string keyword = null, string statuses = null, string author = null)
        {
            // filter?keyword=link&statuses=Open|Closed&author=nakov
            // Check Keyword
            var bugs = this.Data.Bugs
                .Where(x => x.Title.Contains(keyword))
                .OrderByDescending(x => x.DateCreated)
                .Select(BugsDataModel.DataModel).ToList();
            if (keyword == null)
            {
                bugs = this.Data.Bugs
                .OrderByDescending(x => x.DateCreated)
                .Select(BugsDataModel.DataModel).ToList();
            }

            if (bugs.Count == 0)
            {
                return this.BadRequest();
            }

            // check statuses
            
            var bugsKeywordStatuses = new List<BugsDataModel>();
            if (statuses == null)
            {
                bugsKeywordStatuses = bugs;
            }
            else
            {
                string[] statuStrings = statuses.Split('|');
                foreach (var statuString in statuStrings)
                {
                    var statusAsEnum = (BugStatus)Enum.Parse(typeof(BugStatus), statuString, true);
                    foreach (var bug in bugs)
                    {
                        if (bug.Status == statusAsEnum)
                        {
                            bugsKeywordStatuses.Add(bug);
                        }
                    }
                }
            }

            if (bugsKeywordStatuses.Count == 0)
            {
                return this.BadRequest(); 
            }
            
            // check author
            var bugsWithAuthor = new List<BugsDataModel>();
            if (author == null)
            {
                bugsWithAuthor = bugsKeywordStatuses;
            }
            else
            {
                foreach (var bugKeywordStatuses in bugsKeywordStatuses)
                {
                    if (bugKeywordStatuses.Author == author)
                    {
                        bugsWithAuthor.Add(bugKeywordStatuses);
                    }
                }
            }
              
            if (bugsWithAuthor.Count == 0)
            {
                return this.BadRequest();
            }

            // final
            return this.Ok(bugsWithAuthor);
        }
    }
}
