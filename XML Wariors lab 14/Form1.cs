using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace XMLWarriors
{
    public partial class Form1 : Form
    {
        private BindingList<Warrior> _warriors;
        private string xmlFilePath = "guild.xml";

        public Form1()
        {
            InitializeComponent();
            _warriors = new BindingList<Warrior>();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Set up DataGridView
            dataGridView1.DataSource = _warriors;

            // Set up warrior ComboBox
            warriorComboBox.DataSource = _warriors;
            warriorComboBox.DisplayMember = "Name";

            // Set up gender ComboBox
            genderComboBox.DataSource = new[] { "male", "female" };

            // Set up property ComboBox for sorting
            propertyComboBox.Items.Clear();
            propertyComboBox.Items.AddRange(new[] { "Name", "Level", "HP" });
            propertyComboBox.SelectedIndex = 0;

            // Set default radio button
            ascendingRadioButton.Checked = true;

            // Wire up event handlers
            warriorComboBox.SelectedIndexChanged += WarriorComboBox_SelectedIndexChanged;
            addButton.Click += AddButton_Click;
            updateButton.Click += UpdateButton_Click;
            removeButton.Click += RemoveButton_Click;
            resetButton.Click += ResetButton_Click;
            sortButton.Click += SortButton_Click;
            saveToolStripMenuItem.Click += SaveWarriors;
            loadToolStripMenuItem.Click += LoadWarriorsFromXml;
            exitToolStripMenuItem.Click += (s, e) => Application.Exit();
        }

        private void LoadWarriorsFromXml(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Title = "Load Warriors Data";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XDocument doc = XDocument.Load(openFileDialog.FileName);
                        _warriors.Clear();
                        foreach (var w in doc.Root.Elements("warrior").Select(w => new Warrior
                        {
                            Name = w.Element("name").Value,
                            Level = int.Parse(w.Element("level").Value),
                            HP = int.Parse(w.Element("hp").Value),
                            Monster = w.Element("monster").Value,
                            Gender = w.Attribute("gender").Value
                        }))
                        {
                            _warriors.Add(w);
                        }
                        RefreshDataBindings();
                        MessageBox.Show("Warriors loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading warriors: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveWarriors(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.DefaultExt = "xml";
                saveFileDialog.Title = "Save Warriors Data";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var guild = new XElement("guild",
                            _warriors.Select(w => new XElement("warrior",
                                new XAttribute("gender", w.Gender),
                                new XElement("name", w.Name),
                                new XElement("level", w.Level),
                                new XElement("hp", w.HP),
                                new XElement("monster", w.Monster))));

                        guild.Save(saveFileDialog.FileName);
                        MessageBox.Show("Warriors saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving warriors: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void RefreshDataBindings()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _warriors;

            if (_warriors.Count == 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;
                warriorComboBox.DataSource = null;
            }
            else
            {
                warriorComboBox.DataSource = null;
                warriorComboBox.DataSource = _warriors;
                if (warriorComboBox.Items.Count > 0)
                    warriorComboBox.SelectedIndex = 0;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            if (_warriors.Any(w => w.Name == nameTextBox.Text))
            {
                MessageBox.Show("A warrior with this name already exists!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var warrior = new Warrior
            {
                Name = nameTextBox.Text,
                Gender = genderComboBox.SelectedItem.ToString(),
                Level = int.Parse(levelTextBox.Text),
                HP = int.Parse(hpTextBox.Text),
                Monster = monsterTextBox.Text
            };

            _warriors.Add(warrior);
            ResetButton_Click(null, null);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var selectedWarrior = warriorComboBox.SelectedItem as Warrior;
            if (selectedWarrior == null)
            {
                MessageBox.Show("Please select a warrior to update.", "Update Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInputs()) return;

            selectedWarrior.Name = nameTextBox.Text;
            selectedWarrior.Gender = genderComboBox.SelectedItem.ToString();
            selectedWarrior.Level = int.Parse(levelTextBox.Text);
            selectedWarrior.HP = int.Parse(hpTextBox.Text);
            selectedWarrior.Monster = monsterTextBox.Text;

            RefreshDataBindings();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var selectedWarrior = warriorComboBox.SelectedItem as Warrior;
            if (selectedWarrior == null)
            {
                MessageBox.Show("Please select a warrior to remove.", "Remove Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to remove {selectedWarrior.Name}?", 
                "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _warriors.Remove(selectedWarrior);
                RefreshDataBindings();
                ResetButton_Click(null, null);
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            levelTextBox.Text = "1";
            hpTextBox.Text = "100";
            monsterTextBox.Text = "";
            if (genderComboBox.Items.Count > 0)
                genderComboBox.SelectedIndex = 0;
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            if (propertyComboBox.SelectedItem == null) return;

            string propertyName = propertyComboBox.SelectedItem.ToString();
            List<Warrior> orderedWarriors;

            if (ascendingRadioButton.Checked)
            {
                switch (propertyName)
                {
                    case "Name":
                        orderedWarriors = _warriors.OrderBy(w => w.Name).ToList();
                        break;
                    case "Level":
                        orderedWarriors = _warriors.OrderBy(w => w.Level).ToList();
                        break;
                    case "HP":
                        orderedWarriors = _warriors.OrderBy(w => w.HP).ToList();
                        break;
                    default:
                        return;
                }
            }
            else
            {
                switch (propertyName)
                {
                    case "Name":
                        orderedWarriors = _warriors.OrderByDescending(w => w.Name).ToList();
                        break;
                    case "Level":
                        orderedWarriors = _warriors.OrderByDescending(w => w.Level).ToList();
                        break;
                    case "HP":
                        orderedWarriors = _warriors.OrderByDescending(w => w.HP).ToList();
                        break;
                    default:
                        return;
                }
            }

            _warriors.Clear();
            foreach (var warrior in orderedWarriors)
            {
                _warriors.Add(warrior);
            }
        }

        private void WarriorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedWarrior = warriorComboBox.SelectedItem as Warrior;
            if (selectedWarrior == null) return;

            nameTextBox.Text = selectedWarrior.Name;
            levelTextBox.Text = selectedWarrior.Level.ToString();
            hpTextBox.Text = selectedWarrior.HP.ToString();
            monsterTextBox.Text = selectedWarrior.Monster;
            genderComboBox.SelectedItem = selectedWarrior.Gender;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTextBox.Focus();
                return false;
            }

            if (!int.TryParse(levelTextBox.Text, out int level) || level < 1)
            {
                MessageBox.Show("Level must be a positive integer.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                levelTextBox.Focus();
                return false;
            }

            if (!int.TryParse(hpTextBox.Text, out int hp) || hp < 1)
            {
                MessageBox.Show("HP must be a positive integer.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                hpTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(monsterTextBox.Text))
            {
                MessageBox.Show("Monster name cannot be empty.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                monsterTextBox.Focus();
                return false;
            }

            return true;
        }
    }
} 