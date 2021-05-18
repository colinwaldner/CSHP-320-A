
/******************************************
 * 
 * CSHP 320 A
 * Assignment 3
 * Colin Waldner
 * April 30, 2021
 * 
 ****************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HomeWork3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CollectionView view;
        BitmapImage up_arrow;
        BitmapImage down_arrow;

        public MainWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
            view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            uxList.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(ListView_HeaderClick));

            up_arrow = new BitmapImage(new Uri("pack://application:,,,/Images/caret-up-solid.png"));
            down_arrow = new BitmapImage(new Uri("pack://application:,,,/Images/caret-down-solid.png"));
        }

        private void ListView_HeaderClick(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            string header = headerClicked.Name;

            switch (header)
            {
                case "Name": Sort("Name"); uxNameHeader_icon.Source = down_arrow; uxPasswordHeader_icon.Source = up_arrow; break;
                case "Password": Sort("Password"); uxNameHeader_icon.Source = up_arrow; uxPasswordHeader_icon.Source = down_arrow; break;
            }
        }
        private void Sort(string sortBy)
        {
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription(sortBy, ListSortDirection.Ascending));
            view.Refresh();
        }
    }
}
