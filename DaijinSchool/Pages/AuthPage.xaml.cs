using DaijinSchool.Models;
using DaijinSchool.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DaijinSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        bool IsFalse;
        List<UserDB> users;
        public AuthPage()
        {
            InitializeComponent();
            IsFalse = true;
            GetUsers();
        }
        private async void GetUsers()
        {
            users = await Task.Run(() => App.db.UserDB.ToList());
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in users)
            {
                if(EmailTb.Text == item.Email)
                {
                    if(PasswordTb.Password == item.Password)
                    {
                        App.CurrentUser = item;
                        LoadingFunc();
                    }
                    else
                    {
                        AnimateTextBlock(PromptTb);
                    }
                }
                else
                {
                    AnimateTextBlock(PromptTb);
                }
            }
        }
        private async void LoadingFunc()
        {
            IsFalse = true;
            MainGrid.Visibility = Visibility.Collapsed;
            PromptGrid.Visibility = Visibility.Visible;
            AnimateTextBlock(LoadingTb);
            await Task.Delay(1000);
            AnimateTextBlockBack(LoadingTb);
            await Task.Delay(1000);
            IsFalse = true;
            AnimateTextBlock(LoadingTb);
            await Task.Delay(1000);
            if(App.CurrentUser.RoleId == 3)
            {
                NavigationService.Navigate(new CoursesPage());
                App.mainWindow.InServiceSP.Visibility = Visibility.Visible;
            }
            else if(App.CurrentUser.RoleId == 2)
            {
                NavigationService.Navigate(new CoursesPage());
                App.mainWindow.TeacherSP.Visibility = Visibility.Visible;
            }
            else if (App.CurrentUser.RoleId == 1)
            {
                NavigationService.Navigate(new AdminCoursePage());
            }
        }
        private void AnimateTextBlock(TextBlock tb)
        {
            if (IsFalse)
            {
                IsFalse = false;
                DoubleAnimation fadeInAnimation = new DoubleAnimation();
                tb.Visibility = Visibility.Visible;
                tb.Opacity = 0.0;
                fadeInAnimation.Duration = TimeSpan.FromSeconds(1);
                fadeInAnimation.From = 0.0;
                fadeInAnimation.To = 1.0;

                tb.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
            }
        }
        private void AnimateTextBlockBack(TextBlock tb)
        {
                IsFalse = true;
                DoubleAnimation fadeInAnimation = new DoubleAnimation();
                fadeInAnimation.Duration = TimeSpan.FromSeconds(1);
                fadeInAnimation.From = 1.0;
                fadeInAnimation.To = 0.0;
                tb.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentUser = App.db.UserDB.First(x => x.id >= 0);
            NavigationService.Navigate(new CoursesPage());
            App.mainWindow.InServiceSP.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.CurrentUser = App.db.UserDB.First(x => x.RoleId == 2);
            NavigationService.Navigate(new CoursesPage());
            App.mainWindow.TeacherSP.Visibility = Visibility.Visible;
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage(new UserDB()));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            App.CurrentUser = App.db.UserDB.First(x => x.RoleId == 1);
            NavigationService.Navigate(new AdminCoursePage());
            App.mainWindow.AdminSP.Visibility = Visibility.Visible;
        }
    }
}
