namespace BugTracker.RestServices.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using BugTracker.Data.Models;

    public class BugByIdDataModel
    {
        private ICollection<Comment> comments;

        public BugByIdDataModel()
        {
            this.Comments = new HashSet<Comment>();
        }
        // Id, Title, Description, Status, Author, DateCreated and Comments
        public static Expression<Func<Bug, BugByIdDataModel>> DataModel
        {
            get
            {
                return x => new BugByIdDataModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Status = x.Status,
                    Author = x.Author.UserName,
                    DateCreated = x.DateCreated,
                    // Comments = x.Comments
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BugStatus Status { get; set; }

        public virtual string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}