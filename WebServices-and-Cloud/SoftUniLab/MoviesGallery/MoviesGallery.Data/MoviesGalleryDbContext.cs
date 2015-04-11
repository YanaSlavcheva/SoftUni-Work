namespace MoviesGallery.Data
{
    using System.Data.Entity;

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
    }
}
