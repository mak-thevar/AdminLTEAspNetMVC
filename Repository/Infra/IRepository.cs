using System;
using System.Linq;
using System.Linq.Expressions;

namespace AspMVCAdminLTE.Repository.Infra
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        T Create(T entity);

        T Update(T entity);

        void Delete(T entity);
    }
}