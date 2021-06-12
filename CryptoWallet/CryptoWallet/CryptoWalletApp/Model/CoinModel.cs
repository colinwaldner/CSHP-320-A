using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace CryptoWalletApp.Model
{
    public class CoinModel : IDataErrorInfo, INotifyPropertyChanged
    {
        #region Fields
        private string _name { get; set; }
        private string _ticker { get; set; }
        private decimal _purchasePrice { get; set; }
        private decimal _quantity { get; set; }
        private decimal _currentPrice { get; set; }
        #endregion
        #region Error Message Fields
        private string  _error_name { get; set; }
        private string  _error_ticker { get; set; }
        private string  _error_purchasePrice { get; set; }
        private string  _error_quantity { get; set; }
        private string  _error_currentPrice { get; set; }
        #endregion
        #region Properties
        public int Id { get; set; }
        public string Name 
        {
            get { return _name; }
            set { if (_name != value) { _name = value; OnPropertyChanged("Name"); } } 
        }
        public string Ticker
        {
            get { return _ticker; }
            set { if (_ticker != value) { _ticker = value.ToUpper(); OnPropertyChanged("Ticker"); } }
        }
        public bool Favourite { get; set; }
        public decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set 
            { 
                if (_purchasePrice != value) 
                { 
                    _purchasePrice = value; 
                    OnPropertyChanged("PurchasePrice"); 
                }
            }
        }
        public DateTime PurchaseDate { get; set; }
        public decimal Quantity
        {
            get { return _quantity; }
            set { if (_quantity != value) { _quantity = value; OnPropertyChanged("Quantity"); } }
        }
        public decimal CurrentPrice
        {
            get { return _currentPrice; }
            set { if (_currentPrice != value) { _currentPrice = value; OnPropertyChanged("CurrentPrice"); } }
        }
        public DateTime CurrentPriceDate { get; set; }
        #endregion
        #region Error Message Properties
        public string Error_Name
        {
            get { return _error_name; }
            set { if (_error_name != value) { _error_name = value; OnPropertyChanged("Error_Name"); } }
        }
        public string Error_Ticker
        {
            get { return _error_ticker; }
            set { if (_error_ticker != value) { _error_ticker = value; OnPropertyChanged("Error_Ticker"); } }
        }
        public string Error_PurchasePrice
        {
            get { return _error_purchasePrice; }
            set { if (_error_purchasePrice != value) { _error_purchasePrice = value; OnPropertyChanged("Error_PurchasePrice"); } }
        }
        public string Error_Quantity
        {
            get { return _error_quantity; }
            set { if (_error_quantity != value) { _error_quantity = value; OnPropertyChanged("Error_Quantity"); } }
        }
        public string Error_CurrentPrice
        {
            get { return _error_currentPrice; }
            set { if (_error_currentPrice != value) { _error_currentPrice = value; OnPropertyChanged("Error_CurrentPrice"); } }
        }
        #endregion
        #region Calculated Fields
        public decimal PurchaseValue 
        { 
            get
            {
                return PurchasePrice * Quantity;
            }            
        }
        public decimal CurrentValue
        {
            get
            {
                return CurrentPrice * Quantity;
            }
        }
        public decimal GainLoss
        {
            get
            {
                return (CurrentPrice - PurchasePrice) * Quantity;
            }
        }
        #endregion

        #region Mapper & Misc Methods
        private static readonly MapperConfiguration
            config = new MapperConfiguration(cfg => cfg.CreateMap<CryptoWalletRepository.CoinModel, CoinModel>()
            .ReverseMap());
        private static IMapper mapper = config.CreateMapper();

        public CryptoWalletRepository.CoinModel ToRepositoryModel()
        {
            var repositoryModel = mapper.Map<CryptoWalletRepository.CoinModel>(this);

            return repositoryModel;
        }

        public static CoinModel ToModel(CryptoWalletRepository.CoinModel repositoryModel)
        {
            var contactModel = mapper.Map<CoinModel>(repositoryModel);

            return contactModel;
        }

        public CoinModel Clone()
        {
            return (CoinModel)this.MemberwiseClone();
        }
        #endregion

        #region IDataError & INotifyProperty Methods
        public string Error => throw new NotImplementedException();

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
                    return Error_Name;

                    case "Ticker":
                        Error_Ticker = "";
                        if (string.IsNullOrEmpty(Ticker))
                        {
                            Error_Ticker = "Ticker cannot be empty.";
                        }
                        return Error_Ticker;

                    case "PurchasePrice":
                        Error_PurchasePrice = "";
                        if (PurchasePrice == 0)
                        {
                            Error_PurchasePrice = "PurchasePrice cannot be 0.";
                        }
                        return Error_PurchasePrice;

                    case "Quantity":
                        Error_Quantity = "";
                        if (Quantity == 0)
                        {
                            Error_Quantity = "Quantity cannot be 0.";
                        }
                        return Error_Quantity;

                    case "CurrentPrice":
                        Error_CurrentPrice = "";
                        if (CurrentPrice == 0)
                        {
                            Error_CurrentPrice = "CurrentPrice cannot be 0.";
                        }
                        return Error_CurrentPrice;
                }
                return "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
