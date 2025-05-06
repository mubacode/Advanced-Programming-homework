public class Quest
{
    // Properties
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public QuestDifficulty Difficulty { get; set; }
    public Monster Monster { get; set; }
    public int RewardExperience { get; set; }
    public int RewardGold { get; set; }

    // Constructor
    public Quest(string name, string description, string location, QuestDifficulty difficulty,
                Monster monster, int rewardExp, int rewardGold)
    {
        Name = name;
        Description = description;
        Location = location;
        Difficulty = difficulty;
        Monster = monster;
        RewardExperience = rewardExp;
        RewardGold = rewardGold;
    }

    // Override ToString
    public override string ToString()
    {
        return $"{Name} ({Difficulty}) at {Location} - Reward: {RewardGold}g, {RewardExperience}xp\n" +
               $"Monster: {Monster}\nDescription: {Description}";
    }
}