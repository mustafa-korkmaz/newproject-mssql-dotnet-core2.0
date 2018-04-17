using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly BlogDbContext _context;
        private DbSet<TEntity> _entities;

        public EntityFrameworkRepository(BlogDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        public TEntity GetById(object id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var attachedEntity = _entities.Local.FirstOrDefault(e => e.Id == entity.Id);

            if (attachedEntity != null)
            {
                _context.Entry(attachedEntity).State = EntityState.Detached;
            }

            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            //check entity state
            var dbEntityEntry = _context.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _entities.Attach(entity);
                _entities.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;

            Delete(entity);
        }

        public IQueryable<TEntity> AsQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _entities;
        }

        public IQueryable<TEntity> RawSql(string sql)
        {
            return _entities.FromSql(sql);
        }

    }
}