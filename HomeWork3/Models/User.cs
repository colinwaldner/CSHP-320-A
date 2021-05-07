using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HomeWork3.Models
{
    class User : IDataErrorInfo, INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private string _nameError;

        // Exercise 1 - add a passwordErro for password validation
        private string _password = string.Empty;
        private string _passwordError;

        // Add ToString method
        public override string ToString()
        {
            return _name;
        }

        public string NameError
        {
            get
            {
                return _nameError;
            }
            set
            {
                if (_nameError != value)
                {
                    _nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        // Exercise 1 - Need a PasswordError Property
        public string PasswordError
        {
            get
            {
                return _passwordError;
            }

            set
            {
                if (_passwordError != value)
                {
                    _passwordError = value;
                    OnPropertyChanged("PasswordError");
                }
            }
        }


        // IDataErrorInfo interface
        public string Error
        {
            get
            {
                return NameError;
            }
        }

        // IDataErrorInfo interface
        // Called when ValidatesOnDataErrors=True
        public string this[string columnName]
        {
            get
            {
                NameError = "";
                switch (columnName)
                {
                    case "Name":
                        {
                            NameError = "";
                            if (string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty.";
                            }
                            if (Name.Length > 12)
                            {
                                NameError = "Name cannot be longer than 12 characters.";
                            }

                            return NameError;
                        }
                    case "Password": // Exercise 1 - password validation message lable
                        {
                            PasswordError = "";
                            if (string.IsNullOrEmpty(Password))
                            {
                                PasswordError = "Password cannot be empty.";
                            }
                            if (Password.Length > 12)
                            {
                                PasswordError = "Password cannot be longer than 12 characters.";
                            }

                            return PasswordError;

                        }

                } // end of switch statement

                return null;

            } // end of get
        }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // when a trigger happens
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
