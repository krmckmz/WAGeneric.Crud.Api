using Crud.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Crud.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T item)
        {
            await context.Set<T>().AddAsync(item);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
           await context.Set<T>().AddRangeAsync(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
           return context.Set<T>().Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public ValueTask<T> GetByIdAsync(int id)
        {
            return context.Set<T>().FindAsync(id);
        }

        public void Remove(T item)
        {
            context.Set<T>().Remove(item);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().SingleOrDefaultAsync(predicate);
        }
    }
}
