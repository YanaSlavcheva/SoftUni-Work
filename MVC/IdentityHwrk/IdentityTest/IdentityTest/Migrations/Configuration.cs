namespace IdentityTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using IdentityTest.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "IdentityTest.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //•	In the Seed() method in your DB migration class add some code to create "Administrator" role and user admin@admin.com in this role.

            //var adminRole = new IdentityRole { Name = "Administrator" };
            //context.Roles.AddOrUpdate(adminRole);

            //var userStore = new UserStore<ApplicationUser>(context);
            //var userManager = new UserManager<ApplicationUser>(userStore);

            //var adminUser = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };
            //var userCreateResult = userManager.Create(adminUser, "Az-123456");
            //adminUser.AddToRole(user.Id, "AppAdmin");

            //if (userCreateResult.Succeeded)
            //{
            //    context.Users.AddOrUpdate(adminUser);
            //}
            //else
            //{
            //    throw new Exception(string.Join("; ", userCreateResult.Errors));
            //}

            if (!context.Roles.Any(r => r.Name == "Administrator"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrator" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@admin.com" };

                manager.Create(user, "Az-123456");
                manager.AddToRole(user.Id, "Administrator");
            }
        }
    }
}
