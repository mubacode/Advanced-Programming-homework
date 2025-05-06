using FinanceLibrary.Interfaces;
using FinanceLibrary.Models;
using System;
using System.Windows.Forms;

namespace FinanceTracker
{
    public partial class AddEntryForm : Form
    {
        private readonly bool _isIncome;
        private readonly Action<IFinancialEntity> _onEntryAdded;

        public AddEntryForm(bool isIncome, Action<IFinancialEntity> onEntryAdded)
        {
            InitializeComponent();
            _isIncome = isIncome;
            _onEntryAdded = onEntryAdded;
            Text = isIncome ? "Add Income" : "Add Expense";
            InitializeCategoryComboBox();
        }

        private void InitializeCategoryComboBox()
        {
            if (_isIncome)
            {
                foreach (IncomeCategory category in Enum.GetValues(typeof(IncomeCategory)))
                {
                    cmbCategory.Items.Add(category);
                }
            }
            else
            {
                foreach (ExpenseCategory category in Enum.GetValues(typeof(ExpenseCategory)))
                {
                    cmbCategory.Items.Add(category);
                }
            }
            cmbCategory.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || 
                !decimal.TryParse(txtAmount.Text, out decimal amount) || 
                amount <= 0)
            {
                MessageBox.Show("Please enter valid name and amount.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IFinancialEntity entry;
            if (_isIncome)
            {
                entry = new Income
                {
                    Name = txtName.Text,
                    Amount = amount,
                    Description = txtDescription.Text,
                    Category = (IncomeCategory)cmbCategory.SelectedItem
                };
            }
            else
            {
                entry = new Expense
                {
                    Name = txtName.Text,
                    Amount = amount,
                    Description = txtDescription.Text,
                    Category = (ExpenseCategory)cmbCategory.SelectedItem
                };
            }

            _onEntryAdded?.Invoke(entry);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
} 