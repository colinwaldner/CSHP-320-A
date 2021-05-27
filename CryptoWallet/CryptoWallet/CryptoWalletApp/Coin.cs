using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace CryptoWalletApp
{
    class Coin : IDataErrorInfo, INotifyPropertyChanged
    {
        private int _id { get; set; }
        private bool _favourite { get; set; }
        private string _name { get; set; }
        private string _ticker { get; set; }
        private double _purchasePrice { get; set; }
        private double _quantity { get; set; }
        private DateTime _purchaseDate { get; set; }
        private double _currentPrice { get; set; }
        private DateTime _currentPriceDate { get; set; }

        private string _error_name;
        private string _error_ticker;
        private string _error_purchasePrice;
        private string _error_quantity;
        private string _error_purchaseDate;

        public int Id { get { return _id; } set { _id = value; } }
        public bool Favourite { get { return _favourite; } set { _favourite = value; OnPropertyChanged("Favourite"); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public string Ticker { get { return _ticker; } set { _ticker = value; OnPropertyChanged("Ticker"); } }
        public double PurchasePrice { get { return _purchasePrice; } set { _purchasePrice = value; OnPropertyChanged("PurchasePrice"); } }
        public double Quantity { get { return _quantity; } set { _quantity = value; OnPropertyChanged("Quantity"); } }
        public DateTime PurchaseDate { get { return _purchaseDate; } set { _purchaseDate = value; OnPropertyChanged("PurchaseDate"); } }
        public double CurrentPrice { get { return _currentPrice; } set { _currentPrice = value; OnPropertyChanged("CurrentPrice"); } }
        public DateTime CurrentPriceDate { get { return _currentPriceDate; } set { _currentPriceDate = value; OnPropertyChanged("CurrentPriceDate"); } }

        public string Error_Name { get { return _error_name; } set { _error_name = value; OnPropertyChanged("Error_Name"); } }
        public string Error_Ticker { get { return _error_ticker; } set { _error_ticker = value; OnPropertyChanged("Error_Ticker"); } }
        public string Error_PurchasePrice { get { return _error_purchasePrice; } set { _error_purchasePrice = value; OnPropertyChanged("Error_PurchasePrice"); } }
        public string Error_Quantity { get { return _error_quantity; } set { _error_quantity = value; OnPropertyChanged("Error_Quantity"); } }
        public string Error_PurchaseDate { get { return _error_purchaseDate; } set { _error_purchaseDate = value; OnPropertyChanged("Error_PurchaseDate"); } }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        Error_Name = "";
                        if (string.IsNullOrEmpty(Name))
                        {
                            Error_Name = "Name cannot be empty.";
                        }
                        else if (Name.Length > 10)
                        {
                            Error_Name = "Name cannot be greater than 10.";
                        }
                    return Error_Name;
                    case "Ticker":
                        Error_Ticker = "";
                        if (string.IsNullOrEmpty(Ticker))
                        {
                            Error_Ticker = "Ticker cannot be empty.";
                        }
                        else if (!Ticker.All(c => char.IsUpper(c)))
                        {
                            Error_Ticker = "Ticker must be all capital letters.";
                        }
                        else if (Ticker.Length < 3)
                        {
                            Error_Ticker = "Ticker must be at least 3 characters.";
                        }
                    return Error_Name;

                }
                return "";
            }
        }

        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
