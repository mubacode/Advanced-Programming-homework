using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class ProjectManager : Employee
    {
        public int NumberOfProject { get; set; }
        public ProjectManager() { }
        public ProjectManager(int id, string name, string lastName, int age, string gender, double salary, int numberOfProject)
            : base(id, name, lastName, age, gender, salary)
        {
            NumberOfProject = numberOfProject;
        }
        public override void IncreaseSalary(double amount)
        {
            base.IncreaseSalary(amount + (NumberOfProject * 300));
        }

        public override string ToString()
        {
            return base.ToString() + $", Number of projects {NumberOfProject}";
        }
    }
}