public class Wolf : Animal, ICarnivore
{
    public Wolf(string name, int age, double weight) : base(name, age, weight) { }

    public void FindFood()
    {
        Console.WriteLine($"Wolf {Name} is hunting for prey...");
    }

    public void EatMeat()
    {
        Console.WriteLine($"Wolf {Name} is eating meat.");
    }
}