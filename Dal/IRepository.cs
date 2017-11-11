using System;
using System.Linq;
using System.Linq.Expressions;
using Dal.Models;

namespace Dal
{
    public interface IRepository<T> where T : EntityBase
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
