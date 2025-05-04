using System;

namespace FinanceLibrary.Interfaces
{
    public interface IFinancialEntity
    {
        string Id { get; }
        string Name { get; set; }
        decimal Amount { get; set; }
        DateTime Date { get; set; }
        string Description { get; set; }
    }
} 