using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.RestServices.DataModels
{
    using System.Linq.Expressions;

    using BugTracker.Data.Models;

    public class CommentsDataModel
    {
        // Id, Text and Author and DateCreated
        public static Expression<Func<Comment, CommentsDataModel>> DataModel
        {
            get
            {
                return x => new CommentsDataModel
                {
                    Id = x.Id,
                    Text = x.Text,
                    Author = x.Author.UserName,
                    DateCreated = x.PublishDate
                };
            }
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string AuthorId { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}