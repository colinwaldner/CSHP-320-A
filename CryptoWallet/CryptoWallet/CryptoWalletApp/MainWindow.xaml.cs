using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoWalletApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Coin> Wallet = new List<Coin>();

        public MainWindow()
        {
            InitializeComponent();
            FillWallet();
            uxList.ItemsSource = Wallet;
            uxMaxCount.Text = "100";
            uxCount.Text = Wallet.Count.ToString();
        }
        public void FillWallet()
        {
            Wallet.Add(new Coin { Id = 1, Favourite = false, Name = "Bitcoin", Ticker = "BTC", PurchasePrice = 37609, Quantity = 1, PurchaseDate = DateTime.Now, CurrentPrice = 37609, CurrentPriceDate = DateTime.Now });
            Wallet.Add(new Coin { Id = 2, Favourite = false, Name = "Ethereum", Ticker = "ETH", PurchasePrice = 2500, Quantity = 5, PurchaseDate = DateTime.Now, CurrentPrice = 2500, CurrentPriceDate = DateTime.Now });
            Wallet.Add(new Coin { Id = 3, Favourite = false, Name = "Cardano", Ticker = "ADA", PurchasePrice = 1.5, Quantity = 25, PurchaseDate = DateTime.Now, CurrentPrice = 1.5, CurrentPriceDate = DateTime.Now });
            Wallet.Add(new Coin { Id = 4, Favourite = false, Name = "Total Crypto Market Cap", Ticker = "TCAP", PurchasePrice = 260, Quantity = 3, PurchaseDate = DateTime.Now, CurrentPrice = 260, CurrentPriceDate = DateTime.Now });
            Wallet.Add(new Coin { Id = 5, Favourite = false, Name = "Polyon", Ticker = "MATIC", PurchasePrice = 1.4, Quantity = 25, PurchaseDate = DateTime.Now, CurrentPrice = 1.4, CurrentPriceDate = DateTime.Now });
            Wallet.Add(new Coin { Id = 6, Favourite = false, Name = "Safe Moon", Ticker = "SAFEMOON", PurchasePrice = 0.000006352, Quantity = 5000000, PurchaseDate = DateTime.Now, CurrentPrice = 0.000006352, CurrentPriceDate = DateTime.Now });
            Wallet.Add(new Coin { Id = 7, Favourite = false, Name = "Doge Coin", Ticker = "DOGE", PurchasePrice = 0.3443, Quantity = 2000, PurchaseDate = DateTime.Now, CurrentPrice = 0.3443, CurrentPriceDate = DateTime.Now });
            Wallet.Add(new Coin { Id = 8, Favourite = false, Name = "Polkadot", Ticker = "DOT", PurchasePrice = 22.213, Quantity = 10, PurchaseDate = DateTime.Now, CurrentPrice = 22.213, CurrentPriceDate = DateTime.Now });
        }

        private void ListViewItem_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void uxFavourite_Click(object sender, RoutedEventArgs e)
        {
            uxInfo.IsEnabled = false;
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void uxNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewItemWindow();

            window.ShowInTaskbar = false;
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Show();
        }
    }
}
