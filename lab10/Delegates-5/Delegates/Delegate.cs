// Delegate for methods that take a Mercenary parameter and return void
public delegate void MercenaryAction(Mercenary mercenary);

// Delegate for methods that take a Quest parameter and return void
public delegate void QuestAction(Quest quest);

// Delegate for methods that take both Mercenary and Quest parameters and return void
public delegate void MercenaryQuestAction(Mercenary mercenary, Quest quest);