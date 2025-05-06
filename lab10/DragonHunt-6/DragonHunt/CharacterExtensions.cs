// CharacterExtensions.cs
namespace DragonHunt.Extensions
{
    public static class CharacterExtensions
    {
        public static void DrinkHealingPotion(this Library.Character character)
        {
            character.CurrentHealthPoints = character.MaxHealthPoints;
        }

        public static void RegenerateMana(this Library.Wizard wizard, int manaAmount)
        {
            wizard.CurrentManaPoints = System.Math.Min(wizard.CurrentManaPoints + manaAmount, wizard.MaxManaPoints);
        }

        public static void Disarm(this Library.Character character, int damageDecrease)
        {
            character.DamageDealt = System.Math.Max(0, character.DamageDealt - damageDecrease);
        }

        public static void RemoveArmor(this Library.Character character, int resistanceDecrease)
        {
            character.DamageResistance = System.Math.Max(0, character.DamageResistance - resistanceDecrease);
        }
    }
}