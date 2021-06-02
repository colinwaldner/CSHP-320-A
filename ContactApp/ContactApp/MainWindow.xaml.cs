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
using ContactApp.Models;
using System.ComponentModel;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private ContactModel selectedContact;

        public MainWindow()
        {
            InitializeComponent();

            LoadContacts();
        }

        #region Sort
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

        private void LoadContacts()
        {
            var contacts = App.ContactRepository.GetAll();

            uxContactList.ItemsSource = contacts
                .Select(t => ContactModel.ToModel(t))
                .ToList();
        }               

        private void GridViewColumnHeader_Click_Sort(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();

            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxContactList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
            {
                newDir = ListSortDirection.Descending;
            }

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxContactList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }        

        private void uxContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContact = (ContactModel)uxContactList.SelectedValue;
            uxContextDelete.IsEnabled = (selectedContact != null);
            uxContextModify.IsEnabled = (selectedContact != null);
        }

        #region NEW Click
        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Contact;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.ContactRepository.Add(repositoryContactModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());

                LoadContacts();
            }
        }
        private void uxContextNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Contact;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.ContactRepository.Add(repositoryContactModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());

                LoadContacts();
            }
        }
        #endregion

        #region MODIFY Click
        private void uxFileModify_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();
            window.Contact = selectedContact.Clone();

            if(window.ShowDialog() == true)
            {
                App.ContactRepository.Update(window.Contact.ToRepositoryModel());
                LoadContacts();
            }
        }
        private void uxContextModify_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();
            window.Contact = selectedContact.Clone();

            if (window.ShowDialog() == true)
            {
                App.ContactRepository.Update(window.Contact.ToRepositoryModel());
                LoadContacts();
            }
        }
        private void uxContactList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var window = new ContactWindow();
            window.Contact = selectedContact.Clone();

            if (window.ShowDialog() == true)
            {
                App.ContactRepository.Update(window.Contact.ToRepositoryModel());
                LoadContacts();
            }
        }
        private void uxFileModify_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileModify.IsEnabled = (selectedContact != null);
            uxContextModify.IsEnabled = (selectedContact != null);
        }


        #endregion

        #region DELETE Click
        private void uxContextDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ContactRepository.Remove(selectedContact.Id);
            selectedContact = null;
            LoadContacts();
        }
        
        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ContactRepository.Remove(selectedContact.Id);
            selectedContact = null;
            LoadContacts();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedContact != null);
        }
        #endregion

    }
}