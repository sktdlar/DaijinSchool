using DaijinSchool.Models;
using DaijinSchool.UserControls;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        Courses courses;
        public SchedulePage(Courses _course)
        {
            InitializeComponent();
            courses = _course;
            foreach (var item in App.db.Schedule.Where(x => x.CourseId == courses.id))
            {
                ScheduleWP.Children.Add(new ScheduleUC(item));
            }
            foreach(var item in App.db.Comments.ToList().Where(x => x.CourseId == courses.id))
            {
                FeedBackWP.Children.Add(new FeedBackUC(item));
            }
            
            var mark = App.db.Rate.ToList().FirstOrDefault(x => x.CourseId == courses.id && x.UserId == App.CurrentUser.id)?.Mark;
            if(mark != null)
            {
                if(mark == 1)
                {
                    Star11.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                }
                if(mark == 2)
                {
                    Star11.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                    Star22.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                }
                if(mark == 3)
                {
                    Star11.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                    Star22.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                    Star33.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                }
                if (mark == 4)
                {
                    Star11.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                    Star22.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                    Star33.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                    Star44.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                }
                if(mark == 5)
                {
                    Star11.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                    Star22.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                    Star33.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                    Star44.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                    Star55.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            scrollView.ScrollToVerticalOffset(scrollView.VerticalOffset + 900);
        }
        private void CommentTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length > 500)
            {
                textBox.Text = textBox.Text.Substring(0, 500);
                textBox.CaretIndex = textBox.Text.Length;
                MessageBox.Show("Превышено максимальное количество символов (500).", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SendCommentBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.Comments.Add(new Comments()
            {
                CourseId = courses.id,
                UserId = App.CurrentUser.id,
                CommentText = CommentTb.Text,
                Date = DateTime.Now,
            });
            App.db.SaveChanges();
            FeedBackWP.Children.Clear();
            foreach (var item in App.db.Comments.ToList().Where(x => x.CourseId == courses.id))
            {
                FeedBackWP.Children.Add(new FeedBackUC(item));
            }
            scrollView.ScrollToVerticalOffset(scrollView.VerticalOffset + 600);
            CommentTb.Text = "";
        }
        bool Marked = false;

        private void Star1(object sender, MouseButtonEventArgs e)
        {
            foreach (var item in App.db.Rate.ToList().Where(x => x.UserId == App.CurrentUser.id))
            {
                if(item.CourseId == courses.id && item.UserId == App.CurrentUser.id)
                {
                    Marked = true; break;
                }
            }
            if (Marked)
            {
                App.db.Rate.ToList().First(x => x.CourseId == courses.id && x.UserId == App.CurrentUser.id).Mark = 1;
            }
            else
            {
                App.db.Rate.Add(new Rate()
                {
                    CourseId = courses.id,
                    UserId = App.CurrentUser.id,
                    Mark = 1
                });
            }
                App.db.SaveChanges();
            Star11.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star22.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            Star33.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            Star44.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            Star55.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
        }

        private void Star2(object sender, MouseButtonEventArgs e)
        {
            foreach (var item in App.db.Rate.ToList().Where(x => x.UserId == App.CurrentUser.id))
            {
                if (item.CourseId == courses.id && item.UserId == App.CurrentUser.id)
                {
                    Marked = true; break;
                }
            }
            if (Marked)
            {
                App.db.Rate.ToList().First(x => x.CourseId == courses.id && x.UserId == App.CurrentUser.id).Mark = 2;
            }
            else
            {
                App.db.Rate.Add(new Rate()
                {
                    CourseId = courses.id,
                    UserId = App.CurrentUser.id,
                    Mark = 2
                });
            }
            App.db.SaveChanges();
            Star11.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star22.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star33.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            Star44.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            Star55.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));

        }
        private void Star3(object sender, MouseButtonEventArgs e)
        {
            foreach (var item in App.db.Rate.ToList().Where(x => x.UserId == App.CurrentUser.id))
            {
                if (item.CourseId == courses.id && item.UserId == App.CurrentUser.id)
                {
                    Marked = true; break;
                }
            }
            if (Marked)
            {
                App.db.Rate.ToList().First(x => x.CourseId == courses.id && x.UserId == App.CurrentUser.id).Mark = 3;
            }
            else
            {
                App.db.Rate.Add(new Rate()
                {
                    CourseId = courses.id,
                    UserId = App.CurrentUser.id,
                    Mark = 3
                });
            }
            App.db.SaveChanges();
            Star11.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star22.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star33.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star44.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            Star55.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));

        }
        private void Star4(object sender, MouseButtonEventArgs e)
        {
            foreach (var item in App.db.Rate.ToList().Where(x => x.UserId == App.CurrentUser.id))
            {
                if (item.CourseId == courses.id && item.UserId == App.CurrentUser.id)
                {
                    Marked = true; break;
                }
            }
            if (Marked)
            {
                App.db.Rate.ToList().First(x => x.CourseId == courses.id && x.UserId == App.CurrentUser.id).Mark = 4;
            }
            else
            {
                App.db.Rate.Add(new Rate()
                {
                    CourseId = courses.id,
                    UserId = App.CurrentUser.id,
                    Mark = 4
                });
            }
            App.db.SaveChanges();
            Star11.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star22.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star33.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star44.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star55.Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128));

        }
        private void Star5(object sender, MouseButtonEventArgs e)
        {
            foreach (var item in App.db.Rate.ToList().Where(x => x.UserId == App.CurrentUser.id))
            {
                if (item.CourseId == courses.id && item.UserId == App.CurrentUser.id)
                {
                    Marked = true; break;
                }
            }
            if (Marked)
            {
                App.db.Rate.ToList().First(x => x.CourseId == courses.id && x.UserId == App.CurrentUser.id).Mark = 5;
            }
            else
            {
                App.db.Rate.Add(new Rate()
                {
                    CourseId = courses.id,
                    UserId = App.CurrentUser.id,
                    Mark = 5
                });
            }
            App.db.SaveChanges();
            Star11.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star22.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star33.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star44.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
            Star55.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));

        }
    }
}
