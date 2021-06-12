using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CryptoWalletApp.Model;

namespace CryptoWalletApp
{
    /// <summary>
    /// Interaction logic for CoinWindow.xaml
    /// </summary>
    public partial class CoinWindow : Window
    {
        public CoinWindow()
        {
            InitializeComponent();

            ShowInTaskbar = false;
        }

        public CoinModel Coin { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Coin != null)
            {
                uxSubmit.Content = "Update";
            }
            else
            {
                Coin = new CoinModel();
                Coin.PurchaseDate = DateTime.Now;
                uxCurrentPriceDate.Visibility = Visibility.Hidden;
                uxCurrentPriceLastUpdated.Visibility = Visibility.Hidden;
            }

            uxGrid.DataContext = Coin;
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {            
            DialogResult = true;
            Close();
        }

        private void ValidateModel(object sender, KeyEventArgs e)
        {
            
            if (string.IsNullOrEmpty(Coin.Error_Name) &&
                string.IsNullOrEmpty(Coin.Error_Ticker) &&
                string.IsNullOrEmpty(Coin.Error_PurchasePrice) &&
                string.IsNullOrEmpty(Coin.Error_Quantity))
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }
    }
}
