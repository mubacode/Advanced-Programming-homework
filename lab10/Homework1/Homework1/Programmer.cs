using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    internal class Programmer : Employee
    {
        public int NumberOfTechnologies { get; set; }

        public Programmer() {}
        public Programmer(int id, string name, string lastName, int age, string gender, double salary, int numberOfTechnologies) :
            base(id, name, lastName, age, gender, salary)
        {
            NumberOfTechnologies = numberOfTechnologies;
        }
        public override void IncreaseSalary(double amount)
        {
            base.IncreaseSalary(amount + (100 * NumberOfTechnologies));
        }

        public override string ToString()
        {
            return base.ToString() + $", Number of technologies used: {NumberOfTechnologies}";
        }

    }
}