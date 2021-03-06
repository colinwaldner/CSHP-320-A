using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoWalletApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static CryptoWalletRepository.CoinRepository _coinRepository;

        static App()
        {
            _coinRepository = new CryptoWalletRepository.CoinRepository();
        }
        public static CryptoWalletRepository.CoinRepository CoinRepository
        {
            get
            {
                return _coinRepository;
            }
        }
    }
}
