using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AspMVCAdminLTE.Repository.Infra
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public T Create(T entity)
        {
            return this.RepositoryContext.Set<T>().Add(entity);
        }

        public T Update(T entity)
        {
            return this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
    }
}