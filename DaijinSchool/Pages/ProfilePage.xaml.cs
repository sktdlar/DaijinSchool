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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            DataContext = App.CurrentUser;
            if(App.CurrentUser.RoleId == 1)
            {
                EditBtn.Visibility = Visibility.Collapsed;
                BorderBtn.BorderThickness = new Thickness(0, 0, 0, 0);
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainEditProfilePage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            DataContext = App.CurrentUser;
        }
    }
}
