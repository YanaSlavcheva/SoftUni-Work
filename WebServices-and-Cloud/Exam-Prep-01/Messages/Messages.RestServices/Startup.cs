using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MessagesRestService.Startup))]

namespace MessagesRestService
{
    using System.Data.Entity;

    using Messages.Data;
    using Messages.Data.Migrations;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MessagesDbContext, MessagesDbMigrationConfiguration>());
            ConfigureAuth(app);
        }
    }
}
