using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InClassPropertyChange
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Colin", Password = "Temppass1" });
            users.Add(new Models.User { Name = "Joelle", Password = "Temppass2" });
            users.Add(new Models.User { Name = "Kelsey", Password = "Temppass3" });

            uxList.ItemsSource = users;
        }
    }
}
