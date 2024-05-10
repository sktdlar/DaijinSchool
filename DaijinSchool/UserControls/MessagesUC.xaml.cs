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

namespace DaijinSchool.UserControls
{
    /// <summary>
    /// Логика взаимодействия для MessagesUC.xaml
    /// </summary>
    public partial class MessagesUC : UserControl
    {
        public MessagesUC(Messages message)
        {
            InitializeComponent();
            DataContext = message;
            FIOTb.Text = message.UserDB.FIO;
            if(message.UserDB == App.CurrentUser)
            {
                FIOTb.Text = "Вы";
            }
        }
    }
}
