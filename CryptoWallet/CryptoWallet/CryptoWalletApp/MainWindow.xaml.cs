using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using CryptoWalletApp.Model;

namespace CryptoWalletApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private CoinModel selectedCoin;

        public MainWindow()
        {
            InitializeComponent();

            LoadCoins();            
        }

        #region Sorting Class
        public class SortAdorner : Adorner
        {
            private static Geometry ascGeometry =
                Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry descGeometry =
                Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                : base(element)
            {
                this.Direction = dir;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                    (
                        AdornedElement.RenderSize.Width - 15,
                        (AdornedElement.RenderSize.Height - 5) / 2
                    );
                drawingContext.PushTransform(transform);

                Geometry geometry = ascGeometry;
                if (this.Direction == ListSortDirection.Descending)
                    geometry = descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }
        #endregion
        private void LoadCoins()
        {
            var coins = App.CoinRepository.GetAll();
            uxList.ItemsSource = coins
                .Select(s => CoinModel.ToModel(s))
                .OrderBy(o => o.Name)
                .ToList();            

            //Status Bar Totals
            var sumPurchasePrice = coins.Sum(coin => coin.PurchasePrice * coin.Quantity);
            var sumCurrentPrice = coins.Sum(coin => coin.CurrentPrice * coin.Quantity);

            uxTotalCount.Text = coins.Count.ToString();
            uxPurchaseValue.Text = String.Format("{0:C}", sumPurchasePrice);
            uxCurrentValue.Text = String.Format("{0:C}", sumCurrentPrice);
            uxTotalValue.Text = String.Format("{0:C}", (sumCurrentPrice - sumPurchasePrice));           

            if ((sumCurrentPrice - sumPurchasePrice) <= 0)
            {
                uxTotalValue.Foreground = Brushes.Red;
            }
            else
            {
                uxTotalValue.Foreground = Brushes.Green;
            }   
                        
        }
        private void uxList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCoin = (CoinModel)uxList.SelectedItem;

            uxContextEdit.IsEnabled = (selectedCoin != null);
            uxFileEdit.IsEnabled = (selectedCoin != null);
            uxContextDelete.IsEnabled = (selectedCoin != null);
            uxFileDelete.IsEnabled = (selectedCoin != null);
        }
        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();

            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
            {
                newDir = ListSortDirection.Descending;
            }

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        #region New_Click
        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new CoinWindow();
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (window.ShowDialog() == true)
            {
                var uiCoinModel = window.Coin;

                var repositoryCoinModel = uiCoinModel.ToRepositoryModel();

                App.CoinRepository.Add(repositoryCoinModel);

                LoadCoins();
            }
        }

        #endregion

        #region Edit_Click
        private void uxContextEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCoin != null)
            {
                var window = new CoinWindow();
                window.Coin = selectedCoin?.Clone();

                if (window.ShowDialog() == true)
                {
                    App.CoinRepository.Update(window.Coin.ToRepositoryModel());
                    LoadCoins();
                }
            }
        }

        private void uxList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            uxContextEdit_Click(sender, null);                     
        }

        private void uxFileEdit_Click(object sender, RoutedEventArgs e)
        {
            uxContextEdit_Click(sender, null);
        }

        #endregion

        #region Delete_Click
        private void uxContextDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCoin != null)
            {
                App.CoinRepository.Remove(selectedCoin.Id);
                LoadCoins();
            }
        }
        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            uxContextDelete_Click(sender, null);
        }

        #endregion

        #region Other_Click        

        private void uxFileExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion


    }
}
