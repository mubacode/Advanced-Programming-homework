using FinanceLibrary.Exceptions;
using FinanceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceLibrary.Services
{
    public class FinancialService<T> : IFinancialService<T> where T : IFinancialEntity
    {
        private readonly List<T> _entities = new List<T>();

        public async Task AddAsync(T entity)
        {
            if (entity == null)
                throw new FinancialException("Entity cannot be null");

            if (_entities.Any(e => e.Id == entity.Id))
                throw new FinancialException("Entity with this ID already exists");

            await Task.Run(() => _entities.Add(entity));
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new FinancialException("Entity cannot be null");

            var existingEntity = await GetByIdAsync(entity.Id);
            if (existingEntity == null)
                throw new FinancialException("Entity not found");

            await Task.Run(() =>
            {
                var index = _entities.FindIndex(e => e.Id == entity.Id);
                _entities[index] = entity;
            });
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new FinancialException("Entity not found");

            await Task.Run(() => _entities.Remove(entity));
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await Task.Run(() => _entities.FirstOrDefault(e => e.Id == id));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => _entities.AsEnumerable());
        }

        public async Task<IEnumerable<T>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await Task.Run(() =>
                _entities.Where(e => e.Date >= startDate && e.Date <= endDate)
                        .OrderBy(e => e.Date)
            );
        }

        public async Task<decimal> GetTotalAmountAsync()
        {
            return await Task.Run(() => _entities.Sum(e => e.Amount));
        }
    }
} 