public class Pig : Animal, IHerbivore, ICarnivore
{
    public Pig(string name, int age, double weight) : base(name, age, weight) { }

    void IHerbivore.FindFood()
    {
        Console.WriteLine($"Pig {Name} is searching for vegetables...");
    }

    void ICarnivore.FindFood()
    {
        Console.WriteLine($"Pig {Name} is searching for meat scraps...");
    }

    public void EatPlant()
    {
        Console.WriteLine($"Pig {Name} is eating vegetables.");
    }

    public void EatMeat()
    {
        Console.WriteLine($"Pig {Name} is eating meat.");
    }
}