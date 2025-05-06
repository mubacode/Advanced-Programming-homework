using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test generic methods
        Console.WriteLine("Testing Generic Methods:");

        // Test Swap
        int a = 5, b = 10;
        Console.WriteLine($"Before swap: a={a}, b={b}");
        GenericMethods.Swap(ref a, ref b);
        Console.WriteLine($"After swap: a={a}, b={b}");

        // Test Person and Car classes
        Console.WriteLine("\nTesting Person and Car classes:");
        var person1 = new Person("John", "Doe", 30, new List<Car>
        {
            new Car("Toyota", 25000),
            new Car("Honda", 22000)
        });

        var person2 = new Person("Jane", "Smith", 25, new List<Car>
        {
            new Car("BMW", 50000)
        });

        // Test IEnumerable implementation
        Console.WriteLine("\nJohn's cars:");
        foreach (var car in person1)
        {
            Console.WriteLine(car);
        }

        // Test sorting people by total car value
        var people = new List<Person> { person1, person2 };
        people.Sort();
        Console.WriteLine("\nPeople sorted by total car value:");
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }

        // Test Quartet
        Console.WriteLine("\nTesting Quartet:");
        var quartets = new List<Quartet<int, string, double, bool>>
        {
            new Quartet<int, string, double, bool>(2, "Second", 2.5, true),
            new Quartet<int, string, double, bool>(1, "First", 1.5, false),
            new Quartet<int, string, double, bool>(3, "Third", 3.5, true)
        };

        quartets.Sort();
        Console.WriteLine("Sorted Quartets:");
        foreach (var quartet in quartets)
        {
            Console.WriteLine(quartet);
        }
    }
}