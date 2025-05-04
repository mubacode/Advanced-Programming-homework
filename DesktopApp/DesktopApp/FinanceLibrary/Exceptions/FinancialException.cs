using System;

namespace FinanceLibrary.Exceptions
{
    public class FinancialException : Exception
    {
        public FinancialException(string message) : base(message)
        {
        }

        public FinancialException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
} 