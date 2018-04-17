using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dal
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> AsQueryable(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> AsQueryable();
        IQueryable<TEntity> RawSql(string sql);

        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
    }
}
