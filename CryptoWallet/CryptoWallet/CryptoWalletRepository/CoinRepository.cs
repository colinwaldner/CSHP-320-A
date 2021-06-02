using CryptoWalletDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoWalletRepository
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
    }

    public class CoinRepository
    {
        public CoinModel Add(CoinModel coinModel)
        {
            var coinDb = ToDbModel(coinModel);

            DatabaseManager.Instance.Coin.Add(coinDb);
            DatabaseManager.Instance.SaveChanges();

            coinModel = new CoinModel
            {
                Id = coinDb.Id,
                Name = coinDb.Name,
                Ticker = coinDb.Ticker,
                Favourite = coinDb.Favourite,
                PurchasePrice = coinDb.PurchasePrice,
                PurchaseDate = coinDb.PurchaseDate,
                Quantity = coinDb.Quantity,
                CurrentPrice = coinDb.CurrentPrice,
                CurrentPriceDate = coinDb.CurrentPriceDate
            };
            return coinModel;
        }

        public List<CoinModel> GetAll()
        {
            // Use .Select() to map the database coins to CoinModel
            var items = DatabaseManager.Instance.Coin
              .Select(t => new CoinModel
              {
                  Id = t.Id,
                  Name = t.Name,
                  Ticker = t.Ticker,
                  Favourite = t.Favourite,
                  PurchasePrice = t.PurchasePrice,
                  PurchaseDate = t.PurchaseDate,
                  Quantity = t.Quantity,
                  CurrentPrice = t.CurrentPrice,
                  CurrentPriceDate = t.CurrentPriceDate
              }).ToList();

            return items;
        }

        public bool Update(CoinModel coinModel)
        {
            var original = DatabaseManager.Instance.Coin.Find(coinModel.Id);
            CheckCurrentPriceChange(original, coinModel);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(coinModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int coinId)
        {
            var items = DatabaseManager.Instance.Coin
                                .Where(t => t.Id == coinId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Coin.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Coin ToDbModel(CoinModel coinModel)
        {
            var coinDb = new Coin
            {
                Id = coinModel.Id,
                Name = coinModel.Name,
                Ticker = coinModel.Ticker,
                Favourite = coinModel.Favourite,
                PurchasePrice = coinModel.PurchasePrice,
                PurchaseDate = coinModel.PurchaseDate,
                Quantity = coinModel.Quantity,
                CurrentPrice = coinModel.CurrentPrice,
                CurrentPriceDate = coinModel.CurrentPriceDate
            };

            return coinDb;
        }

        private CoinModel CheckCurrentPriceChange(Coin original, CoinModel coinModel)
        {
            if (coinModel.CurrentPrice != original.CurrentPrice)
            {
                coinModel.CurrentPriceDate = DateTime.Now;
            }
            return coinModel;
        }
    }
}
