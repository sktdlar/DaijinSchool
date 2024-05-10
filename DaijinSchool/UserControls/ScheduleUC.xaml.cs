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
    /// Логика взаимодействия для ScheduleUC.xaml
    /// </summary>
    public partial class ScheduleUC : UserControl
    {
        Schedule schedule;
        public ScheduleUC(Schedule _schedule)
        {
            InitializeComponent();
            schedule = _schedule;
            DataContext = schedule;
            if (schedule.IsAvailable == 1 && DateTime.Now >= schedule.Date)
            {

            }
            else
            {
                this.IsEnabled = false;
                DateTb.Text = "Откроется " + schedule.Date;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new LessonPage(schedule));
        }

    }
}
