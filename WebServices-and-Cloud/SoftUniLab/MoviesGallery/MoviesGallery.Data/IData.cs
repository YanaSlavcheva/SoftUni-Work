namespace MoviesGallery.Data
{
    using MoviesGallery.Data.Repositories;
    using MoviesGallery.Models;

    public interface IData
    {
        IRepository<Actor> Actors { get; }

        IRepository<Genre> Genres { get; }

        IRepository<Movie> Movies { get; }

        IRepository<Review> Reviews { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
