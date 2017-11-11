using System;
using System.Linq;
using System.Linq.Expressions;
using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : EntityBase
    {
        private readonly BlogDbContext _context;
        private DbSet<T> _entities;

        public EntityFrameworkRepository(BlogDbContext context)
        {
            _context = context;
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            Entities.Add(entity);
        }

        public void Update(T entity)
        {
            var attachedEntity = Entities.Local.FirstOrDefault(e => e.Id == entity.Id);

            if (attachedEntity != null)
            {
                _context.Entry(attachedEntity).State = EntityState.Detached;
            }

            Entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
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

        public IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public IQueryable<T> AsQueryable()
        {
            return Entities;
        }

        public IQueryable<T> RawSql(string sql)
        {
            return _context.Set<T>().FromSql(sql);
        }

        private DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
