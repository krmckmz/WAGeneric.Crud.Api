﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crud.Core
{
    public interface IRepository<T> where T : class
    {
        ValueTask<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T item);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> entities);
    }
}
