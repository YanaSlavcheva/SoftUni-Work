namespace TicTacToe.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using TicTacToe.Data.Migrations;
    using TicTacToe.Web.Models;

    public class TicTacToeDbContext : IdentityDbContext<TicTacToeUser>
    {
        public TicTacToeDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TicTacToeDbContext, Configuration>());
        }

        public static TicTacToeDbContext Create()
        {
            return new TicTacToeDbContext();
        }
    }
}
