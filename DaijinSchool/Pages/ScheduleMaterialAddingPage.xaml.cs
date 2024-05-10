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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DaijinSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для ScheduleMaterialAddingPage.xaml
    /// </summary>
    public partial class ScheduleMaterialAddingPage : Page
    {
        Schedule schedule;
        Courses course;
        List<ScheduleMaterial> materials;
        public ScheduleMaterialAddingPage(Courses courses)
        {
            InitializeComponent();
            materials = new List<ScheduleMaterial>();
            course = courses;
            DateOfSchedule.DisplayDateStart = App.db.Schedule.ToList().LastOrDefault(x => true).Date > DateTime.Now ? App.db.Schedule.ToList().LastOrDefault(x => true).Date : DateTime.Now;
            ScheduleDG.ItemsSource = materials;
            NumOfLessonTb.Text = (App.db.Schedule.ToList().Last(x => x.CourseId == course.id).LessonNumber + 1).ToString();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MaterialURLTb.Text.Length > 0 && DescriptionTb.Text.Length > 0)
            {
                materials.Add(new ScheduleMaterial()
                {
                    ScheduleId = course.id,
                    MaterialURL = MaterialURLTb.Text,
                    Description = DescriptionTb.Text,
                });
            }
            ScheduleDG.ItemsSource = null;
            ScheduleDG.ItemsSource = materials;
            MaterialURLTb.Text = "";
            DescriptionTb.Text = "";
        }

        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            if(DescOfCourseTb.Text.Length > 0 && DateOfSchedule.SelectedDate != null)
            {
                try
                {
                App.db.Schedule.Add(new Schedule()
                {
                    Date = DateOfSchedule.SelectedDate,
                    DescriptionOfLesson = DescOfCourseTb.Text,
                    LessonNumber = int.Parse(NumOfLessonTb.Text),
                    IsAvailable = (bool)IsAvailable.IsChecked? 1 : 0,
                    CourseId = course.id,
                });

                App.db.SaveChanges();
                var schedule = App.db.Schedule.ToList().Last(x => true);
                foreach(var item in materials)
                {
                    item.ScheduleId = schedule.id;
                    App.db.ScheduleMaterial.Add(item);
                    App.db.SaveChanges();
                }
                NavigationService.GoBack();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"Ошибка FormatException: {ex.Message}");
                    MessageBox.Show($"Стек вызовов: {ex.StackTrace}");
                }

            }
        }
    }
}
