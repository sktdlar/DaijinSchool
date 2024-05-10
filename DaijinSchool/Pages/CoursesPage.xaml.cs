using DaijinSchool.Models;
using DaijinSchool.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
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
    /// Логика взаимодействия для CoursesPage.xaml
    /// </summary>
    public partial class CoursesPage : Page
    {
        List<Courses> courses;
        public CoursesPage()
        {
            InitializeComponent();
            if(App.CurrentUser.RoleId == 2)
            {
                FilterCB.Visibility = Visibility.Collapsed;
                scrollViewer.HorizontalAlignment = HorizontalAlignment.Center;
                scrollViewer.Width = gridGd.Width;
                foreach(var item in App.db.Courses.Where(x => App.db.Category.Any(c => c.id == x.CategoryId && c.InstructorId == App.CurrentUser.id)).ToList())
                {
                    CoursesWP.Children.Add(new CoursesUC(item, this));
                }
                TitleTb.Text = "Просмотрите и обновите ваши курсы";
                SecTitleTb.Text = "На данной странице вы можете просмотреть свои опубликованные курсы, а так же обновить их и добавить уроки к ним";
                
;            }
            else
            {
                CategoryCb.Items.Add("");
                foreach (var item in App.db.Category.ToList())
                {
                    CategoryCb.Items.Add(item);
                }
                CategoryCb.DisplayMemberPath = "Name";
                Refresh();
            }

        }

        public void Refresh()
        {
            var coursesFalse = App.db.Courses.Where(c => !App.db.DeletedCourses.Any(dc => dc.idCourse == c.id)).ToList();
            courses = App.db.Courses.ToList();
            foreach (var item in courses)
            {
                foreach(var item1 in App.db.ListOfCourses.Where(x => x.UserId == App.CurrentUser.id))
                {
                    if(item.id == item1.CourseId)
                    {
                        coursesFalse.Remove(item);
                    }
                }
            }
            courses = coursesFalse;
            if(SearchTb.Text.Length > 0)
            {
                courses = courses.ToList().Where(x => x.Name.Contains(SearchTb.Text) || x.Description.Contains(SearchTb.Text)).ToList();
            }
            CoursesWP.Children.Clear();

            if (CategoryCb.SelectedIndex != 0 && CategoryCb.SelectedIndex != -1)
            {
                courses = courses.Where(x => x.Category == (Category)CategoryCb.SelectedItem).ToList();
            }
            if (PriceCb.SelectedItem != null)
            {
                if (PriceCb.SelectedIndex == 1)
                {
                    courses = courses.OrderBy(x => x.Price).ToList();
                }
                if (PriceCb.SelectedIndex == 2)
                {
                    courses = courses.OrderByDescending(x => x.Price).ToList();
                }
            }
            if (DurationCb.SelectedItem != null)
            {
                if (DurationCb.SelectedIndex == 1)
                {
                    courses = courses.OrderBy(x => x.Duration).ToList();
                }
                if (DurationCb.SelectedIndex == 2)
                {
                    courses = courses.OrderByDescending(x => x.Duration).ToList();
                }
            }

            foreach (var item in courses)
            {
                CoursesWP.Children.Add(new CoursesUC(item, this));
            }
        }

        private void DurationCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CategoryCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void PriceCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}
