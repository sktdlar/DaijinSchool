using DaijinSchool.Models;
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

namespace DaijinSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminProdsPage.xaml
    /// </summary>
    public partial class AdminProdsPage : Page
    {
        public AdminProdsPage()
        {
            InitializeComponent();
            var NeededTable = App.db.Product.ToList();
            ProdsDg.ItemsSource = NeededTable;
            App.adminProdsPage = this;
            ReminderFrame.Visibility = Visibility.Collapsed;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ProdsDg.ItemsSource = null;
            var NeededTable = App.db.Product.ToList();
            ProdsDg.ItemsSource = NeededTable;
        }

        private void AddProdBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProdPage(new Product()));
        }

        private void EditProdBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ProdsDg.SelectedItem != null)
            {
                NavigationService.Navigate(new AddEditProdPage((Product)ProdsDg.SelectedItem));
            }
        }

        private void RemindersBTn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProdsDg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProdsDg.SelectedItem != null)
            {
                RemindersDg.ItemsSource = App.db.Remainder.ToList().Where(x => x.Product == ProdsDg.SelectedItem as Product);
            }
        }

        private void EditReminder_Click(object sender, RoutedEventArgs e)
        {
            ReminderFrame.Visibility = Visibility.Visible;
            if (RemindersDg.SelectedItem != null)
            {
                ReminderFrame.NavigationService.Navigate(new ReminderAddEditPage((Remainder)RemindersDg.SelectedItem));
            }
        }

        private void AddRenminder_Click(object sender, RoutedEventArgs e)
        {
            ReminderFrame.Visibility = Visibility.Visible;
            if (ProdsDg.SelectedItem != null)
            {
                ReminderFrame.NavigationService.Navigate(new ReminderAddEditPage(new Remainder()
                {
                    ProductId = (ProdsDg.SelectedItem as Product).id,
                }));
            }
        }

        private void DelReminder_Click(object sender, RoutedEventArgs e)
        {
            if (RemindersDg.SelectedItem != null)
            {
                App.db.Remainder.Remove((Remainder)RemindersDg.SelectedItem);
                RemindersDg.ItemsSource = App.db.Remainder.ToList().Where(x => x.Product == ProdsDg.SelectedItem as Product);
            }
        }
    }
}
