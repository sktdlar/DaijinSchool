using DaijinSchool.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для LessonMaterialUC.xaml
    /// </summary>
    public partial class LessonMaterialUC : UserControl
    {
        public LessonMaterialUC(ScheduleMaterial scheduleMaterial)
        {
            InitializeComponent();
            DataContext = scheduleMaterial;
            
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(((ScheduleMaterial)DataContext).MaterialURL);
        }
    }
}
