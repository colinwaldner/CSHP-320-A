using System;
using AutoMapper;

namespace CryptoWalletApp.Model
{
    public class CoinModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public bool Favourite { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime CurrentPriceDate { get; set; }

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
                return CurrentPrice - PurchasePrice;
            }
        }

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
    }
}
