using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InClassPropertyChange.Models
{
    class User : IDataErrorInfo, INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private string _password = string.Empty;

        private string _nameError;
        private string _passwordError;

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

        public string this[string columnName]
        {

            get
            {             
                switch (columnName)
                {
                    case "Name":
                        NameError = "";
                        if (string.IsNullOrEmpty(Name))
                        {
                            NameError = "Name cannot be empty.";
                        }
                        if (Name.Length > 12)
                        {
                            NameError = "Name must be less than 12 char.";
                        }
                        return NameError;
                    case "Password":
                        PasswordError = "";
                        if (string.IsNullOrEmpty(Password))
                        {
                            PasswordError = "Password cannot be empty.";
                        }
                        if (Password.Length < 6 || Password.Length > 12)
                        {
                            PasswordError = "Password must be more > 6 < 12.";
                        }
                        return PasswordError;
                }
                return "";
            }
        }

        public string Error
        {
            get
            {
                return NameError;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public override string ToString()
        {
            return _name;
        }
    }
}
