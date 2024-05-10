using DaijinSchool.Models;
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

namespace DaijinSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyCoursesPage.xaml
    /// </summary>
    public partial class MyCoursesPage : Page
    {
        List<Courses> courses;
        public MyCoursesPage()
        {
            InitializeComponent();
            Refresh();
        }

        public void Refresh()
        {
            CoursesWP.Children.Clear();
            courses = App.db.Courses.ToList();
            foreach (var course in courses)
            {
                foreach(var item in App.db.ListOfCourses.Where(x => x.UserId == App.CurrentUser.id))
                {
                    if(course.id == item.CourseId)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            CoursesWP.Children.Add(new CoursesUC(course, new CoursesPage()));
                        });
                    }
                }
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
