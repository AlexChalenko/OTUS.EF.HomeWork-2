using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected IEnumerable<T> Data { get; set; }

        public InMemoryRepository(IEnumerable<T> data)
        {
            Data = data;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(Data);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task<Guid> AddAsync(T entity)
        {
            Data = Data.Append(entity);
            return Task.FromResult(entity.Id);
        }

        public Task AddRange(List<T> entities)
        {
            foreach (var entity in entities)
            {
                Data = Data.Append(entity);
            }
            return Task.CompletedTask;
        }

        public Task<Guid> UpdateAsync(T entity)
        {
            var itemToUpdate = Data.FirstOrDefault(x => x.Id == entity.Id);
            if (Data.ToList().Remove(itemToUpdate))
            {
                Data = Data.Append(entity);
                return Task.FromResult(entity.Id);
            }
            else
            {
                throw new Exception("Entity not found");
            }
        }

        public Task DeleteAsync(Guid id)
        {
            var itemToDelete = Data.FirstOrDefault(x => x.Id == id);
            if (Data.ToList().Remove(itemToDelete))
            {
                return Task.CompletedTask;
            }
            else
            {
                throw new Exception("Entity not found");
            }
        }
    }
}