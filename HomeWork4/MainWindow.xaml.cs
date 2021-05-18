/******************************************
 * 
 * CSHP 320 A
 * Assignment 4
 * Colin Waldner
 * May 18, 2021
 * 
 ****************************************/

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HomeWork4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
        }

        private void uxPostalCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = uxPostalCode.Text;
            bool isValid = false;

            if (text.All(Char.IsDigit) && text.Length == 5) 
            { 
                isValid = true; 
            }            
            else if (text.Length == 6)
            {
                isValid = true;
                for (int i = 0; i < text.Length; i++)
                {
                    if (i%2 == 0)
                    {
                        if (!Char.IsLetter(text[i]))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    else
                    {
                        if (!Char.IsDigit(text[i]))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
            }
            else if (text.Length == 10)
            {
                if (text.Substring(0, 5).All(Char.IsDigit))
                {
                    if (text[5].Equals('-'))
                    {
                        if (text.Substring(6, 4).All(Char.IsDigit))
                        {
                            isValid = true;
                        }
                    }
                }
            }

            uxSubmit.IsEnabled = isValid;
        }
    }
}
