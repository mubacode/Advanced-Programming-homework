// Form1.Designer.cs
namespace DragonHunt.App
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblWarrior = new Label();
            lblArcher = new Label();
            lblWizard = new Label();
            lblDragon = new Label();
            pbWarrior = new ProgressBar();
            pbArcher = new ProgressBar();
            pbWizard = new ProgressBar();
            pbDragon = new ProgressBar();
            lblPotions = new Label();
            btnWarriorHeal = new Button();
            btnArcherHeal = new Button();
            btnWizardHeal = new Button();
            btnCombatRound = new Button();
            lblBattleResult = new Label();
            btnSimulateBattle = new Button();
            btnReset = new Button();
            txtExpWarrior = new TextBox();
            txtExpArcher = new TextBox();
            txtExpWizard = new TextBox();
            btnAddExpWarrior = new Button();
            btnAddExpArcher = new Button();
            btnAddExpWizard = new Button();
            SuspendLayout();
            // 
            // lblWarrior
            // 
            lblWarrior.AutoSize = true;
            lblWarrior.Location = new Point(14, 58);
            lblWarrior.Margin = new Padding(4, 0, 4, 0);
            lblWarrior.Name = "lblWarrior";
            lblWarrior.Size = new Size(46, 15);
            lblWarrior.TabIndex = 0;
            lblWarrior.Text = "Warrior";
            // 
            // lblArcher
            // 
            lblArcher.AutoSize = true;
            lblArcher.Location = new Point(14, 115);
            lblArcher.Margin = new Padding(4, 0, 4, 0);
            lblArcher.Name = "lblArcher";
            lblArcher.Size = new Size(42, 15);
            lblArcher.TabIndex = 1;
            lblArcher.Text = "Archer";
            // 
            // lblWizard
            // 
            lblWizard.AutoSize = true;
            lblWizard.Location = new Point(14, 173);
            lblWizard.Margin = new Padding(4, 0, 4, 0);
            lblWizard.Name = "lblWizard";
            lblWizard.Size = new Size(43, 15);
            lblWizard.TabIndex = 2;
            lblWizard.Text = "Wizard";
            // 
            // lblDragon
            // 
            lblDragon.AutoSize = true;
            lblDragon.Location = new Point(14, 231);
            lblDragon.Margin = new Padding(4, 0, 4, 0);
            lblDragon.Name = "lblDragon";
            lblDragon.Size = new Size(46, 15);
            lblDragon.TabIndex = 3;
            lblDragon.Text = "Dragon";
            // 
            // pbWarrior
            // 
            pbWarrior.Location = new Point(117, 58);
            pbWarrior.Margin = new Padding(4, 3, 4, 3);
            pbWarrior.Name = "pbWarrior";
            pbWarrior.Size = new Size(233, 27);
            pbWarrior.TabIndex = 4;
            pbWarrior.Click += pbWarrior_Click;
            // 
            // pbArcher
            // 
            pbArcher.Location = new Point(117, 115);
            pbArcher.Margin = new Padding(4, 3, 4, 3);
            pbArcher.Name = "pbArcher";
            pbArcher.Size = new Size(233, 27);
            pbArcher.TabIndex = 5;
            // 
            // pbWizard
            // 
            pbWizard.Location = new Point(117, 173);
            pbWizard.Margin = new Padding(4, 3, 4, 3);
            pbWizard.Name = "pbWizard";
            pbWizard.Size = new Size(233, 27);
            pbWizard.TabIndex = 6;
            // 
            // pbDragon
            // 
            pbDragon.Location = new Point(117, 231);
            pbDragon.Margin = new Padding(4, 3, 4, 3);
            pbDragon.Name = "pbDragon";
            pbDragon.Size = new Size(233, 27);
            pbDragon.TabIndex = 7;
            // 
            // lblPotions
            // 
            lblPotions.AutoSize = true;
            lblPotions.Location = new Point(14, 12);
            lblPotions.Margin = new Padding(4, 0, 4, 0);
            lblPotions.Name = "lblPotions";
            lblPotions.Size = new Size(103, 15);
            lblPotions.TabIndex = 8;
            lblPotions.Text = "Healing Potions: 3";
            // 
            // btnWarriorHeal
            // 
            btnWarriorHeal.Location = new Point(362, 58);
            btnWarriorHeal.Margin = new Padding(4, 3, 4, 3);
            btnWarriorHeal.Name = "btnWarriorHeal";
            btnWarriorHeal.Size = new Size(88, 27);
            btnWarriorHeal.TabIndex = 9;
            btnWarriorHeal.Text = "Heal";
            btnWarriorHeal.UseVisualStyleBackColor = true;
            btnWarriorHeal.Click += btnWarriorHeal_Click;
            // 
            // btnArcherHeal
            // 
            btnArcherHeal.Location = new Point(362, 115);
            btnArcherHeal.Margin = new Padding(4, 3, 4, 3);
            btnArcherHeal.Name = "btnArcherHeal";
            btnArcherHeal.Size = new Size(88, 27);
            btnArcherHeal.TabIndex = 10;
            btnArcherHeal.Text = "Heal";
            btnArcherHeal.UseVisualStyleBackColor = true;
            btnArcherHeal.Click += btnArcherHeal_Click;
            // 
            // btnWizardHeal
            // 
            btnWizardHeal.Location = new Point(362, 173);
            btnWizardHeal.Margin = new Padding(4, 3, 4, 3);
            btnWizardHeal.Name = "btnWizardHeal";
            btnWizardHeal.Size = new Size(88, 27);
            btnWizardHeal.TabIndex = 11;
            btnWizardHeal.Text = "Heal";
            btnWizardHeal.UseVisualStyleBackColor = true;
            btnWizardHeal.Click += btnWizardHeal_Click;
            // 
            // btnCombatRound
            // 
            btnCombatRound.Location = new Point(117, 288);
            btnCombatRound.Margin = new Padding(4, 3, 4, 3);
            btnCombatRound.Name = "btnCombatRound";
            btnCombatRound.Size = new Size(128, 35);
            btnCombatRound.TabIndex = 12;
            btnCombatRound.Text = "Combat Round";
            btnCombatRound.UseVisualStyleBackColor = true;
            btnCombatRound.Click += btnCombatRound_Click;
            // 
            // lblBattleResult
            // 
            lblBattleResult.AutoSize = true;
            lblBattleResult.Location = new Point(117, 335);
            lblBattleResult.Margin = new Padding(4, 0, 4, 0);
            lblBattleResult.Name = "lblBattleResult";
            lblBattleResult.Size = new Size(0, 15);
            lblBattleResult.TabIndex = 13;
            // 
            // btnSimulateBattle
            // 
            btnSimulateBattle.Location = new Point(257, 288);
            btnSimulateBattle.Margin = new Padding(4, 3, 4, 3);
            btnSimulateBattle.Name = "btnSimulateBattle";
            btnSimulateBattle.Size = new Size(128, 35);
            btnSimulateBattle.TabIndex = 14;
            btnSimulateBattle.Text = "Simulate Battle";
            btnSimulateBattle.UseVisualStyleBackColor = true;
            btnSimulateBattle.Click += btnSimulateBattle_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(397, 288);
            btnReset.Margin = new Padding(4, 3, 4, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(128, 35);
            btnReset.TabIndex = 15;
            btnReset.Text = "Reset Battle";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // txtExpWarrior
            // 
            txtExpWarrior.Location = new Point(455, 58);
            txtExpWarrior.Margin = new Padding(4, 3, 4, 3);
            txtExpWarrior.Name = "txtExpWarrior";
            txtExpWarrior.Size = new Size(69, 23);
            txtExpWarrior.TabIndex = 16;
            // 
            // txtExpArcher
            // 
            txtExpArcher.Location = new Point(455, 115);
            txtExpArcher.Margin = new Padding(4, 3, 4, 3);
            txtExpArcher.Name = "txtExpArcher";
            txtExpArcher.Size = new Size(69, 23);
            txtExpArcher.TabIndex = 17;
            // 
            // txtExpWizard
            // 
            txtExpWizard.Location = new Point(455, 173);
            txtExpWizard.Margin = new Padding(4, 3, 4, 3);
            txtExpWizard.Name = "txtExpWizard";
            txtExpWizard.Size = new Size(69, 23);
            txtExpWizard.TabIndex = 18;
            // 
            // btnAddExpWarrior
            // 
            btnAddExpWarrior.Location = new Point(537, 58);
            btnAddExpWarrior.Margin = new Padding(4, 3, 4, 3);
            btnAddExpWarrior.Name = "btnAddExpWarrior";
            btnAddExpWarrior.Size = new Size(88, 27);
            btnAddExpWarrior.TabIndex = 19;
            btnAddExpWarrior.Text = "Add EXP";
            btnAddExpWarrior.UseVisualStyleBackColor = true;
            btnAddExpWarrior.Click += btnAddExpWarrior_Click;
            // 
            // btnAddExpArcher
            // 
            btnAddExpArcher.Location = new Point(537, 115);
            btnAddExpArcher.Margin = new Padding(4, 3, 4, 3);
            btnAddExpArcher.Name = "btnAddExpArcher";
            btnAddExpArcher.Size = new Size(88, 27);
            btnAddExpArcher.TabIndex = 20;
            btnAddExpArcher.Text = "Add EXP";
            btnAddExpArcher.UseVisualStyleBackColor = true;
            btnAddExpArcher.Click += btnAddExpArcher_Click;
            // 
            // btnAddExpWizard
            // 
            btnAddExpWizard.Location = new Point(537, 173);
            btnAddExpWizard.Margin = new Padding(4, 3, 4, 3);
            btnAddExpWizard.Name = "btnAddExpWizard";
            btnAddExpWizard.Size = new Size(88, 27);
            btnAddExpWizard.TabIndex = 21;
            btnAddExpWizard.Text = "Add EXP";
            btnAddExpWizard.UseVisualStyleBackColor = true;
            btnAddExpWizard.Click += btnAddExpWizard_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 369);
            Controls.Add(btnAddExpWizard);
            Controls.Add(btnAddExpArcher);
            Controls.Add(btnAddExpWarrior);
            Controls.Add(txtExpWizard);
            Controls.Add(txtExpArcher);
            Controls.Add(txtExpWarrior);
            Controls.Add(btnReset);
            Controls.Add(btnSimulateBattle);
            Controls.Add(lblBattleResult);
            Controls.Add(btnCombatRound);
            Controls.Add(btnWizardHeal);
            Controls.Add(btnArcherHeal);
            Controls.Add(btnWarriorHeal);
            Controls.Add(lblPotions);
            Controls.Add(pbDragon);
            Controls.Add(pbWizard);
            Controls.Add(pbArcher);
            Controls.Add(pbWarrior);
            Controls.Add(lblDragon);
            Controls.Add(lblWizard);
            Controls.Add(lblArcher);
            Controls.Add(lblWarrior);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Dragon Hunt";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblWarrior;
        private System.Windows.Forms.Label lblArcher;
        private System.Windows.Forms.Label lblWizard;
        private System.Windows.Forms.Label lblDragon;
        private System.Windows.Forms.ProgressBar pbWarrior;
        private System.Windows.Forms.ProgressBar pbArcher;
        private System.Windows.Forms.ProgressBar pbWizard;
        private System.Windows.Forms.ProgressBar pbDragon;
        private System.Windows.Forms.Label lblPotions;
        private System.Windows.Forms.Button btnWarriorHeal;
        private System.Windows.Forms.Button btnArcherHeal;
        private System.Windows.Forms.Button btnWizardHeal;
        private System.Windows.Forms.Button btnCombatRound;
        private System.Windows.Forms.Label lblBattleResult;
        private System.Windows.Forms.Button btnSimulateBattle;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtExpWarrior;
        private System.Windows.Forms.TextBox txtExpArcher;
        private System.Windows.Forms.TextBox txtExpWizard;
        private System.Windows.Forms.Button btnAddExpWarrior;
        private System.Windows.Forms.Button btnAddExpArcher;
        private System.Windows.Forms.Button btnAddExpWizard;
    }
}