using DaijinSchool.Models;
using DaijinSchool.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для UserWP.xaml
    /// </summary>
    public partial class UserWP : UserControl
    {
        UserDB user;
        public UserWP(UserDB userDB)
        {
            InitializeComponent(); 
            user = userDB;
            BitmapImage imageSource = new BitmapImage();
            if(userDB.Image != null )
            {
            using (MemoryStream stream = new MemoryStream(userDB.Image))
            {
                imageSource.BeginInit();
                imageSource.CacheOption = BitmapCacheOption.OnLoad;
                imageSource.StreamSource = stream;
                imageSource.EndInit();
            }
            AvatarImg.Source = imageSource;

            }
            FIOTb.Text = userDB.FIO;
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool done = false;
            foreach (var item in App.db.Chats.ToList())
            {
                if (App.chatWithFollowersPage != null)
                {
                    if ((item.User1Id == user.id && item.User2Id == App.CurrentUser.id) || (item.User2Id == user.id && item.User1Id == App.CurrentUser.id))
                    {
                        App.chat = App.db.Chats.ToList().First(x => (x.User1Id == App.CurrentUser.id && x.User2Id == user.id) || (x.User1Id == user.id && x.User2Id == App.CurrentUser.id));
                        App.chatWithFollowersPage.Refresh();
                        App.chatWithFollowersPage.MessageTypingGrid.Visibility = Visibility.Visible;
                        App.chatWithFollowersPage.scrollView.ScrollToVerticalOffset(App.chatWithFollowersPage.scrollView.VerticalOffset + 20000);
                        done = true;
                        break;
                    }
                }
            }
            foreach (var item in App.db.Chats.ToList())
            {
                    if ((item.User1Id == user.id && item.User2Id == App.CurrentUser.id) || (item.User2Id == user.id && item.User1Id == App.CurrentUser.id))
                    {
                        App.chat = App.db.Chats.ToList().First(x => (x.User1Id == App.CurrentUser.id && x.User2Id == user.id) || (x.User1Id == user.id && x.User2Id == App.CurrentUser.id));
                        done = true;
                        break;
                    }
            }
            if (!done)
            {
                App.db.Chats.Add(new Chats()
                {
                    User1Id = user.id,
                    User2Id = App.CurrentUser.id,
                });
                App.db.SaveChanges();
            }
            App.chat = App.db.Chats.ToList().First(x => (x.User1Id == App.CurrentUser.id && x.User2Id == user.id) || (x.User1Id == user.id && x.User2Id == App.CurrentUser.id));
            if (App.chatWithFollowersPage != null)
            {
                App.chatWithFollowersPage.Refresh();
                App.chatWithFollowersPage.MessageTypingGrid.Visibility = Visibility.Visible;
                App.chatWithFollowersPage.scrollView.ScrollToVerticalOffset(App.chatWithFollowersPage.scrollView.VerticalOffset + 20000);
            }
            if (App.chatsPage != null)
            {
                App.chatsPage.Refresh();
                foreach (var item in App.db.Messages.ToList().Where(x => x.ChatId == App.chat.id))
                {
                    App.chatsPage.Messages.Children.Add(new MessagesUC(item));
                }
                App.chatsPage.UsersMessagesWP.Children.Clear();
                foreach (var item in App.db.Chats.ToList().Where(x => x.UserDB1 == App.CurrentUser || x.UserDB == App.CurrentUser))
                {
                    App.chatsPage.UsersMessagesWP.Children.Add(new ChatsUC(item));
                }
                App.chatsPage.SearchTb.Text = "";
            }
        }
    }
}
