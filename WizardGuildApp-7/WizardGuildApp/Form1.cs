using System;
using System.Windows.Forms;

namespace WizardsGuild
{
    public partial class Form1 : Form
    {
        private WizardsGuild guild = new WizardsGuild();

        public Form1()
        {
            InitializeComponent();
            InitializeGuild();
            cboSpellType.SelectedIndex = 0;
        }

        private void InitializeGuild()
        {
            // Create sample wizards
            var gandalf = new Wizard
            {
                Name = "Gandalf",
                Level = 20,
                Experience = 5000,
                Strength = 15,
                Dexterity = 18,
                Intelligence = 25,
                CurrentHealth = 100,
                MaxHealth = 100,
                CurrentMana = 200,
                MaxMana = 200,
                Damage = 30,
                PhysicalResistance = 20,
                FireResistance = 50,
                FrostResistance = 30,
                PoisonResistance = 10
            };

            gandalf.Spellbook.AddRange(new[]
            {
                new MagicSpell { Name = "Fireball", Type = SpellType.Offensive, ManaCost = 20, Cooldown = 3, Effect = 50 },
                new MagicSpell { Name = "Ice Shard", Type = SpellType.Offensive, ManaCost = 15, Cooldown = 2, Effect = 30 },
                new MagicSpell { Name = "Healing Touch", Type = SpellType.Healing, ManaCost = 25, Cooldown = 5, Effect = 40 },
                new MagicSpell { Name = "Magic Shield", Type = SpellType.Defensive, ManaCost = 30, Cooldown = 10, Effect = 25 }
            });

            var merlin = new Wizard
            {
                Name = "Merlin",
                Level = 25,
                Experience = 7500,
                Strength = 12,
                Dexterity = 15,
                Intelligence = 30,
                CurrentHealth = 90,
                MaxHealth = 90,
                CurrentMana = 250,
                MaxMana = 250,
                Damage = 25,
                PhysicalResistance = 15,
                FireResistance = 40,
                FrostResistance = 40,
                PoisonResistance = 20
            };

            merlin.Spellbook.AddRange(new[]
            {
                new MagicSpell { Name = "Fireball", Type = SpellType.Offensive, ManaCost = 20, Cooldown = 3, Effect = 50 },
                new MagicSpell { Name = "Arcane Barrier", Type = SpellType.Defensive, ManaCost = 35, Cooldown = 12, Effect = 30 },
                new MagicSpell { Name = "Mass Heal", Type = SpellType.Healing, ManaCost = 50, Cooldown = 8, Effect = 60 }
            });

            guild.AddMember(gandalf);
            guild.AddMember(merlin);
        }

        private void ClearAndAdd(string message)
        {
            resultsListBox.Items.Clear();
            resultsListBox.Items.Add(message);
        }

        private void btnAllWizards_Click(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
            foreach (var wizard in guild.GetAllWizards())
            {
                resultsListBox.Items.Add(wizard.ToString());
                resultsListBox.Items.Add("");
            }
        }

        private void btnExperiencedWizards_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMinLevel.Text, out int minLevel))
            {
                resultsListBox.Items.Clear();
                foreach (var wizard in guild.GetExperiencedWizards(minLevel))
                {
                    resultsListBox.Items.Add(wizard.ToString());
                    resultsListBox.Items.Add("");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid minimum level.");
            }
        }

        private void btnGetSpellsByType_Click(object sender, EventArgs e)
        {
            SpellType selectedType = (SpellType)cboSpellType.SelectedIndex;
            resultsListBox.Items.Clear();

            var spells = guild.GetSpellsByType(selectedType);
            resultsListBox.Items.Add($"{selectedType} Spells:");
            resultsListBox.Items.Add("");

            foreach (var spell in spells)
            {
                resultsListBox.Items.Add(spell.ToString());
                resultsListBox.Items.Add("");
            }
        }

        private void btnTournamentReady_Click(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
            bool ready = guild.AreAllWizardsReadyForTournament();

            resultsListBox.Items.Add(ready
                ? "All wizards are ready for tournament!"
                : "Not all wizards are ready:");
            resultsListBox.Items.Add("");

            foreach (var wizard in guild.GetAllWizards())
            {
                resultsListBox.Items.Add($"{wizard.Name}: " +
                    $"{wizard.CurrentHealth}/{wizard.MaxHealth} HP, " +
                    $"{wizard.CurrentMana}/{wizard.MaxMana} MP");
                resultsListBox.Items.Add("");
            }
        }

        private void btnCheckUnconscious_Click(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
            bool anyUnconscious = guild.IsAnyWizardUnconscious();

            resultsListBox.Items.Add(anyUnconscious
                ? "Unconscious wizards:"
                : "No unconscious wizards");
            resultsListBox.Items.Add("");

            foreach (var wizard in guild.GetAllWizards().Where(w => w.CurrentHealth == 0))
            {
                resultsListBox.Items.Add($"{wizard.Name} is unconscious!");
                resultsListBox.Items.Add("");
            }
        }

        private void btnSimulateBattle_Click(object sender, EventArgs e)
        {
            guild.SimulateBattle();
            ClearAndAdd("Battle simulated! Check wizard status.");
            btnAllWizards.PerformClick();
        }

        private void btnRestAll_Click(object sender, EventArgs e)
        {
            guild.RestAllWizards();
            ClearAndAdd("All wizards have rested and recovered fully!");
            btnAllWizards.PerformClick();
        }

        private void btnCastSpell_Click(object sender, EventArgs e)
        {
            var wizard = guild.GetAllWizards().First();
            var spell = wizard.Spellbook.First();

            if (wizard.CastSpell(spell))
            {
                ClearAndAdd($"{wizard.Name} cast {spell.Name}!");
            }
            else
            {
                ClearAndAdd($"{wizard.Name} doesn't have enough mana for {spell.Name}!");
            }
            btnAllWizards.PerformClick();
        }
    }
}