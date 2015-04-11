namespace MoviesGallery.Data.Repositories
{
    using System.Data.Entity;
    using System.Dynamic;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext context;

        private IDbSet<T> set;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public void Add(T entity)
        {
            this.AttachEntityAndChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.AttachEntityAndChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.AttachEntityAndChangeState(entity, EntityState.Deleted);
        }

        public void Delete(object id)
        {
            var entity = this.Find(id);
            this.AttachEntityAndChangeState(entity, EntityState.Deleted);
        }

        public void Detach(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void AttachEntityAndChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State.ToString() == "Detached")
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
