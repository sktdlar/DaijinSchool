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
using System.Windows.Threading;

namespace DaijinSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChatWithFollowersPage.xaml
    /// </summary>
    public partial class ChatWithFollowersPage : Page
    {
        public ChatWithFollowersPage(Courses courses)
        {
            InitializeComponent();
            App.chatWithFollowersPage = this;
            foreach(var item in App.db.ListOfCourses.ToList().Where(x => x.CourseId == courses.id))
            {
                FollowersWP.Children.Add(new UserWP(item.UserDB));
            }
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
        public void Refresh()
        {
            Messages.Children.Clear();
            if (App.chatWithFollowersPage != null)
            {
                foreach (var item in App.db.Messages.ToList().Where(x => x.ChatId == App.chat.id))
                {
                    App.chatWithFollowersPage.Messages.Children.Add(new MessagesUC(item));
                }
                scrollView.ScrollToVerticalOffset(scrollView.VerticalOffset + 6000000);
            }
        }

        private void SendMessageBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.Messages.Add(new Models.Messages()
            {
                ChatId = App.chat.id,
                MessageText = MessageTb.Text,
                SenderId = App.CurrentUser.id,
                Timestamp = DateTime.Now,
            });
            App.db.SaveChanges();
            Refresh();
            MessageTb.Text = "";
        }
    }
}
