public class Guild
{
    // Private lists
    private List<Mercenary> mercenaries = new List<Mercenary>();
    private List<Quest> quests = new List<Quest>();

    // Events
    public event MercenaryAction OnMercenaryHired;
    public event QuestAction OnQuestAdded;
    public event MercenaryQuestAction OnQuestStarting;
    public event MercenaryQuestAction OnQuestCompleted;

    // Add a mercenary to the guild
    public void HireMercenary(Mercenary mercenary)
    {
        if (mercenaries.Any(m => m.Name == mercenary.Name))
        {
            throw new ArgumentException($"A mercenary named {mercenary.Name} already exists in the guild.");
        }

        mercenaries.Add(mercenary);
        OnMercenaryHired?.Invoke(mercenary);
    }

    // Add a quest to the guild
    public void AddQuest(Quest quest)
    {
        if (quests.Any(q => q.Name == quest.Name))
        {
            throw new ArgumentException($"A quest named {quest.Name} already exists in the guild.");
        }

        quests.Add(quest);
        OnQuestAdded?.Invoke(quest);
    }

    // Send a mercenary on a quest
    public void SendOnQuest(string mercenaryName, string questName)
    {
        var mercenary = mercenaries.Find(m => m.Name == mercenaryName);
        var quest = quests.Find(q => q.Name == questName);

        if (mercenary == null)
        {
            throw new ArgumentException($"Mercenary {mercenaryName} not found.");
        }

        if (quest == null)
        {
            throw new ArgumentException($"Quest {questName} not found.");
        }

        // Before quest starts
        OnQuestStarting?.Invoke(mercenary, quest);

        // Quest logic
        mercenary.CurrentHealth -= quest.Monster.Damage;

        if (mercenary.CurrentHealth > 0)
        {
            mercenary.ExperiencePoints += quest.RewardExperience;
            mercenary.Gold += quest.RewardGold;
        }
        else
        {
            mercenary.CurrentHealth = 0;
        }

        // After quest completes
        OnQuestCompleted?.Invoke(mercenary, quest);
    }

    // Perform action on all mercenaries
    public void ForEachMercenary(MercenaryAction action)
    {
        mercenaries.ForEach(m => action(m));
    }

    // Perform action on all quests
    public void ForEachQuest(QuestAction action)
    {
        quests.ForEach(q => action(q));
    }

    // Search methods
    public Mercenary FindMercenaryByName(string name)
    {
        return mercenaries.Find(m => m.Name == name);
    }

    public List<Mercenary> FindMercenariesByLevelOrHealth(int minLevel, int minHealth)
    {
        return mercenaries.FindAll(m => m.Level > minLevel || m.MaxHealth > minHealth);
    }

    public Quest FindQuestByName(string name)
    {
        return quests.Find(q => q.Name == name);
    }

    public List<Quest> FindQuestsByLocationAndDifficulty(string location, QuestDifficulty difficulty)
    {
        return quests.FindAll(q => q.Location == location && q.Difficulty == difficulty);
    }
}