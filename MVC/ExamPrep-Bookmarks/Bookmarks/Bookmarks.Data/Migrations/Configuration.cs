namespace Bookmarks.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BookmarksDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "Bookmarks.Data.BookmarksDbContext";
            this.AutomaticMigrationDataLossAllowed = false;
        }
    }
}
