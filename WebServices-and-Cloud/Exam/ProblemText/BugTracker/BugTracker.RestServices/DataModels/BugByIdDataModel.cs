namespace BugTracker.RestServices.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq.Expressions;

    using BugTracker.Data.Models;

    public class BugByIdDataModel
    {
        // Id, Title, Description, Status, Author, DateCreated and Comments
        //public static Expression<Func<Bug, BugByIdDataModel>> DataModel
        //{
        //    get
        //    {
        //        return x => new BugByIdDataModel
        //        {
        //            Id = x.Id,
        //            Title = x.Title,
        //            Description = x.Description,
        //            Status = x.Status,
        //            Author = x.Author.UserName,
        //            DateCreated = x.DateCreated
        //        };
        //    }
        //}

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BugStatus Status { get; set; }

        public virtual string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public List<Comment> Comments { get; set; }
    }
}