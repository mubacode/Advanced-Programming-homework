using FinanceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceLibrary.Services
{
    public interface IFinancialService<T> where T : IFinancialEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetTotalAmountAsync();
    }
} 