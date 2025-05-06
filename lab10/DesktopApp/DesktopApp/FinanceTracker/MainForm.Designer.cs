namespace FinanceTracker
{
    partial class MainForm
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

        private void InitializeComponent()
        {
            this.lblTotalIncome = new System.Windows.Forms.Label();
            this.lblTotalExpense = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddIncome = new System.Windows.Forms.Button();
            this.btnAddExpense = new System.Windows.Forms.Button();
            this.dataGridViewTransactions = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbTypeFilter = new System.Windows.Forms.ComboBox();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblTypeFilter = new System.Windows.Forms.Label();
            this.lblCategoryFilter = new System.Windows.Forms.Label();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.lstCategorySummary = new System.Windows.Forms.ListBox();
            this.lblCategorySummary = new System.Windows.Forms.Label();
            this.lblGoal = new System.Windows.Forms.Label();
            this.txtGoal = new System.Windows.Forms.TextBox();
            this.btnSetGoal = new System.Windows.Forms.Button();
            this.lblGoalProgress = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalIncome
            // 
            this.lblTotalIncome.AutoSize = true;
            this.lblTotalIncome.Location = new System.Drawing.Point(12, 40);
            this.lblTotalIncome.Name = "lblTotalIncome";
            this.lblTotalIncome.Size = new System.Drawing.Size(100, 15);
            this.lblTotalIncome.TabIndex = 0;
            this.lblTotalIncome.Text = "Total Income: $0.00";
            // 
            // lblTotalExpense
            // 
            this.lblTotalExpense.AutoSize = true;
            this.lblTotalExpense.Location = new System.Drawing.Point(12, 65);
            this.lblTotalExpense.Name = "lblTotalExpense";
            this.lblTotalExpense.Size = new System.Drawing.Size(100, 15);
            this.lblTotalExpense.TabIndex = 1;
            this.lblTotalExpense.Text = "Total Expense: $0.00";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(12, 90);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(100, 15);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "Balance: $0.00";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnAddIncome
            // 
            this.btnAddIncome.Location = new System.Drawing.Point(12, 120);
            this.btnAddIncome.Name = "btnAddIncome";
            this.btnAddIncome.Size = new System.Drawing.Size(100, 30);
            this.btnAddIncome.TabIndex = 4;
            this.btnAddIncome.Text = "Add Income";
            this.btnAddIncome.UseVisualStyleBackColor = true;
            this.btnAddIncome.Click += new System.EventHandler(this.btnAddIncome_Click);
            // 
            // btnAddExpense
            // 
            this.btnAddExpense.Location = new System.Drawing.Point(118, 120);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(100, 30);
            this.btnAddExpense.TabIndex = 5;
            this.btnAddExpense.Text = "Add Expense";
            this.btnAddExpense.UseVisualStyleBackColor = true;
            this.btnAddExpense.Click += new System.EventHandler(this.btnAddExpense_Click);
            // 
            // dataGridViewTransactions
            // 
            this.dataGridViewTransactions.Location = new System.Drawing.Point(12, 170);
            this.dataGridViewTransactions.Size = new System.Drawing.Size(600, 250);
            this.dataGridViewTransactions.ReadOnly = true;
            this.dataGridViewTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTransactions.MultiSelect = false;
            this.dataGridViewTransactions.AllowUserToAddRows = false;
            this.dataGridViewTransactions.AllowUserToDeleteRows = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Text = "Edit";
            this.btnEdit.Location = new System.Drawing.Point(620, 170);
            this.btnEdit.Size = new System.Drawing.Size(80, 30);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(710, 170);
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbTypeFilter
            // 
            this.cmbTypeFilter.Location = new System.Drawing.Point(300, 37);
            this.cmbTypeFilter.Size = new System.Drawing.Size(100, 23);
            this.cmbTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeFilter.Items.AddRange(new object[] { "All", "Income", "Expense" });
            this.cmbTypeFilter.SelectedIndex = 0;
            this.cmbTypeFilter.Name = "cmbTypeFilter";
            // 
            // cmbCategoryFilter
            // 
            this.cmbCategoryFilter.Location = new System.Drawing.Point(480, 37);
            this.cmbCategoryFilter.Size = new System.Drawing.Size(120, 23);
            this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(690, 37);
            this.dtpStart.Size = new System.Drawing.Size(100, 23);
            this.dtpStart.Name = "dtpStart";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(800, 37);
            this.dtpEnd.Size = new System.Drawing.Size(100, 23);
            this.dtpEnd.Name = "dtpEnd";
            // 
            // lblTypeFilter
            // 
            this.lblTypeFilter.Text = "Type:";
            this.lblTypeFilter.Location = new System.Drawing.Point(250, 40);
            // 
            // lblCategoryFilter
            // 
            this.lblCategoryFilter.Text = "Category:";
            this.lblCategoryFilter.Location = new System.Drawing.Point(410, 40);
            // 
            // lblDateRange
            // 
            this.lblDateRange.Text = "Date Range:";
            this.lblDateRange.Location = new System.Drawing.Point(610, 40);
            // 
            // lstCategorySummary
            // 
            this.lstCategorySummary.Location = new System.Drawing.Point(620, 240);
            this.lstCategorySummary.Size = new System.Drawing.Size(260, 100);
            this.lstCategorySummary.Name = "lstCategorySummary";
            // 
            // lblCategorySummary
            // 
            this.lblCategorySummary.Text = "Category Summary:";
            this.lblCategorySummary.Location = new System.Drawing.Point(620, 220);
            // 
            // lblGoal
            // 
            this.lblGoal.Text = "Savings Goal:";
            this.lblGoal.Location = new System.Drawing.Point(620, 350);
            // 
            // txtGoal
            // 
            this.txtGoal.Location = new System.Drawing.Point(710, 347);
            this.txtGoal.Size = new System.Drawing.Size(80, 23);
            this.txtGoal.Name = "txtGoal";
            // 
            // btnSetGoal
            // 
            this.btnSetGoal.Text = "Set Goal";
            this.btnSetGoal.Location = new System.Drawing.Point(800, 347);
            this.btnSetGoal.Size = new System.Drawing.Size(80, 23);
            this.btnSetGoal.Name = "btnSetGoal";
            this.btnSetGoal.Click += new System.EventHandler(this.btnSetGoal_Click);
            // 
            // lblGoalProgress
            // 
            this.lblGoalProgress.Text = "Progress: $0.00 / $0.00 (0%)";
            this.lblGoalProgress.Location = new System.Drawing.Point(620, 380);
            this.lblGoalProgress.Size = new System.Drawing.Size(260, 23);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblGoalProgress);
            this.Controls.Add(this.btnSetGoal);
            this.Controls.Add(this.txtGoal);
            this.Controls.Add(this.lblGoal);
            this.Controls.Add(this.lblCategorySummary);
            this.Controls.Add(this.lstCategorySummary);
            this.Controls.Add(this.lblDateRange);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.cmbCategoryFilter);
            this.Controls.Add(this.cmbTypeFilter);
            this.Controls.Add(this.lblTypeFilter);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dataGridViewTransactions);
            this.Controls.Add(this.btnAddExpense);
            this.Controls.Add(this.btnAddIncome);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblTotalExpense);
            this.Controls.Add(this.lblTotalIncome);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Personal Finance Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.Label lblTotalExpense;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnAddIncome;
        private System.Windows.Forms.Button btnAddExpense;
        private System.Windows.Forms.DataGridView dataGridViewTransactions;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbTypeFilter;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblTypeFilter;
        private System.Windows.Forms.Label lblCategoryFilter;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.ListBox lstCategorySummary;
        private System.Windows.Forms.Label lblCategorySummary;
        private System.Windows.Forms.Label lblGoal;
        private System.Windows.Forms.TextBox txtGoal;
        private System.Windows.Forms.Button btnSetGoal;
        private System.Windows.Forms.Label lblGoalProgress;
    }
} 