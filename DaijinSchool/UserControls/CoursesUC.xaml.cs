using DaijinSchool.Models;
using DaijinSchool.Pages;
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

namespace DaijinSchool.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CoursesUC.xaml
    /// </summary>
    public partial class CoursesUC : UserControl
    {
        Courses course;
        CoursesPage ParrentPage;
        public CoursesUC(Courses _course, CoursesPage page)
        {
            InitializeComponent();
            ParrentPage = page;
            DataContext = _course;
            course = _course;
            if (App.db.Rate.ToList().Where(x => x.CourseId == course.id).Any())
            {
                ScoresTb.Text = Math.Round((double)App.db.Rate.ToList().Where(x => x.CourseId == course.id).Average(x => x.Mark), 2).ToString();
            }
            else
                ScoresTb.Text = "недоступна";
        }

        private void TakeACourseBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new AuthPage());
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(App.CurrentUser.RoleId == 3)
            {
                bool IsAdded = false;
                foreach(var item in App.db.ListOfCourses)
                {
                    if(item.UserId == App.CurrentUser.id && item.CourseId == course.id)
                    {
                        NavigationService.GetNavigationService(this).Navigate(new SchedulePage(course));
                        IsAdded = true; break;
                    }
                }
                if(!IsAdded)
                {
                App.db.ListOfCourses.Add(new ListOfCourses()
                {
                    UserId = App.CurrentUser.id,
                    CourseId = course.id,
                });
                  IsAdded = true;
                App.db.SaveChanges();
                MessageBox.Show("Курс добавлен к вам в профиль.");
                ParrentPage.Refresh();
                }
            }
            else
            {
                NavigationService.GetNavigationService(this).Navigate(new ScheduleForTeacherPage(course));
            }
        }
    }
}
