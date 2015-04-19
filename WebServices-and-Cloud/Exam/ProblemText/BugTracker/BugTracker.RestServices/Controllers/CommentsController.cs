namespace BugTracker.RestServices.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;

    using BugTracker.Data.Models;
    using BugTracker.RestServices.DataModels;

    using Microsoft.AspNet.Identity;

    public class CommentsController : BaseApiController
    {
        [Route("api/comments")]
        [HttpGet]
        public IHttpActionResult GetAllComments()
        {
            var comments = this.Data.Comments
                .OrderByDescending(x => x.PublishDate)
                .Select(CommentsDataModel.DataModel);

            return this.Ok(comments);
        }

        [HttpGet]
        [Route("api/bugs/{id}/comments")]
        public IHttpActionResult GetCommentByBug(int id)
        {
            var comments = this.Data.Comments
                .OrderByDescending(x => x.PublishDate)
                .Where(x => x.BugId == id)
                .Select(CommentsByBugDataModel.DataModel);

            if (!this.Data.Comments.Any(x => x.BugId == id))
            {
                return this.NotFound();
            }

            return this.Ok(comments);
        }

        [HttpPost]
        [Route("api/bugs/{id}/comments")]
        public IHttpActionResult CreateCommentByBug(int id, CommentSimpleDataModel commentData)
        {
            if (commentData == null)
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var bug = this.Data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var comment = new Comment
            {
                Text = commentData.Text,
                BugId = id
            };

            if (this.User.Identity.IsAuthenticated)
            {
                var authorId = this.User.Identity.GetUserId();
                comment.Author = this.Data.Users.FirstOrDefault(x => x.Id == authorId);
            }

            this.Data.Comments.Add(comment);
            this.Data.SaveChanges();

            if (this.User.Identity.IsAuthenticated)
            {
                return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "comments", id = comment.Id },
                new { comment.Id, Author = comment.Author.UserName, Message = "User comment added for bug #{0}", comment.BugId });
            }

            return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "bugs", id = bug.Id },
                new { bug.Id, Message = "Added anonymous comment for bug #{0}", comment.BugId });
        }
    }
}
