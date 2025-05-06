using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    internal class RemoteProgrammer : Programmer
    {
        public double Distance { get; set; }
         
        public RemoteProgrammer() { }
        public RemoteProgrammer(int id, string name, string lastName, int age, string gender, double salary, int numberOfTechnologies, double distance) :
            base(id, name, lastName, age, gender, salary, numberOfTechnologies)
        {
            Distance = distance;
        }
        public override void IncreaseSalary(double amount)
        {
            base.IncreaseSalary(amount + (50 * Distance/100)); //50PLN per 100KM
        }
        public override string ToString()
            
        {
            return base.ToString() + $", Distance: {Distance}km";
        }

    }
}
