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
    /// Interaction logic for StatusWindow.xaml
    /// </summary>
    public partial class StatusWindow : Window
    {
        public StatusWindow()
        {
            InitializeComponent();
        }
        private void uxTextEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = uxTextEditor.GetLineIndexFromCharacterIndex(uxTextEditor.CaretIndex);
            int col = uxTextEditor.CaretIndex - uxTextEditor.GetCharacterIndexFromLineIndex(row);
            uxStatus.Text = "Line " + (row + 1) + ", Char " + (col + 1);

            uxProgressBar.Value = uxTextEditor.Text.Length;
            uxProgressPercent.Text = ((uxTextEditor.Text.Length / uxProgressBar.Maximum) * 100).ToString() + "%";
        }
    }
}
