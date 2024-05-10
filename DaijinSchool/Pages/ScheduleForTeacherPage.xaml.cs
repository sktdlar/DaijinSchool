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
    /// Логика взаимодействия для ScheduleForTeacherPage.xaml
    /// </summary>
    public partial class ScheduleForTeacherPage : Page
    {
        Courses courses;
        public ScheduleForTeacherPage(Courses _course)
        {
            InitializeComponent();
            courses = _course;
            foreach (var item in App.db.Schedule.Where(x => x.CourseId == courses.id))
            {
                ScheduleWP.Children.Add(new ScheduleUC(item));
            }
            foreach (var item in App.db.Comments.ToList().Where(x => x.CourseId == courses.id))
            {
                FeedBackWP.Children.Add(new FeedBackUC(item));
            }
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            scrollView.ScrollToVerticalOffset(scrollView.VerticalOffset + 900);
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ScheduleMaterialAddingPage(courses));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ScheduleWP.Children.Clear();
            FeedBackWP.Children.Clear();
            foreach (var item in App.db.Schedule.Where(x => x.CourseId == courses.id))
            {
                ScheduleWP.Children.Add(new ScheduleUC(item));
            }
            foreach (var item in App.db.Comments.ToList().Where(x => x.CourseId == courses.id))
            {
                FeedBackWP.Children.Add(new FeedBackUC(item));
            }
        }

        private void Hyperlink_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChatWithFollowersPage(courses));
        }
    }
}
