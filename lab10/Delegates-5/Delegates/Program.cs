class Program
{
    static void Main(string[] args)
    {
        // Create guild
        var guild = new Guild();

        // Setup event handlers
        guild.OnMercenaryHired += mercenary =>
            Console.WriteLine($"\u001b[32m{mercenary.Name} has joined the guild!\u001b[0m");

        guild.OnQuestAdded += quest =>
            Console.WriteLine($"\u001b[34mNew quest available: {quest.Name} ({quest.Difficulty})\u001b[0m");

        guild.OnQuestStarting += (mercenary, quest) =>
            Console.WriteLine($"\u001b[33m{mercenary.Name} is embarking on {quest.Name}...\u001b[0m");

        guild.OnQuestCompleted += (mercenary, quest) =>
        {
            if (mercenary.CurrentHealth > 0)
            {
                Console.WriteLine($"\u001b[36m{mercenary.Name} completed {quest.Name} and earned {quest.RewardGold}g!\u001b[0m");
            }
            else
            {
                Console.WriteLine($"\u001b[31m{mercenary.Name} was defeated on {quest.Name}!\u001b[0m");
            }
        };

        // Add some mercenaries
        guild.HireMercenary(new Mercenary("Grimgor", 5, 100, 25, 50));
        guild.HireMercenary(new Mercenary("Elena", 3, 70, 15, 30));
        guild.HireMercenary(new Mercenary("Thorgar", 7, 120, 30, 75));

        // Add some quests
        guild.AddQuest(new Quest(
            "Goblin Hunt",
            "Clear out the goblin infestation in the old mines",
            "Blackrock Mines",
            QuestDifficulty.Easy,
            new Monster("Goblin Chief", 40, 10),
            50, 25));

        guild.AddQuest(new Quest(
            "Dragon Slaying",
            "The red dragon is terrorizing the countryside",
            "Mount Doom",
            QuestDifficulty.VeryHard,
            new Monster("Red Dragon", 200, 50),
            500, 1000));

        // Test ForEach methods
        Console.WriteLine("\nAll Mercenaries:");
        guild.ForEachMercenary(m => Console.WriteLine($"- {m}"));

        Console.WriteLine("\nAll Quests:");
        guild.ForEachQuest(q => Console.WriteLine($"- {q}"));

        // Test search methods
        Console.WriteLine("\nMercenaries above level 4:");
        var highLevel = guild.FindMercenariesByLevelOrHealth(4, 0);
        highLevel.ForEach(m => Console.WriteLine($"- {m}"));

        // Send mercenaries on quests
        Console.WriteLine("\nSending mercenaries on quests:");
        guild.SendOnQuest("Elena", "Goblin Hunt");
        guild.SendOnQuest("Grimgor", "Dragon Slaying");
        guild.SendOnQuest("Thorgar", "Dragon Slaying");

        // Show mercenary status after quests
        Console.WriteLine("\nMercenary Status After Quests:");
        guild.ForEachMercenary(m => Console.WriteLine($"- {m}"));
    }
}