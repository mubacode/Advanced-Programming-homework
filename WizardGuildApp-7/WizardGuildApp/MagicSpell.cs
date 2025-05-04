using System;

namespace WizardsGuild
{
    public enum SpellType
    {
        Offensive,
        Defensive,
        Healing
    }

    public class MagicSpell
    {
        public string Name { get; set; }
        public SpellType Type { get; set; }
        public int ManaCost { get; set; }
        public int Cooldown { get; set; }
        public int Effect { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Type}) - Cost: {ManaCost} mana, Cooldown: {Cooldown} turns, Effect: {Effect}";
        }

        public override bool Equals(object obj)
        {
            if (obj is MagicSpell other)
            {
                return this.ToString() == other.ToString();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}