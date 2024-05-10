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
    /// Логика взаимодействия для ChatsPage.xaml
    /// </summary>
    public partial class ChatsPage : Page
    {
        public ChatsPage()
        {
            InitializeComponent();
            App.chatsPage = this;
            foreach (var item in App.db.Chats.ToList().Where(x => x.UserDB1 == App.CurrentUser || x.UserDB == App.CurrentUser))
            {
                UsersMessagesWP.Children.Add(new ChatsUC(item));
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
            int count = Messages.Children.Count;
            if(App.chat != null){

            Messages.Children.Clear();
            if(App.chatsPage != null)
            {
            foreach (var item in App.db.Messages.ToList().Where(x => x.ChatId == App.chat.id))
            {
                Messages.Children.Add(new MessagesUC(item));
            }
            if(Messages.Children.Count != count)
                    {
                        scrollView.ScrollToVerticalOffset(scrollView.VerticalOffset + 6000000);
                    }
                }
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

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SearchTb.Text.Length > 0)
            {
                UsersMessagesWP.Children.Clear();
                foreach(var item in App.db.UserDB.ToList().Where(x => x.Email.ToLower().Contains(SearchTb.Text.ToLower())))
                {
                    UsersMessagesWP.Children.Add(new UserWP(item));
                }
            }
        }
    }
}
