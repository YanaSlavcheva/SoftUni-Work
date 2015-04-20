namespace BugTracker.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using BugTracker.Data.Models;
    using BugTracker.Data.Repositories;

    // visual studio got lost and didn't recognise the interface :)
    // public class BugTrackerData : IBugTrackerData
        public class BugTrackerData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public BugTrackerData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }


        public IRepository<Bug> Bugs
        {
            get { return this.GetRepository<Bug>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }


        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericReposory<T>);

                var repository = Activator.CreateInstance(typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
