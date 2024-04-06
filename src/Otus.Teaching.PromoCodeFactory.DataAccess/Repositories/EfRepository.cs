using Microsoft.EntityFrameworkCore;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public EfRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public Task<Guid> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return Task.FromResult(entity.Id);
        }

        public Task AddRange(List<T> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var itemToDelete = await _dbSet.Where(x => x.Id == id).ToListAsync();

            if (itemToDelete.Count != 0)
            {
                foreach (var item in itemToDelete)
                {
                    _dbSet.Remove(item);
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<Guid> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return Task.FromResult(entity.Id);
        }
    }
}
