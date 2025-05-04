class Program
{
    static void Main(string[] args)
    {
        var manager = new AnimalManager();

        // Adding animals
        manager.AddAnimal(new Sheep("Wooley", 2, 45.5));
        manager.AddAnimal(new Sheep("Dolly", 1, 35.2));
        manager.AddAnimal(new Wolf("Grey", 3, 65.8));
        manager.AddAnimal(new Wolf("Hunter", 4, 70.2));
        manager.AddAnimal(new Pig("Peppa", 1, 30.0));
        manager.AddAnimal(new Pig("George", 1, 25.5));

        // Copy to specialized lists
        manager.CopyToSpecializedLists();

        // Display all lists
        manager.DisplayAllAnimals();
        manager.DisplayAllHerbivores();
        manager.DisplayAllCarnivores();

        Console.WriteLine("\n--- Group Feeding ---");
        manager.FeedAllHerbivores();
        manager.FeedAllCarnivores();

        Console.WriteLine("\n--- Individual Feeding ---");
        var animal = manager.FindAnimalByName("Peppa");
        if (animal is IHerbivore herbivore)
            AnimalManager.FeedHerbivore(herbivore);
        if (animal is ICarnivore carnivore)
            AnimalManager.FeedCarnivore(carnivore);
    }
}