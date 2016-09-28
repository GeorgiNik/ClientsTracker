namespace ClientsTracker.Data.Common
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using ClientsTracker.Data;

    /// <summary>
    /// Generic repository where the delete method removes selected entity from the database.
    /// GetAll method returns all entities, even the ones with the flag IsDeleted set to true.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(ApplicationDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected ApplicationDbContext Context { get; set; }

        protected IDbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> set = this.DbSet.AsQueryable<T>();

            foreach (var includeExpression in includeExpressions)
            {
                set = set.Include(includeExpression);
            }

            return set;
        }

        public virtual T Get(int id)
        {
            return this.DbSet.Find(id);
        }

        public virtual T Get(Guid id)
        {
            return this.DbSet.Find(id);
        }

        public virtual T FirstOrDefault()
        {
            return this.DbSet.FirstOrDefault();
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> conditions)
        {
            return this.DbSet.FirstOrDefault(conditions);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual bool All(Expression<Func<T, bool>> conditions)
        {
            return this.DbSet.All(conditions);
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = this.Get(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Delete(Expression<Func<T, bool>> conditions)
        {
            foreach (var item in this.GetAll().Where(conditions))
            {
                this.Delete(item);
            }
        }

        public virtual void Detach(T entity)
        {
            DbEntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> conditions)
        {
             return this.GetAll().Where(conditions);
        }

        public virtual bool Any(Expression<Func<T, bool>> conditions)
        {
            return this.DbSet.Any(conditions);
        }

        public virtual int Count(Expression<Func<T, bool>> conditions)
        {
            return this.DbSet.Count(conditions);
        }

        public void Dispose()
        {
                this.Context.Dispose();
        }
    }
}
