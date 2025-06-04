namespace XMLWarriors
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.warriorComboBox = new System.Windows.Forms.ComboBox();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.propertyComboBox = new System.Windows.Forms.ComboBox();
            this.ascendingRadioButton = new System.Windows.Forms.RadioButton();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.levelTextBox = new System.Windows.Forms.TextBox();
            this.hpTextBox = new System.Windows.Forms.TextBox();
            this.monsterTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.descendingRadioButton = new System.Windows.Forms.RadioButton();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblHP = new System.Windows.Forms.Label();
            this.lblMonster = new System.Windows.Forms.Label();
            this.lblWarrior = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblSortBy = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // MenuStrip
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            // File Menu
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.saveToolStripMenuItem,
                this.loadToolStripMenuItem,
                this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";

            // Save Menu Item
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";

            // Load Menu Item
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";

            // Exit Menu Item
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";

            // DataGridView
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView1.Location = new System.Drawing.Point(10, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(464, 120);
            this.dataGridView1.TabIndex = 0;

            // Top Warrior ComboBox
            this.warriorComboBox.FormattingEnabled = true;
            this.warriorComboBox.Location = new System.Drawing.Point(10, 160);
            this.warriorComboBox.Name = "warriorComboBox";
            this.warriorComboBox.Size = new System.Drawing.Size(200, 21);
            this.warriorComboBox.TabIndex = 1;

            // Left side labels
            void ConfigureLabel(System.Windows.Forms.Label lbl, int y, string text)
            {
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(10, y);
                lbl.Text = text;
            }

            // Warrior section
            ConfigureLabel(this.lblWarrior, 200, "Warrior");
            ConfigureLabel(this.lblName, 220, "Name");
            ConfigureLabel(this.lblGender, 245, "Gender");
            ConfigureLabel(this.lblLevel, 270, "Level");
            ConfigureLabel(this.lblHP, 295, "HP");
            ConfigureLabel(this.lblMonster, 320, "Monster");

            // Left side inputs
            void ConfigureTextBox(System.Windows.Forms.TextBox txt, int y)
            {
                txt.Location = new System.Drawing.Point(70, y);
                txt.Size = new System.Drawing.Size(120, 20);
            }

            ConfigureTextBox(this.nameTextBox, 220);
            
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Location = new System.Drawing.Point(70, 245);
            this.genderComboBox.Size = new System.Drawing.Size(120, 21);

            ConfigureTextBox(this.levelTextBox, 270);
            ConfigureTextBox(this.hpTextBox, 295);
            ConfigureTextBox(this.monsterTextBox, 320);

            // Right side controls
            // Sort section
            ConfigureLabel(this.lblSortBy, 200, "Sort by");
            
            this.propertyComboBox.FormattingEnabled = true;
            this.propertyComboBox.Location = new System.Drawing.Point(260, 220);
            this.propertyComboBox.Size = new System.Drawing.Size(120, 21);

            this.ascendingRadioButton.AutoSize = true;
            this.ascendingRadioButton.Checked = true;
            this.ascendingRadioButton.Location = new System.Drawing.Point(260, 250);
            this.ascendingRadioButton.Text = "ascending";

            this.descendingRadioButton.AutoSize = true;
            this.descendingRadioButton.Location = new System.Drawing.Point(340, 250);
            this.descendingRadioButton.Text = "descending";

            // Buttons
            void ConfigureButton(System.Windows.Forms.Button btn, int y, string text)
            {
                btn.Location = new System.Drawing.Point(200, y);
                btn.Size = new System.Drawing.Size(50, 23);
                btn.Text = text;
            }

            ConfigureButton(this.addButton, 220, "Add");
            ConfigureButton(this.updateButton, 250, "Update");
            ConfigureButton(this.removeButton, 280, "Remove");
            ConfigureButton(this.resetButton, 310, "Reset");

            this.sortButton.Location = new System.Drawing.Point(330, 280);
            this.sortButton.Size = new System.Drawing.Size(50, 23);
            this.sortButton.Text = "Sort";

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.warriorComboBox);
            this.Controls.Add(this.genderComboBox);
            this.Controls.Add(this.propertyComboBox);
            this.Controls.Add(this.ascendingRadioButton);
            this.Controls.Add(this.descendingRadioButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.levelTextBox);
            this.Controls.Add(this.hpTextBox);
            this.Controls.Add(this.monsterTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.lblWarrior);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblHP);
            this.Controls.Add(this.lblMonster);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblSortBy);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Form1";
            this.Text = "Warriors Guild";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox warriorComboBox;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.ComboBox propertyComboBox;
        private System.Windows.Forms.RadioButton ascendingRadioButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox levelTextBox;
        private System.Windows.Forms.TextBox hpTextBox;
        private System.Windows.Forms.TextBox monsterTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.RadioButton descendingRadioButton;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblHP;
        private System.Windows.Forms.Label lblMonster;
        private System.Windows.Forms.Label lblWarrior;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblSortBy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
} 