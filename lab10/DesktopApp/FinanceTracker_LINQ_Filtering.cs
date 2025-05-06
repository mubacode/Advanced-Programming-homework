// MainForm.cs - LINQ Filtering and Grouping Example
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