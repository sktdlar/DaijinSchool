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
    /// Логика взаимодействия для LessonPage.xaml
    /// </summary>
    public partial class LessonPage : Page
    {
        Schedule schedule1;
        public LessonPage(Schedule schedule)
        {
            InitializeComponent();
            schedule1 = schedule;
            DataContext = schedule;
            foreach (var item in App.db.ScheduleMaterial)
            {
                if(item.ScheduleId == schedule.id)
                {
                    MaterialsWP.Children.Add(new LessonMaterialUC(item));
                }
            }
            if(App.CurrentUser.RoleId != 2)
            {
                DeleteLessonButton.IsEnabled = false;
                DeleteLessonButton.Visibility = Visibility.Collapsed;
            }
        }
        bool isdeleted = false;
        private void DeleteLessonButton_Click(object sender, RoutedEventArgs e)
        {
            if(isdeleted)
            {
                foreach(var item in App.db.ScheduleMaterial)
                {
                    if(item.ScheduleId == schedule1.id)
                    {
                        App.db.ScheduleMaterial.Remove(item);
                        App.db.SaveChanges();
                    }
                }
                var courses = schedule1.Courses;
                App.db.Schedule.Remove(schedule1);
                App.db.SaveChanges();
                NavigationService.Navigate(new ScheduleForTeacherPage(courses));
            }
            else
            {
                MessageBox.Show("Вы удаляете урок, нажмите на кнопку еще раз, что бы подтвердить свои действия. После удаления урок не получится восстановить, он будет удален навсегда!");
                isdeleted = true;
            }
        }
    }
}
