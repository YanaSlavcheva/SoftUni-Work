namespace MoviesGallery.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using MoviesGallery.Data.Migrations;
    using MoviesGallery.Models;

    public class MoviesGalleryDbContext : IdentityDbContext<User>
    {
        public MoviesGalleryDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesGalleryDbContext, Configuration>());
            }

        public IDbSet<Actor> Actors { get; set; }

        public IDbSet<Genre> Genres { get; set; }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public static MoviesGalleryDbContext Create()
        {
            return new MoviesGalleryDbContext();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }

            catch (DbEntityValidationException ex)
            {
                foreach (var e in ex.EntityValidationErrors)
                {
                    foreach (var messages in e.ValidationErrors)
                    {
                        var temp = messages.ErrorMessage;
                        Console.WriteLine(messages.ErrorMessage);
                    }
                }

                throw;
            }
        }
    }
}
