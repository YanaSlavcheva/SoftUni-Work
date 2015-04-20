namespace BugTracker.Data
{
    using BugTracker.Data.Models;
    using BugTracker.Data.Repositories;


    public interface IMessagesData
    {
        IRepository<Bug> Bugs { get; }

        IRepository<Comment> Comments { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}

