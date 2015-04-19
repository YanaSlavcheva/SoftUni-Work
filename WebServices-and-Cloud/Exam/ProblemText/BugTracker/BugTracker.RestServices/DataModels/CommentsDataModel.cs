namespace BugTracker.RestServices.DataModels
{
    using System;
    using System.Linq.Expressions;

    using BugTracker.Data.Models;

    public class CommentsDataModel
    {
        // Id, Text, Author, DateCreated, BugId and BugTitle
        public static Expression<Func<Comment, CommentsDataModel>> DataModel
        {
            get
            {
                return x => new CommentsDataModel
                {
                    Id = x.Id,
                    Text = x.Text,
                    Author = x.Author.UserName,
                    DateCreated = x.PublishDate,
                    BugId = x.BugId,
                    BugTitle = x.Bug.Title
                };
            }
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public int BugId { get; set; }

        public string BugTitle { get; set; }
    }
}