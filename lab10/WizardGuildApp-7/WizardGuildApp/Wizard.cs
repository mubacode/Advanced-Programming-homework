namespace WizardsGuild
{
    public class Wizard
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentMana { get; set; }
        public int MaxMana { get; set; }
        public int Damage { get; set; }
        public int PhysicalResistance { get; set; }
        public int FireResistance { get; set; }
        public int FrostResistance { get; set; }
        public int PoisonResistance { get; set; }
        public Spellbook Spellbook { get; set; } = new Spellbook();

        public bool CastSpell(MagicSpell spell, Wizard target = null)
        {
            if (CurrentMana < spell.ManaCost)
                return false;

            CurrentMana -= spell.ManaCost;

            switch (spell.Type)
            {
                case SpellType.Offensive:
                    target?.TakeDamage(spell.Effect);
                    break;
                case SpellType.Defensive:
                    this.PhysicalResistance += spell.Effect;
                    break;
                case SpellType.Healing:
                    this.Heal(spell.Effect);
                    break;
            }

            return true;
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth = Math.Max(0, CurrentHealth - amount);
        }

        public void Heal(int amount)
        {
            CurrentHealth = Math.Min(MaxHealth, CurrentHealth + amount);
        }

        public void Rest()
        {
            CurrentHealth = MaxHealth;
            CurrentMana = MaxMana;
        }

        public override string ToString()
        {
            string status = CurrentHealth == 0 ? "UNCONSCIOUS" : "Ready";
            return $"{Name} (Level {Level}) - {status}\n" +
                   $"HP: {CurrentHealth}/{MaxHealth} | MP: {CurrentMana}/{MaxMana}\n" +
                   $"Stats: STR {Strength}, DEX {Dexterity}, INT {Intelligence}\n" +
                   $"Resistances: P{PhysicalResistance}% F{FireResistance}% I{FrostResistance}% T{PoisonResistance}%\n" +
                   $"Spells: {Spellbook.Count}";
        }
    }
}