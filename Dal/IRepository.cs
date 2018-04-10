using System;
using System.Linq;
using System.Linq.Expressions;

namespace Dal
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate);
        IQueryable<T> AsQueryable();
        IQueryable<T> RawSql(string sql);

        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
