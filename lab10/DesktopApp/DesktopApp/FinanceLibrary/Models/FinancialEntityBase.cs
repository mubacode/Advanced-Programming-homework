using FinanceLibrary.Interfaces;
using System;

namespace FinanceLibrary.Models
{
    public abstract class FinancialEntityBase : IFinancialEntity
    {
        public string Id { get; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        protected FinancialEntityBase()
        {
            Id = Guid.NewGuid().ToString();
            Date = DateTime.Now;
        }

        protected FinancialEntityBase(string name, decimal amount, string description)
            : this()
        {
            Name = name;
            Amount = amount;
            Description = description;
        }
    }
} 