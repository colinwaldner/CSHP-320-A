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
using Microsoft.EntityFrameworkCore;

namespace InClassPropertyChange
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();
        public MainWindow()
        {
            InitializeComponent();
            //uxName.DataContext = user;
            //uxNameError.DataContext = user;
            uxContainer.DataContext = user;

            var sample = new SampleContext();
            sample.Users.Load();
            var users = sample.Users.Local.ToObservableCollection();
            uxList.ItemsSource = users;
        }

        private void uxButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            var window = new SecondWindow();

            Application.Current.MainWindow = window;
            Close();
            window.Show();

        }
    }
}
