using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.RestServices.DataModels
{
    public class CommentsDM
    {
        // Id = x.Id, Text = x.Text, Author = x.Author.UserName, DateCreated = x.PublishDate

        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}