using FinanceLibrary.Models;
using FinanceLibrary.Services;
using FinanceLibrary.Interfaces;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace FinanceTracker
{
    public partial class MainForm : Form
    {
        private readonly FinancialService<Income> _incomeService;
        private readonly FinancialService<Expense> _expenseService;
        private readonly DataPersistenceService _dataPersistenceService;

        private List<IFinancialEntity> _allTransactions = new List<IFinancialEntity>();
        private decimal _goalAmount = 0;

        public MainForm()
        {
            InitializeComponent();
            _incomeService = new FinancialService<Income>();
            _expenseService = new FinancialService<Expense>();
            _dataPersistenceService = new DataPersistenceService();
            LoadDataAsync();
            WireUpFilterEvents();
        }

        private void WireUpFilterEvents()
        {
            cmbTypeFilter.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbCategoryFilter.SelectedIndexChanged += (s, e) => ApplyFilters();
            dtpStart.ValueChanged += (s, e) => ApplyFilters();
            dtpEnd.ValueChanged += (s, e) => ApplyFilters();
        }

        private async void LoadDataAsync()
        {
            try
            {
                var incomes = (await _dataPersistenceService.LoadDataAsync<Income>("incomes.json")).ToList();
                var expenses = (await _dataPersistenceService.LoadDataAsync<Expense>("expenses.json")).ToList();

                _allTransactions = new List<IFinancialEntity>();
                foreach (var income in incomes)
                {
                    await _incomeService.AddAsync(income);
                    _allTransactions.Add(income);
                }
                foreach (var expense in expenses)
                {
                    await _expenseService.AddAsync(expense);
                    _allTransactions.Add(expense);
                }

                UpdateFinancialSummary();
                PopulateCategoryFilter();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateCategoryFilter()
        {
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All");
            var categories = _allTransactions
                .Select(t => t is Income i ? i.Category.ToString() : ((Expense)t).Category.ToString())
                .Distinct()
                .OrderBy(c => c)
                .ToList();
            foreach (var cat in categories)
                cmbCategoryFilter.Items.Add(cat);
            cmbCategoryFilter.SelectedIndex = 0;
        }

        private void ApplyFilters()
        {
            var filtered = _allTransactions.AsEnumerable();
            // Type filter
            if (cmbTypeFilter.SelectedItem?.ToString() == "Income")
                filtered = filtered.Where(t => t is Income);
            else if (cmbTypeFilter.SelectedItem?.ToString() == "Expense")
                filtered = filtered.Where(t => t is Expense);
            // Category filter
            if (cmbCategoryFilter.SelectedItem?.ToString() != "All")
                filtered = filtered.Where(t => (t is Income i && i.Category.ToString() == cmbCategoryFilter.SelectedItem.ToString()) ||
                                               (t is Expense e && e.Category.ToString() == cmbCategoryFilter.SelectedItem.ToString()));
            // Date filter
            filtered = filtered.Where(t => t.Date.Date >= dtpStart.Value.Date && t.Date.Date <= dtpEnd.Value.Date);
            // Bind to DataGridView
            dataGridViewTransactions.DataSource = filtered
                .Select(t => new
                {
                    Type = t is Income ? "Income" : "Expense",
                    t.Name,
                    t.Amount,
                    t.Date,
                    Category = t is Income i ? i.Category.ToString() : ((Expense)t).Category.ToString(),
                    t.Description,
                    t.Id
                })
                .OrderByDescending(t => t.Date)
                .ToList();
            dataGridViewTransactions.Columns["Id"].Visible = false;
            UpdateCategorySummary(filtered);
            UpdateGoalProgress();
        }

        private void UpdateCategorySummary(IEnumerable<IFinancialEntity> filtered)
        {
            var summary = filtered
                .GroupBy(t => t is Income i ? i.Category.ToString() : ((Expense)t).Category.ToString())
                .Select(g => new { Category = g.Key, Total = g.Sum(t => t.Amount) })
                .OrderByDescending(g => g.Total)
                .ToList();
            lstCategorySummary.Items.Clear();
            foreach (var item in summary)
                lstCategorySummary.Items.Add($"{item.Category}: {item.Total:C}");
        }

        private void UpdateGoalProgress()
        {
            var balance = _allTransactions.OfType<Income>().Sum(i => i.Amount) - _allTransactions.OfType<Expense>().Sum(e => e.Amount);
            var percent = _goalAmount > 0 ? (balance / _goalAmount) * 100 : 0;
            lblGoalProgress.Text = $"Progress: {balance:C} / {_goalAmount:C} ({percent:0}%)";
        }

        private async void UpdateFinancialSummary()
        {
            try
            {
                var totalIncome = await _incomeService.GetTotalAmountAsync();
                var totalExpense = await _expenseService.GetTotalAmountAsync();
                var balance = totalIncome - totalExpense;

                lblTotalIncome.Text = $"Total Income: {totalIncome:C}";
                lblTotalExpense.Text = $"Total Expense: {totalExpense:C}";
                lblBalance.Text = $"Balance: {balance:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating summary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SaveDataAsync()
        {
            try
            {
                var incomes = await _incomeService.GetAllAsync();
                var expenses = await _expenseService.GetAllAsync();

                await _dataPersistenceService.SaveDataAsync("incomes.json", incomes);
                await _dataPersistenceService.SaveDataAsync("expenses.json", expenses);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDataAsync();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDataAsync();
            MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDataAsync();
            Application.Exit();
        }

        private async void btnAddIncome_Click(object sender, EventArgs e)
        {
            using (var form = new AddEntryForm(true, async (entry) =>
            {
                try
                {
                    await _incomeService.AddAsync((Income)entry);
                    UpdateFinancialSummary();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding income: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }))
            {
                form.ShowDialog(this);
            }
        }

        private async void btnAddExpense_Click(object sender, EventArgs e)
        {
            using (var form = new AddEntryForm(false, async (entry) =>
            {
                try
                {
                    await _expenseService.AddAsync((Expense)entry);
                    UpdateFinancialSummary();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding expense: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }))
            {
                form.ShowDialog(this);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // TODO: Implement edit logic
            MessageBox.Show("Edit feature coming soon.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // TODO: Implement delete logic
            MessageBox.Show("Delete feature coming soon.");
        }

        private void btnSetGoal_Click(object sender, EventArgs e)
        {
            // TODO: Implement set goal logic
            MessageBox.Show("Set goal feature coming soon.");
        }
    }
} 