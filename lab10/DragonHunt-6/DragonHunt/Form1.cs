// Form1.cs
using System;
using System.Windows.Forms;
using DragonHunt.Library;
using DragonHunt.Extensions;

namespace DragonHunt.App
{
    public partial class Form1 : Form
    {
        private Warrior warrior;
        private Archer archer;
        private Wizard wizard;
        private Dragon dragon;
        private int healingPotionsCount;

        public Form1()
        {
            InitializeComponent();
            InitializeCharacters();
            InitializeUI();
        }

        private void InitializeCharacters()
        {
            warrior = new Warrior("Conan");
            archer = new Archer("Legolas");
            wizard = new Wizard("Gandalf");

            dragon = new Dragon
            {
                Name = "Smaug",
                Level = 10,
                Strength = 25,
                Dexterity = 15,
                Intelligence = 20,
                MaxHealthPoints = 500,
                CurrentHealthPoints = 500,
                DamageDealt = 30,
                DamageResistance = 10,
                ExperienceReward = 1000
            };

            dragon.OnFireBreath += FireIntensity =>
            {
                warrior.TakeDamage(FireIntensity);
                archer.TakeDamage(FireIntensity);
                wizard.TakeDamage(FireIntensity);
                UpdateHealthBars();
            };

            healingPotionsCount = 3;
        }

        private void InitializeUI()
        {
            // Set character names
            lblWarrior.Text = warrior.Name;
            lblArcher.Text = archer.Name;
            lblWizard.Text = wizard.Name;
            lblDragon.Text = dragon.Name;

            // Configure health bars
            pbWarrior.Minimum = 0;
            pbWarrior.Maximum = warrior.MaxHealthPoints;
            pbWarrior.Value = warrior.CurrentHealthPoints;

            pbArcher.Minimum = 0;
            pbArcher.Maximum = archer.MaxHealthPoints;
            pbArcher.Value = archer.CurrentHealthPoints;

            pbWizard.Minimum = 0;
            pbWizard.Maximum = wizard.MaxHealthPoints;
            pbWizard.Value = wizard.CurrentHealthPoints;

            pbDragon.Minimum = 0;
            pbDragon.Maximum = dragon.MaxHealthPoints;
            pbDragon.Value = dragon.CurrentHealthPoints;

            // Set potion count
            lblPotions.Text = $"Healing Potions: {healingPotionsCount}";
        }

        private void UpdateHealthBars()
        {
            pbWarrior.Value = warrior.CurrentHealthPoints;
            pbArcher.Value = archer.CurrentHealthPoints;
            pbWizard.Value = wizard.CurrentHealthPoints;
            pbDragon.Value = dragon.CurrentHealthPoints;

            CheckBattleStatus();
        }

        private void btnWarriorHeal_Click(object sender, EventArgs e)
        {
            if (healingPotionsCount > 0)
            {
                warrior.DrinkHealingPotion();
                healingPotionsCount--;
                lblPotions.Text = $"Healing Potions: {healingPotionsCount}";
                UpdateHealthBars();

                if (healingPotionsCount == 0)
                {
                    DisablePotionButtons();
                }
            }
        }

        private void btnArcherHeal_Click(object sender, EventArgs e)
        {
            if (healingPotionsCount > 0)
            {
                archer.DrinkHealingPotion();
                healingPotionsCount--;
                lblPotions.Text = $"Healing Potions: {healingPotionsCount}";
                UpdateHealthBars();

                if (healingPotionsCount == 0)
                {
                    DisablePotionButtons();
                }
            }
        }

        private void btnWizardHeal_Click(object sender, EventArgs e)
        {
            if (healingPotionsCount > 0)
            {
                wizard.DrinkHealingPotion();
                healingPotionsCount--;
                lblPotions.Text = $"Healing Potions: {healingPotionsCount}";
                UpdateHealthBars();

                if (healingPotionsCount == 0)
                {
                    DisablePotionButtons();
                }
            }
        }

        private void DisablePotionButtons()
        {
            btnWarriorHeal.Enabled = false;
            btnArcherHeal.Enabled = false;
            btnWizardHeal.Enabled = false;
        }

        private void btnCombatRound_Click(object sender, EventArgs e)
        {
            ExecuteCombatRound();
        }

        private static void ExecuteCombatRound(Warrior warrior, Archer archer, Wizard wizard, Dragon dragon)
        {
            // Party attacks dragon
            if (!warrior.IsDead)
                dragon.TakeDamage(warrior.DamagePerRound);

            if (!archer.IsDead)
                dragon.TakeDamage(archer.DamagePerRound);

            if (!wizard.IsDead)
                dragon.TakeDamage(wizard.DamagePerRound);

            // Dragon breathes fire
            if (!dragon.IsDead)
                dragon.BreatheFire();
        }

        private void ExecuteCombatRound()
        {
            ExecuteCombatRound(warrior, archer, wizard, dragon);
            UpdateHealthBars();
        }

        private void CheckBattleStatus()
        {
            if (dragon.IsDead || (warrior.IsDead && archer.IsDead && wizard.IsDead))
            {
                btnCombatRound.Enabled = false;

                if (dragon.IsDead)
                {
                    lblBattleResult.Text = "Victory! The dragon has been defeated!";
                    // Award experience if any party members survived
                    if (!warrior.IsDead)
                        warrior.AddExperience(dragon.ExperienceReward);
                    if (!archer.IsDead)
                        archer.AddExperience(dragon.ExperienceReward);
                    if (!wizard.IsDead)
                        wizard.AddExperience(dragon.ExperienceReward);
                }
                else
                {
                    lblBattleResult.Text = "Defeat! All heroes have fallen!";
                }
            }
        }

        private void btnSimulateBattle_Click(object sender, EventArgs e)
        {
            while (!dragon.IsDead && !(warrior.IsDead && archer.IsDead && wizard.IsDead))
            {
                ExecuteCombatRound();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitializeCharacters();
            InitializeUI();
            btnCombatRound.Enabled = true;
            lblBattleResult.Text = "";
        }

        private void btnAddExpWarrior_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtExpWarrior.Text, out int exp) && exp > 0)
            {
                warrior.AddExperience(exp);
                pbWarrior.Maximum = warrior.MaxHealthPoints;
                pbWarrior.Value = warrior.CurrentHealthPoints;
            }
        }

        private void btnAddExpArcher_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtExpArcher.Text, out int exp) && exp > 0)
            {
                archer.AddExperience(exp);
                pbArcher.Maximum = archer.MaxHealthPoints;
                pbArcher.Value = archer.CurrentHealthPoints;
            }
        }

        private void btnAddExpWizard_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtExpWizard.Text, out int exp) && exp > 0)
            {
                wizard.AddExperience(exp);
                pbWizard.Maximum = wizard.MaxHealthPoints;
                pbWizard.Value = wizard.CurrentHealthPoints;
            }
        }

        private void pbWarrior_Click(object sender, EventArgs e)
        {

        }
    }
}