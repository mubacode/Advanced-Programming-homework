using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using SharedLibrary;

namespace ContactManager
{
    public partial class Form1 : Form
    {
        private List<Contact> _contacts;
        private readonly string _pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
        private readonly List<IPluginable> _plugins = new();

        public Form1()
        {
            InitializeComponent();
            _contacts = new List<Contact>();
            
            // Set up DataGridView properties
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataError += DataGridView1_DataError;
            dataGridView1.CellValidating += DataGridView1_CellValidating;

            // Create columns manually
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "FirstName",
                    DataPropertyName = "FirstName",
                    HeaderText = "First Name",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "LastName",
                    DataPropertyName = "LastName",
                    HeaderText = "Last Name",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Phone",
                    DataPropertyName = "Phone",
                    HeaderText = "Phone",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Email",
                    DataPropertyName = "Email",
                    HeaderText = "Email",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 150
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Discord",
                    DataPropertyName = "Discord",
                    HeaderText = "Discord",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    FillWeight = 100
                }
            );
            
            // Set up data binding
            contactBindingSource.DataSource = _contacts;
            dataGridView1.DataSource = contactBindingSource;
        }

        private void DataGridView1_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is ArgumentException argEx)
            {
                MessageBox.Show(argEx.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.ThrowException = false;
                // Keep the cell in edit mode
                dataGridView1.BeginEdit(true);
            }
        }

        private void DataGridView1_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.Rows[e.RowIndex].IsNewRow) return;

            try
            {
                var columnName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
                var newValue = e.FormattedValue?.ToString() ?? string.Empty;

                // Only validate non-empty values
                if (!string.IsNullOrWhiteSpace(newValue))
                {
                    // Create a temporary contact to test the value
                    var testContact = new Contact();
                    switch (columnName)
                    {
                        case nameof(Contact.FirstName):
                            testContact.FirstName = newValue;
                            break;
                        case nameof(Contact.LastName):
                            testContact.LastName = newValue;
                            break;
                        case nameof(Contact.Phone):
                            testContact.Phone = newValue;
                            break;
                        case nameof(Contact.Email):
                            testContact.Email = newValue;
                            break;
                        case nameof(Contact.Discord):
                            testContact.Discord = newValue;
                            break;
                    }
                }
            }
            catch (ArgumentException ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Keep the existing value
                var currentValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (currentValue != null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = currentValue;
                }
                // Keep the cell in edit mode
                dataGridView1.BeginEdit(true);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_pluginsPath);
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                // załadowanie pakietu i podpięcie funkcjonalności wtycznek
                Assembly assembly = Assembly.LoadFrom(file.FullName);
                
                var types = assembly.GetTypes()
                    .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == nameof(IPluginable)));

                foreach (Type type in types)
                {
                    object? obj = Activator.CreateInstance(type);
                    if (obj != null)
                    {
                        IPluginable plugin = (IPluginable)obj;
                        _plugins.Add(plugin);
                        
                        // Add menu items for the plugin
                        var saveItem = new ToolStripMenuItem(plugin.Format);
                        saveItem.Click += (s, e) =>
                        {
                            // wybranie pliku, w którym mają być zapisane kontakty
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.ShowDialog();
                            
                            // wywołanie metody z pluginu realizującej zapisanie
                            plugin.Save(_contacts, saveFileDialog.FileName);
                        };
                        saveToToolStripMenuItem.DropDownItems.Add(saveItem);

                        var loadItem = new ToolStripMenuItem(plugin.Format);
                        loadItem.Click += (s, e) =>
                        {
                            // wybranie pliku, z którego mają zostać wczytane kontakty
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            openFileDialog.ShowDialog();
                            
                            // wywołanie metody pluginu do wczytywania kontaktów
                            var loadedContacts = plugin.Load(openFileDialog.FileName);
                            
                            // resetowanie pola z kontaktami i bindingu
                            _contacts.Clear();
                            _contacts.AddRange(loadedContacts);
                            contactBindingSource.ResetBindings(false);
                        };
                        loadFromToolStripMenuItem.DropDownItems.Add(loadItem);

                        // Add help menu item for plugin info
                        var infoItem = new ToolStripMenuItem(plugin.Format);
                        infoItem.Click += (obj, e) =>
                        {
                            var attrObj = type.GetCustomAttribute(typeof(InfoAttribute));
                            if (attrObj != null)
                            {
                                var attr = attrObj as InfoAttribute;
                                if (attr != null)
                                {
                                    MessageBox.Show(
                                        $"Plugin Information:\n\n" +
                                        $"Format: {plugin.Format}\n" +
                                        $"Author: {attr.Author}\n" +
                                        $"Type: {type.FullName}\n" +
                                        $"Assembly: {type.Assembly.GetName().Name}",
                                        $"About {plugin.Format} Plugin",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information
                                    );
                                }
                            }
                            else
                            {
                                MessageBox.Show(
                                    $"Plugin Information:\n\n" +
                                    $"Format: {plugin.Format}\n" +
                                    $"Type: {type.FullName}\n" +
                                    $"Assembly: {type.Assembly.GetName().Name}",
                                    $"About {plugin.Format} Plugin",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                        };
                        helpToolStripMenuItem.DropDownItems.Add(infoItem);
                    }
                }
            }
        }

        private void saveXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            
            using (Stream stream = File.Create(saveFileDialog.FileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
                serializer.Serialize(stream, _contacts);
            }
        }

        private void loadXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            
            using (Stream stream = File.OpenRead(openFileDialog.FileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
                var loadedContacts = serializer.Deserialize(stream) as List<Contact>;
                if (loadedContacts != null)
                {
                    _contacts.Clear();
                    _contacts.AddRange(loadedContacts);
                    contactBindingSource.ResetBindings(false);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
} 