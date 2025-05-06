namespace Homework1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        // Constant for the company's annual budget
        private const double AnnualBudget = 1000000; // Example: 1,000,000 PLN

        // List to store all employees
        private static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            // Initialize the employee list with some sample data
            InitializeEmployees();

            // Display the main menu
            while (true)
            {
                DisplayMenu();
                int choice = GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        DisplayAllEmployees();
                        break;
                    case 2:
                        DisplayEmployeesSortedBySalary();
                        break;
                    case 3:
                        DisplayEmployeeById();
                        break;
                    case 4:
                        IncreaseEmployeeSalary();
                        break;
                    case 5:
                        IncreaseAllSalaries();
                        break;
                    case 6:
                        DisplayAnnualSummary();
                        break;
                    case 7:
                        Console.WriteLine("Exiting the application...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        // Method to initialize the employee list with sample data
        private static void InitializeEmployees()
        {
            employees.Add(new ProjectManager(1, "John", "Doe", 40, "Male", 10000, 5));
            employees.Add(new Analyst(2, "Jane", "Smith", 35, "Female", 8000, 10));
            employees.Add(new Programmer(3, "Alice", "Johnson", 30, "Female", 7000, 8));
            employees.Add(new RemoteProgrammer(4, "Bob", "Brown", 28, "Male", 7500, 6, 100));
        }

        // Method to display the main menu
        private static void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===== Employee Management System =====");
            Console.ResetColor();
            Console.WriteLine("1. Display all employees");
            Console.WriteLine("2. Display all employees sorted by salary (descending)");
            Console.WriteLine("3. Display employee by ID");
            Console.WriteLine("4. Increase salary of an employee");
            Console.WriteLine("5. Increase salaries for all employees");
            Console.WriteLine("6. Display annual summary");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
        }

        // Method to get the user's menu choice
        private static int GetMenuChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }
            return choice;
        }

        // Method to display all employees
        private static void DisplayAllEmployees()
        {
            Console.WriteLine("\n===== All Employees =====");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        // Method to display all employees sorted by salary in descending order
        private static void DisplayEmployeesSortedBySalary()
        {
            Console.WriteLine("\n===== Employees Sorted by Salary (Descending) =====");
            var sortedEmployees = employees.OrderByDescending(e => e.Salary).ToList();
            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine(employee);
            }
        }

        // Method to display an employee by ID
        private static void DisplayEmployeeById()
        {
            Console.Write("\nEnter employee ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid input. Please enter a valid ID: ");
            }

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                Console.WriteLine(employee);
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // Method to increase the salary of an employee by a specified amount
        private static void IncreaseEmployeeSalary()
        {
            Console.Write("\nEnter employee ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.Write("Invalid input. Please enter a valid ID: ");
            }

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                Console.Write("Enter the amount to increase the salary: ");
                double amount;
                while (!double.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Invalid input. Please enter a valid amount: ");
                }

                employee.IncreaseSalary(amount);
                Console.WriteLine($"Salary increased. New salary: {employee.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        // Method to increase salaries for all employees by a specified amount
        private static void IncreaseAllSalaries()
        {
            Console.Write("\nEnter the amount to increase all salaries: ");
            double amount;
            while (!double.TryParse(Console.ReadLine(), out amount))
            {
                Console.Write("Invalid input. Please enter a valid amount: ");
            }

            foreach (var employee in employees)
            {
                employee.IncreaseSalary(amount);
            }
            Console.WriteLine("Salaries increased for all employees.");
        }

        // Method to display the annual summary
        private static void DisplayAnnualSummary()
        {
            double totalSalaries = employees.Sum(e => e.Salary * 12); // Annual salary expenses
            double difference = AnnualBudget - totalSalaries;

            Console.WriteLine("\n===== Annual Summary =====");
            Console.WriteLine($"Annual Budget: {AnnualBudget}");
            Console.WriteLine($"Total Annual Salary Expenses: {totalSalaries}");
            Console.Write("Difference: ");
            if (difference >= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{difference} (In the plus)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{difference} (In the red)");
            }
            Console.ResetColor();
        }
    }
}
