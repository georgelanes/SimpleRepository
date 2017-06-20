using SimpleRepository.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleRepository.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(string[] includes=null);
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        bool Any(Expression<Func<T, bool>> where);
    }
}
