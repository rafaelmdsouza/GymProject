using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Gym.Domain.Core.Data
{
    public interface IRepository<T, TKey> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(TKey id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
