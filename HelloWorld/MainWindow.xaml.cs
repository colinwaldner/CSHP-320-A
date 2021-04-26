
/******************************************
 * 
 * CSHP 320 A
 * Assignment 1
 * Colin Waldner
 * April 26, 2021
 * 
 ****************************************/

using System.Windows;
using System.Windows.Controls;

namespace HomeWork1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"User Name: {uxName.Text}\n Password: {uxPassword.Text}");
        }
        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CheckText()) { uxSubmit.IsEnabled = true; }
            else { uxSubmit.IsEnabled = false; }
        }
        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CheckText()) { uxSubmit.IsEnabled = true; }
            else { uxSubmit.IsEnabled = false; }
        }
        private bool CheckText()
        {
            bool result = false;

            if (!string.IsNullOrEmpty(uxName.Text) && !string.IsNullOrEmpty(uxPassword.Text))
            {
                result = true;
            }

            return result;
        }
    }
}
