using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    internal class Analyst : Employee
    {
        public int NumberOfCustomer { get; set; }
        public Analyst(){}
        public Analyst(int id, string name, string lastName, int age, string gender, double salary, int numberOfCustomer) :
            base(id, name, lastName, age, gender, salary)
        {
            NumberOfCustomer = numberOfCustomer;
        }
        public override void IncreaseSalary(double amount)
        {
            base.IncreaseSalary(amount + (200 * NumberOfCustomer));
        }
        public override string ToString()
        {
            return base.ToString() + $"Number of customer: {NumberOfCustomer}";
        }

    }
}
