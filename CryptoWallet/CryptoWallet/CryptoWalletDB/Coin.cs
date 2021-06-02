using System;
using System.Collections.Generic;

namespace CryptoWalletDB
{
    public partial class Coin
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
}
