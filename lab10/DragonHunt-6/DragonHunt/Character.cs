// Character.cs
using System;

namespace DragonHunt.Library
{
    public abstract class Character : IComparable<Character>
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int CurrentHealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }
        public int DamageDealt { get; set; }
        public int DamageResistance { get; set; }

        public Character()
        {
            Name = "Unknown";
            Level = 1;
            ExperiencePoints = 0;
            Strength = 10;
            Dexterity = 10;
            Intelligence = 10;
            MaxHealthPoints = 100;
            CurrentHealthPoints = MaxHealthPoints;
            DamageDealt = 5;
            DamageResistance = 0;
        }

        public Character(string name, int level, int experiencePoints, int strength, int dexterity,
                        int intelligence, int currentHealthPoints, int maxHealthPoints,
                        int damageDealt, int damageResistance)
        {
            Name = name;
            Level = level;
            ExperiencePoints = experiencePoints;
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            MaxHealthPoints = maxHealthPoints;
            CurrentHealthPoints = currentHealthPoints;
            DamageDealt = damageDealt;
            DamageResistance = damageResistance;
        }

        public override string ToString()
        {
            return $"{Name} (Level {Level}) - HP: {CurrentHealthPoints}/{MaxHealthPoints}";
        }

        public virtual void EquipWeapon(int damageIncrease)
        {
            DamageDealt += damageIncrease;
        }

        public virtual void EquipArmor(int resistanceIncrease)
        {
            DamageResistance += resistanceIncrease;
        }

        public virtual int DamagePerRound => DamageDealt;

        public virtual void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - DamageResistance);
            CurrentHealthPoints = Math.Max(0, CurrentHealthPoints - actualDamage);
        }

        public bool IsDead => CurrentHealthPoints <= 0;

        public virtual void LevelUp()
        {
            Level++;
            MaxHealthPoints += 10;
            Strength += 2;
            Dexterity += 2;
            Intelligence += 2;
            CurrentHealthPoints = MaxHealthPoints;
        }

        public virtual void AddExperience(int experience)
        {
            ExperiencePoints += experience;
            int experienceThreshold = CalculateExperienceThreshold();

            while (ExperiencePoints >= experienceThreshold)
            {
                LevelUp();
                ExperiencePoints -= experienceThreshold;
                experienceThreshold = CalculateExperienceThreshold();
            }
        }

        protected virtual int CalculateExperienceThreshold()
        {
            return Level * 100;
        }

        public int CompareTo(Character other)
        {
            if (other == null) return 1;
            return Level.CompareTo(other.Level);
        }
    }
}