// Warrior.cs
namespace DragonHunt.Library
{
    public class Warrior : Character
    {
        public int AttacksPerRound { get; set; }

        public Warrior() : base()
        {
            // Default values for warrior
        }

        public Warrior(string name)
            : base(name, 1, 0, 15, 10, 8, 150, 150, 8, 2)
        {
            AttacksPerRound = 2;
        }

        public override int DamagePerRound => DamageDealt * AttacksPerRound;

        public override void LevelUp()
        {
            base.LevelUp();
            MaxHealthPoints += 15;
            Strength += 3;
            if (Level % 3 == 0)
            {
                AttacksPerRound++;
            }
            CurrentHealthPoints = MaxHealthPoints;
        }
    }
}