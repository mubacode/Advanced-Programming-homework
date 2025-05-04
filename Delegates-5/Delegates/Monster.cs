public class Monster
{
    // Properties
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    // Constructor
    public Monster(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    // Override ToString
    public override string ToString()
    {
        return $"{Name} - HP: {Health}, DMG: {Damage}";
    }
}