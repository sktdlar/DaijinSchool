using DaijinSchool.Models;
using DaijinSchool.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для AdminCoursePage.xaml
    /// </summary>
    public partial class AdminCoursePage : Page
    {
        public AdminCoursePage()
        {
            InitializeComponent();
            CourseDg.ItemsSource = App.db.Courses.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CourseDg.SelectedItem != null && ((Courses)CourseDg.SelectedItem).IsDeleted == "Не удален")
            {
                NavigationService.Navigate(new CourseAddPage((Courses) CourseDg.SelectedItem));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CourseDg.ItemsSource = null;
            CourseDg.ItemsSource = App.db.Courses.ToList();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CourseDg.SelectedItem != null && ((Courses)CourseDg.SelectedItem).IsDeleted == "Не удален")
            {
                App.db.Courses.Remove((Courses)CourseDg.SelectedItem);
                App.db.SaveChanges();
                CourseDg.ItemsSource = null;
                CourseDg.ItemsSource = App.db.Courses.ToList();
                MessageBox.Show("Курс удален");
            }
            else
            {
                MessageBox.Show("Курс не выбран или уже удален");
            }
        }

        private void CategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            if(App.db.UserDB.ToList().Where(x => !x.Category.Any()).Count() != 0)
            {
                MessageBox.Show("Нет преподавателей, которые готовы взять на себя новую категорию! Ожидается регистрация нового преподавателя!");
            }
            else
            {
                var dialogWindow = new AddCourseCategoryWindow();
                dialogWindow.Owner = App.mainWindow;
                dialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                dialogWindow.ShowDialog();
            }
        }
    }
}
