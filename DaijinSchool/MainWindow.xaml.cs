using DaijinSchool.Pages;
using DaijinSchool.UserControls;
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

namespace DaijinSchool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.mainWindow = this;
            MainFrame.Navigate(new AuthPage());
            App.mainWindow = this;
        }

        void DeleteHistory()
        {
            while (MainFrame.CanGoBack)
            {
                MainFrame.RemoveBackEntry();
            }
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProfilePage());
            DeleteHistory();
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CoursesPage());
            DeleteHistory();
        }

        private void Hyperlink_Click_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MyCoursesPage());
            DeleteHistory();
        }

        private void Hyperlink_Click_3(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ShopPage());
            DeleteHistory();

        }

        private void Hyperlink_Click_4(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ShoppingCartPage());
            DeleteHistory();
        }

        private void Hyperlink_Click_5(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PreOrderedProductsPage());
            DeleteHistory();

        }

        private void Hyperlink_Click_6(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ChatsPage());
            DeleteHistory();
        }

        private void Hyperlink_Click_7(object sender, RoutedEventArgs e)
        {
            App.CurrentUser = null;
            MainFrame.Navigate(new AuthPage());
            InServiceSP.Visibility = Visibility.Collapsed;
            TeacherSP.Visibility = Visibility.Collapsed;
            AdminSP.Visibility = Visibility.Collapsed;
            DeleteHistory();
        }

        private void Hyperlink_Click_8(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CourseAddPage(new Models.Courses()));
            DeleteHistory();

        }

        private void Hyperlink_Click_9(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminCoursePage());
            DeleteHistory();
        }

        private void Hyperlink_Click_10(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AdminProdsPage());
            DeleteHistory();
        }
    }
}
