using System;
using System.Collections.Generic;
using System.Linq;

namespace WizardsGuild
{
    public class WizardsGuild
    {
        private List<Wizard> members = new List<Wizard>();
        private readonly Random rnd = new Random();

        public void AddMember(Wizard wizard)
        {
            if (wizard == null)
                throw new ArgumentNullException(nameof(wizard), "Wizard cannot be null");
            members.Add(wizard);
        }

        public IEnumerable<Wizard> GetAllWizards() => members.OrderBy(w => w.Name);

        public IEnumerable<Wizard> GetExperiencedWizards(int minLevel)
        {
            if (minLevel < 0)
                throw new ArgumentException("Minimum level cannot be negative", nameof(minLevel));
            return members.Where(w => w.Level > minLevel).OrderBy(w => w.Level);
        }

        public IEnumerable<Wizard> GetTalentedWizards(int maxLevel)
        {
            if (maxLevel < 0)
                throw new ArgumentException("Maximum level cannot be negative", nameof(maxLevel));
            return members.Where(w => w.Intelligence > 20 && w.Level <= maxLevel)
                  .OrderByDescending(w => w.Intelligence);
        }

        public int GetBattleMagesManaPotential() =>
            members.Where(w => w.Level > 2 && w.Dexterity > 10).Sum(w => w.CurrentMana);

        public IEnumerable<(string Name, int SpellCount, int TotalMana)> GetWizardsWithLargeSpellArsenal(int minSpells)
        {
            if (minSpells < 0)
                throw new ArgumentException("Minimum spells cannot be negative", nameof(minSpells));
            return members.Where(w => w.Spellbook.Count >= minSpells)
                  .Select(w => (w.Name, SpellCount: w.Spellbook.Count, w.CurrentMana))
                  .OrderByDescending(x => x.SpellCount);
        }

        public IEnumerable<(string Name, int Level, double AverageStats)> GetMostVersatileWizards() =>
            members.Select(w => (w.Name, w.Level,
                                 AverageStats: (w.Strength + w.Dexterity + w.Intelligence) / 3.0))
                  .OrderByDescending(x => x.AverageStats);

        public IEnumerable<string> GetWizardsWithMostSpells()
        {
            if (!members.Any()) return Enumerable.Empty<string>();
            int maxSpells = members.Max(w => w.Spellbook.Count);
            return members.Where(w => w.Spellbook.Count == maxSpells).Select(w => w.Name);
        }

        public IEnumerable<MagicSpell> GetAllUniqueSpells() =>
            members.SelectMany(w => w.Spellbook).Distinct();

        public IEnumerable<MagicSpell> GetSpellsByType(SpellType type) =>
            members.SelectMany(w => w.Spellbook)
                  .Where(s => s.Type == type)
                  .Distinct();

        public IEnumerable<MagicSpell> GetWizardSpellsByType(string wizardName, SpellType type)
        {
            if (string.IsNullOrWhiteSpace(wizardName))
                throw new ArgumentException("Wizard name cannot be null or empty", nameof(wizardName));
            
            var wizard = members.SingleOrDefault(w => w.Name == wizardName);
            if (wizard == null)
                throw new KeyNotFoundException($"Wizard with name '{wizardName}' not found");
                
            return wizard.Spellbook.Where(s => s.Type == type);
        }

        public IEnumerable<(SpellType Type, int Count)> GetSpellCountsByType() =>
            members.SelectMany(w => w.Spellbook)
                  .Distinct()
                  .GroupBy(s => s.Type)
                  .Select(g => (g.Key, g.Count()));

        public IEnumerable<(SpellType Type, int Count)> GetWizardSpellCountsByType(string wizardName)
        {
            if (string.IsNullOrWhiteSpace(wizardName))
                throw new ArgumentException("Wizard name cannot be null or empty", nameof(wizardName));
            
            var wizard = members.SingleOrDefault(w => w.Name == wizardName);
            if (wizard == null)
                throw new KeyNotFoundException($"Wizard with name '{wizardName}' not found");
                
            return wizard.Spellbook.GroupBy(s => s.Type)
                  .Select(g => (g.Key, g.Count()));
        }

        public IEnumerable<(string Name, int Level)> GetTopPowerfulWizards(int take, int skip)
        {
            if (take < 0)
                throw new ArgumentException("Take count cannot be negative", nameof(take));
            if (skip < 0)
                throw new ArgumentException("Skip count cannot be negative", nameof(skip));
                
            return members.OrderByDescending(w => w.Level)
                  .ThenByDescending(w => w.Experience)
                  .Skip(skip)
                  .Take(take)
                  .Select(w => (w.Name, w.Level));
        }

        public bool AreAllWizardsReadyForTournament() =>
            members.All(w => w.CurrentHealth == w.MaxHealth && w.CurrentMana == w.MaxMana);

        public bool IsAnyWizardUnconscious() =>
            members.Any(w => w.CurrentHealth == 0);

        public IEnumerable<(string Name, int Level, int TotalResistance, int Physical, int Fire, int Frost, int Poison)>
            GetBestWizardsForSpecialMission(int minLevel)
        {
            if (minLevel < 0)
                throw new ArgumentException("Minimum level cannot be negative", nameof(minLevel));
                
            return members.Where(w => w.Level > minLevel)
                  .Select(w => (w.Name, w.Level,
                              TotalResistance: w.PhysicalResistance + w.FireResistance + w.FrostResistance + w.PoisonResistance,
                              w.PhysicalResistance, w.FireResistance, w.FrostResistance, w.PoisonResistance))
                  .OrderByDescending(x => x.TotalResistance)
                  .Take(3);
        }

        public void SimulateBattle()
        {
            foreach (var wizard in members)
            {
                int damage = rnd.Next(10, 30);
                wizard.TakeDamage(damage);
            }
        }

        public void RestAllWizards()
        {
            foreach (var wizard in members)
            {
                wizard.Rest();
            }
        }
    }
}