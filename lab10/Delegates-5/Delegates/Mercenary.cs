// Difficulty levels for quests
public enum QuestDifficulty
{
    Training,
    Easy,
    NotSoEasy,
    Hard,
    VeryHard,
    NightmarishlyHard
}
public class Mercenary
{
    // Properties
    public string Name { get; set; }
    public int Level { get; set; }
    public int ExperiencePoints { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public int Damage { get; set; }
    public int Gold { get; set; }

    // Constructor
    public Mercenary(string name, int level, int maxHealth, int damage, int gold)
    {
        Name = name;
        Level = level;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        Damage = damage;
        Gold = gold;
        ExperiencePoints = 0;
    }

    // Override ToString
    public override string ToString()
    {
        return $"{Name} (Lvl {Level}) - HP: {CurrentHealth}/{MaxHealth}, DMG: {Damage}, Gold: {Gold}, XP: {ExperiencePoints}";
    }
}