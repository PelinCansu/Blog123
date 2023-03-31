using Blog123.Domain.Entities.Abstract;
using Blog123.Domain.Enums;
using Blog123.Domain.Repositories;
using Blog123.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Infrastructure.ConcreteRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly Blog123DbContext _dbContext;
        protected DbSet<T> _table;

        public BaseRepository(Blog123DbContext dbContext)
        {
            this._dbContext = dbContext;
            this._table = _dbContext.Set<T>();
        }

        public async Task Add(T item)
        {
            await _table.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }

        public async Task Delete(T item)
        {
            item.Status = Status.Deleted;
            await Update(item);
        }

        public async Task<List<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).FirstAsync();
           
         
        }

        public async Task<List<T>> GetDefault(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task Update(T item)
        {
            _dbContext.Entry<T>(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
