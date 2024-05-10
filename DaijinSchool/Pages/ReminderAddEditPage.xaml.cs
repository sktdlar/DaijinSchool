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
    /// Логика взаимодействия для ReminderAddEditPage.xaml
    /// </summary>
    public partial class ReminderAddEditPage : Page
    {
        Remainder remainder;
        public ReminderAddEditPage(Remainder remainder)
        {
            InitializeComponent();
            this.remainder = remainder;
            DataContext = this.remainder;

            if (remainder.id != 0)
            {
                AddReminder.Content = "Изменить остаток";
            }
        }

        private void AddReminder_Click(object sender, RoutedEventArgs e)
        {
            if(remainder.Count != null && remainder.Discount != null)
            {
                if(remainder.id == 0)
                    App.db.Remainder.Add(remainder);
                    App.db.SaveChanges();
                    App.adminProdsPage.ReminderFrame.Visibility = Visibility.Collapsed;
                    App.adminProdsPage.RemindersDg.ItemsSource = App.db.Remainder.ToList().Where(x => x.Product == remainder.Product);
            }
            else
            {
                App.adminProdsPage.ReminderFrame.Visibility = Visibility.Collapsed;
            }
        }

        private void CountTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void DiscountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
                if (!char.IsDigit(e.Text, 0))
                {
                    e.Handled = true; 
                    return;
                }
                TextBox textBox = sender as TextBox;
                string newText = textBox.Text + e.Text;

                if (!string.IsNullOrEmpty(newText) && int.Parse(newText) > 100)
                {
                    e.Handled = true; 
                }
            }
    }
}
