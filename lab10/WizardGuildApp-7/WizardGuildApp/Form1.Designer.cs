namespace WizardsGuild
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.resultsListBox = new System.Windows.Forms.ListBox();
            this.btnAllWizards = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMinLevel = new System.Windows.Forms.TextBox();
            this.btnExperiencedWizards = new System.Windows.Forms.Button();
            this.btnGetSpellsByType = new System.Windows.Forms.Button();
            this.cboSpellType = new System.Windows.Forms.ComboBox();
            this.btnTournamentReady = new System.Windows.Forms.Button();
            this.btnCheckUnconscious = new System.Windows.Forms.Button();
            this.btnSimulateBattle = new System.Windows.Forms.Button();
            this.btnRestAll = new System.Windows.Forms.Button();
            this.btnCastSpell = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // resultsListBox
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.HorizontalScrollbar = true;
            this.resultsListBox.ItemHeight = 16;
            this.resultsListBox.Location = new System.Drawing.Point(12, 12);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(600, 500);
            this.resultsListBox.TabIndex = 0;

            // btnAllWizards
            this.btnAllWizards.Location = new System.Drawing.Point(618, 12);
            this.btnAllWizards.Name = "btnAllWizards";
            this.btnAllWizards.Size = new System.Drawing.Size(170, 40);
            this.btnAllWizards.TabIndex = 1;
            this.btnAllWizards.Text = "1. All Wizards";
            this.btnAllWizards.UseVisualStyleBackColor = true;
            this.btnAllWizards.Click += new System.EventHandler(this.btnAllWizards_Click);

            // groupBox1
            this.groupBox1.Controls.Add(this.txtMinLevel);
            this.groupBox1.Controls.Add(this.btnExperiencedWizards);
            this.groupBox1.Location = new System.Drawing.Point(618, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2. Experienced Wizards";

            // txtMinLevel
            this.txtMinLevel.Location = new System.Drawing.Point(6, 21);
            this.txtMinLevel.Name = "txtMinLevel";
            this.txtMinLevel.Size = new System.Drawing.Size(158, 22);
            this.txtMinLevel.TabIndex = 1;
            this.txtMinLevel.Text = "10";

            // btnExperiencedWizards
            this.btnExperiencedWizards.Location = new System.Drawing.Point(6, 50);
            this.btnExperiencedWizards.Name = "btnExperiencedWizards";
            this.btnExperiencedWizards.Size = new System.Drawing.Size(158, 40);
            this.btnExperiencedWizards.TabIndex = 0;
            this.btnExperiencedWizards.Text = "Get";
            this.btnExperiencedWizards.UseVisualStyleBackColor = true;
            this.btnExperiencedWizards.Click += new System.EventHandler(this.btnExperiencedWizards_Click);

            // btnGetSpellsByType
            this.btnGetSpellsByType.Location = new System.Drawing.Point(618, 180);
            this.btnGetSpellsByType.Name = "btnGetSpellsByType";
            this.btnGetSpellsByType.Size = new System.Drawing.Size(170, 40);
            this.btnGetSpellsByType.TabIndex = 3;
            this.btnGetSpellsByType.Text = "9. Get Spells by Type";
            this.btnGetSpellsByType.UseVisualStyleBackColor = true;
            this.btnGetSpellsByType.Click += new System.EventHandler(this.btnGetSpellsByType_Click);

            // cboSpellType
            this.cboSpellType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpellType.FormattingEnabled = true;
            this.cboSpellType.Items.AddRange(new object[] {
                "Offensive",
                "Defensive",
                "Healing"});
            this.cboSpellType.Location = new System.Drawing.Point(618, 150);
            this.cboSpellType.Name = "cboSpellType";
            this.cboSpellType.Size = new System.Drawing.Size(170, 24);
            this.cboSpellType.TabIndex = 4;

            // btnTournamentReady
            this.btnTournamentReady.Location = new System.Drawing.Point(618, 240);
            this.btnTournamentReady.Name = "btnTournamentReady";
            this.btnTournamentReady.Size = new System.Drawing.Size(170, 40);
            this.btnTournamentReady.TabIndex = 5;
            this.btnTournamentReady.Text = "14. Tournament Ready?";
            this.btnTournamentReady.UseVisualStyleBackColor = true;
            this.btnTournamentReady.Click += new System.EventHandler(this.btnTournamentReady_Click);

            // btnCheckUnconscious
            this.btnCheckUnconscious.Location = new System.Drawing.Point(618, 290);
            this.btnCheckUnconscious.Name = "btnCheckUnconscious";
            this.btnCheckUnconscious.Size = new System.Drawing.Size(170, 40);
            this.btnCheckUnconscious.TabIndex = 6;
            this.btnCheckUnconscious.Text = "15. Unconscious Members?";
            this.btnCheckUnconscious.UseVisualStyleBackColor = true;
            this.btnCheckUnconscious.Click += new System.EventHandler(this.btnCheckUnconscious_Click);

            // btnSimulateBattle
            this.btnSimulateBattle.Location = new System.Drawing.Point(618, 340);
            this.btnSimulateBattle.Name = "btnSimulateBattle";
            this.btnSimulateBattle.Size = new System.Drawing.Size(170, 40);
            this.btnSimulateBattle.TabIndex = 7;
            this.btnSimulateBattle.Text = "Simulate Battle";
            this.btnSimulateBattle.UseVisualStyleBackColor = true;
            this.btnSimulateBattle.Click += new System.EventHandler(this.btnSimulateBattle_Click);

            // btnRestAll
            this.btnRestAll.Location = new System.Drawing.Point(618, 390);
            this.btnRestAll.Name = "btnRestAll";
            this.btnRestAll.Size = new System.Drawing.Size(170, 40);
            this.btnRestAll.TabIndex = 8;
            this.btnRestAll.Text = "Rest All Wizards";
            this.btnRestAll.UseVisualStyleBackColor = true;
            this.btnRestAll.Click += new System.EventHandler(this.btnRestAll_Click);

            // btnCastSpell
            this.btnCastSpell.Location = new System.Drawing.Point(618, 440);
            this.btnCastSpell.Name = "btnCastSpell";
            this.btnCastSpell.Size = new System.Drawing.Size(170, 40);
            this.btnCastSpell.TabIndex = 9;
            this.btnCastSpell.Text = "Cast First Spell";
            this.btnCastSpell.UseVisualStyleBackColor = true;
            this.btnCastSpell.Click += new System.EventHandler(this.btnCastSpell_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.btnCastSpell);
            this.Controls.Add(this.btnRestAll);
            this.Controls.Add(this.btnSimulateBattle);
            this.Controls.Add(this.btnCheckUnconscious);
            this.Controls.Add(this.btnTournamentReady);
            this.Controls.Add(this.cboSpellType);
            this.Controls.Add(this.btnGetSpellsByType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAllWizards);
            this.Controls.Add(this.resultsListBox);
            this.Name = "Form1";
            this.Text = "Wizards\' Guild Management";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox resultsListBox;
        private System.Windows.Forms.Button btnAllWizards;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMinLevel;
        private System.Windows.Forms.Button btnExperiencedWizards;
        private System.Windows.Forms.Button btnGetSpellsByType;
        private System.Windows.Forms.ComboBox cboSpellType;
        private System.Windows.Forms.Button btnTournamentReady;
        private System.Windows.Forms.Button btnCheckUnconscious;
        private System.Windows.Forms.Button btnSimulateBattle;
        private System.Windows.Forms.Button btnRestAll;
        private System.Windows.Forms.Button btnCastSpell;
    }
}