namespace MoviesGallery.Data.Repositories
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        // CRUD
        // R
        IQueryable<T> All();

        // C
        void Add(T entity);

        // U
        void Update(T entity);

        // D
        void Delete(T entity);

        // D
        void Delete(object id);

        void Detach(T entity);

        T Find(object id);

        int SaveChanges();
    }
}
