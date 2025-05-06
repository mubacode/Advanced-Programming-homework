public class AnimalManager
{
    public List<Animal> Animals { get; } = new List<Animal>();
    public List<IHerbivore> Herbivores { get; } = new List<IHerbivore>();
    public List<ICarnivore> Carnivores { get; } = new List<ICarnivore>();

    public void AddAnimal(Animal animal)
    {
        Animals.Add(animal);
    }

    public void AddHerbivore(IHerbivore herbivore)
    {
        Herbivores.Add(herbivore);
    }

    public void AddCarnivore(ICarnivore carnivore)
    {
        Carnivores.Add(carnivore);
    }

    public void CopyToSpecializedLists()
    {
        foreach (var animal in Animals)
        {
            if (animal is IHerbivore herbivore)
                AddHerbivore(herbivore);
            if (animal is ICarnivore carnivore)
                AddCarnivore(carnivore);
        }
    }

    public void FeedAllHerbivores()
    {
        foreach (var herbivore in Herbivores)
        {
            herbivore.FindFood();
            herbivore.EatPlant();
        }
    }

    public void FeedAllCarnivores()
    {
        foreach (var carnivore in Carnivores)
        {
            carnivore.FindFood();
            carnivore.EatMeat();
        }
    }

    public static void FeedHerbivore(IHerbivore herbivore)
    {
        herbivore.FindFood();
        herbivore.EatPlant();
    }

    public static void FeedCarnivore(ICarnivore carnivore)
    {
        carnivore.FindFood();
        carnivore.EatMeat();
    }

    public void DisplayAllAnimals()
    {
        Console.WriteLine("\nAll Animals:");
        foreach (var animal in Animals)
        {
            Console.WriteLine(animal);
        }
    }

    public void DisplayAllHerbivores()
    {
        Console.WriteLine("\nAll Herbivores:");
        foreach (var herbivore in Herbivores)
        {
            Console.WriteLine(herbivore);
        }
    }

    public void DisplayAllCarnivores()
    {
        Console.WriteLine("\nAll Carnivores:");
        foreach (var carnivore in Carnivores)
        {
            Console.WriteLine(carnivore);
        }
    }

    public Animal? FindAnimalByName(string name)
    {
        return Animals.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}