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
using System.Windows.Shapes;

namespace DaijinSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddCourseCategoryWindow.xaml
    /// </summary>
    public partial class AddCourseCategoryWindow : Window
    {
        Category category;
        public AddCourseCategoryWindow()
        {
            InitializeComponent();
            DataContext = category;
            TeacherTb.ItemsSource = App.db.UserDB.ToList().Where(x => x.RoleId == 2 && !x.Category.Any());
            TeacherTb.DisplayMemberPath = "FIO";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(category.Name.Length > 0 && category.DescriptionOfCourse.Length > 0 && category.UserDB != null)
            {
                App.db.Category.Add(category);
                App.db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Категория не добавлена, заполните данные заново!");
            }
        }
    }
}
