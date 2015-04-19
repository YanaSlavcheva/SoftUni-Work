namespace BugTracker.RestServices.DataModels
{
    using System;

    using System.Linq.Expressions;

    using BugTracker.Data.Models;

    public class BugsDataModel
    {
        // Id, Title, Status, Author and DateCreated
        public static Expression<Func<Bug, BugsDataModel>> DataModel
        {
            get
            {
                return x => new BugsDataModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Status = x.Status,
                    Author = x.Author.UserName,
                    DateCreated = x.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public BugStatus Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}