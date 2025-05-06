// Archer.cs
using System;

namespace DragonHunt.Library
{
    public class Archer : Character
    {
        public int DodgeChancePercent { get; set; }
        private Random random = new Random();

        public Archer() : base()
        {
            // Default values for archer
        }

        public Archer(string name)
            : base(name, 1, 0, 10, 15, 10, 100, 100, 10, 1)
        {
            DodgeChancePercent = 20;
        }

        public override void TakeDamage(int damage)
        {
            if (random.Next(1, 101) <= DodgeChancePercent)
            {
                // Dodged the attack
                return;
            }

            base.TakeDamage(damage);
        }

        public override void LevelUp()
        {
            base.LevelUp();
            MaxHealthPoints += 8;
            Dexterity += 3;
            DodgeChancePercent += 2;
            CurrentHealthPoints = MaxHealthPoints;
        }
    }
}