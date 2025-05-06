using FinanceLibrary.Models;

namespace FinanceLibrary.Models
{
    public class Income : FinancialEntityBase
    {
        public IncomeCategory Category { get; set; }

        public Income() : base()
        {
        }

        public Income(string name, decimal amount, string description, IncomeCategory category)
            : base(name, amount, description)
        {
            Category = category;
        }
    }

    public enum IncomeCategory
    {
        Salary,
        Investment,
        Gift,
        Other
    }
} 