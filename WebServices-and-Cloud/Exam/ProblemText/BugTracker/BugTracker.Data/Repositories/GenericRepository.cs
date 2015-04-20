namespace BugTracker.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity;

    public class GenericReposory<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private IDbSet<T> set;

        public GenericReposory(DbContext context)
        {
            if (context != null)
            {
                this.Context = context;
                this.Set = context.Set<T>();
            }
        }

        protected DbContext Context { get; private set; }

        protected IDbSet<T> Set { get; private set; }

        public IQueryable<T> All()
        {
            return this.Set;
        }

        public T Find(object id)
        {
            return this.Set.Find(id);
        }

        public T Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
            return entity;
        }

        public T Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            return entity;
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.Set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
