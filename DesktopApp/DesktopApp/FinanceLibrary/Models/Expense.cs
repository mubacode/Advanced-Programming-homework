using FinanceLibrary.Models;

namespace FinanceLibrary.Models
{
    public class Expense : FinancialEntityBase
    {
        public ExpenseCategory Category { get; set; }

        public Expense() : base()
        {
        }

        public Expense(string name, decimal amount, string description, ExpenseCategory category)
            : base(name, amount, description)
        {
            Category = category;
        }
    }

    public enum ExpenseCategory
    {
        Food,
        Housing,
        Transportation,
        Entertainment,
        Health,
        Education,
        Other
    }
} 