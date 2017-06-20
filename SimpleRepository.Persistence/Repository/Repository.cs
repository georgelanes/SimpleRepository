using Microsoft.EntityFrameworkCore;
using SimpleRepository.Core.Abstract;
using SimpleRepository.Core.Interfaces;
using SimpleRepository.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleRepository.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> _entity;
        string _errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            _entity = context.Set<T>();
        }
        public IEnumerable<T> GetAll(string[] includes=null)
        {
            ///Add Include Expressions dynamically
            if (includes != null)
            {
                foreach(var include in includes)
                {
                    _entity.Include(include);
                }
            }

            return _entity.AsEnumerable();
        }

        public T Get(int id)
        {
            return _entity.SingleOrDefault(s => s.Id == id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _entity.Where(where).ToList();
        }

        public bool Any(Expression<Func<T, bool>> @where)
        {
            return _entity.Any(where);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entity.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entity.Remove(entity);
        }
    }
}
