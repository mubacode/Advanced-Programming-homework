using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        private int age;
        public string Gender { get; set; }
        private double salary;
        public Employee() { }
        public Employee(int id, string name, string lastName, int age, string gender, double salary)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Salary = salary;
        }
        public int Age
        {
            get { return age; }
            set {
                if (age >= 0)
                    age = value;
                else
                    Console.WriteLine("age cannote be negative");

            }
        }
        public double Salary
        {
            get { return salary; }
            set
            {
                if (salary >= 0)
                    salary = value;
                else
                    Console.WriteLine("Salary cannot be negative.");
            }
        }
        public virtual void IncreaseSalary(double amount)
        {
            Salary += amount;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Lastname: {LastName}, Age: {Age}, Gender: {Gender}, Salary: {Salary}";
        }
    }  
}
