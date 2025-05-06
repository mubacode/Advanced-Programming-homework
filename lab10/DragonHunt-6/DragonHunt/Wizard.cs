// Wizard.cs
namespace DragonHunt.Library
{
    public class Wizard : Character
    {
        public int CurrentManaPoints { get; set; }
        public int MaxManaPoints { get; set; }

        public Wizard() : base()
        {
            // Default values for wizard
        }

        public Wizard(string name)
            : base(name, 1, 0, 6, 8, 15, 80, 80, 12, 0)
        {
            MaxManaPoints = 100;
            CurrentManaPoints = MaxManaPoints;
        }

        public override int DamagePerRound => DamageDealt + (Intelligence / 2);

        public override void LevelUp()
        {
            base.LevelUp();
            MaxHealthPoints += 5;
            Intelligence += 3;
            MaxManaPoints += 20;
            CurrentManaPoints = MaxManaPoints;
            CurrentHealthPoints = MaxHealthPoints;
        }
    }
}