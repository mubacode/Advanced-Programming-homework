using System;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace SharedLibrary
{
    /// <summary>
    /// Represents contact information for a person
    /// </summary>
    public class Contact : IDataErrorInfo, INotifyPropertyChanged
    {
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _phone = string.Empty;
        private string _email = string.Empty;
        private string _discord = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length > 50)
                        throw new ArgumentException("First name cannot be longer than 50 characters.");
                    if (!Regex.IsMatch(value, @"^[a-zA-Z\s-']+$"))
                        throw new ArgumentException("First name can only contain letters, spaces, hyphens, and apostrophes.");
                    
                    _firstName = value.Trim();
                }
                else
                {
                    _firstName = string.Empty;
                }
                OnPropertyChanged(nameof(FirstName));
            }
        }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length > 50)
                        throw new ArgumentException("Last name cannot be longer than 50 characters.");
                    if (!Regex.IsMatch(value, @"^[a-zA-Z\s-']+$"))
                        throw new ArgumentException("Last name can only contain letters, spaces, hyphens, and apostrophes.");
                    
                    _lastName = value.Trim();
                }
                else
                {
                    _lastName = string.Empty;
                }
                OnPropertyChanged(nameof(LastName));
            }
        }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string Phone
        {
            get => _phone;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    // Remove any non-digit characters for validation
                    string digitsOnly = Regex.Replace(value, @"[^\d]", "");
                    
                    if (digitsOnly.Length < 9 || digitsOnly.Length > 15)
                        throw new ArgumentException("Phone number must be between 9 and 15 digits.");
                    
                    // Format the phone number: +XX-XXX-XXX-XXX
                    _phone = string.Format("{0:+#-###-###-###}", long.Parse(digitsOnly));
                }
                else
                {
                    _phone = string.Empty;
                }
                OnPropertyChanged(nameof(Phone));
            }
        }

        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    // RFC 5322 email validation
                    string emailPattern = @"^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$";
                    
                    if (!Regex.IsMatch(value, emailPattern, RegexOptions.IgnoreCase))
                        throw new ArgumentException("Invalid email format.");
                    
                    _email = value.Trim().ToLower();
                }
                else
                {
                    _email = string.Empty;
                }
                OnPropertyChanged(nameof(Email));
            }
        }

        /// <summary>
        /// Gets or sets the Discord username
        /// </summary>
        public string Discord
        {
            get => _discord;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    // Discord username format: username#0000 or just username
                    if (!Regex.IsMatch(value, @"^[a-zA-Z0-9_]{2,32}(#\d{4})?$"))
                        throw new ArgumentException("Invalid Discord username format. Must be 2-32 characters (letters, numbers, underscores) with optional #0000.");
                }
                
                _discord = value?.Trim() ?? string.Empty;
                OnPropertyChanged(nameof(Discord));
            }
        }

        /// <summary>
        /// Initializes a new instance of the Contact class
        /// </summary>
        public Contact()
        {
            // Initialize with empty strings
            _firstName = string.Empty;
            _lastName = string.Empty;
            _phone = string.Empty;
            _email = string.Empty;
            _discord = string.Empty;
        }

        // IDataErrorInfo implementation for DataGridView validation
        public string Error => null;

        public string this[string columnName] => null; // Removing validation to allow empty values

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 