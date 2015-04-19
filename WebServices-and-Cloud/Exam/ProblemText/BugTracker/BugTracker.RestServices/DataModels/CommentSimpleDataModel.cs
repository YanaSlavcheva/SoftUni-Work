namespace BugTracker.RestServices.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using BugTracker.Data.Models;

    public class CommentSimpleDataModel
    {
        public static Expression<Func<Comment, CommentSimpleDataModel>> DataModel
        {
            get
            {
                return x => new CommentSimpleDataModel
                {
                    Text = x.Text
                };
            }
        }

        [Required(ErrorMessage = "The text is required.")]
        public string Text { get; set; }
    }
}