namespace Bookmarks.Data
{
    using System.Data.Entity;

    using Bookmarks.Data.Migrations;
    using Bookmarks.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BookmarksDbContext : IdentityDbContext<User>, IBookmarksDbContext
        {
            public BookmarksDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookmarksDbContext, Configuration>());
            }

            public IDbSet<Bookmark> Bookmarks { get; set; }

            public IDbSet<Category> Categories { get; set; }

            public IDbSet<Comment> Comments { get; set; }

            public IDbSet<Vote> Votes { get; set; }

            public static BookmarksDbContext Create()
            {
                return new BookmarksDbContext();
            }
        }
}
