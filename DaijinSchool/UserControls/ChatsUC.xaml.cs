using DaijinSchool.Models;
using System;
using System.Collections;
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
    /// Логика взаимодействия для ChatsUC.xaml
    /// </summary>
    public partial class ChatsUC : UserControl
    {
        Chats chat;
        public ChatsUC(Chats _chat)
        {
            InitializeComponent();
            chat = _chat;
            if(chat.UserDB != App.CurrentUser)
            {
                BitmapImage imageSource = new BitmapImage();
                if(chat.UserDB.Image != null)
                {
                using (MemoryStream stream = new MemoryStream(chat.UserDB.Image))
                {
                    imageSource.BeginInit();
                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
                    imageSource.StreamSource = stream;
                    imageSource.EndInit();
                }
                AvatarImg.Source = imageSource;

                }
                FIOTb.Text = chat.UserDB.FIO;
            }
            else
            {
                BitmapImage imageSource = new BitmapImage();

                using (MemoryStream stream = new MemoryStream(chat.UserDB1.Image))
                {
                    imageSource.BeginInit();
                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
                    imageSource.StreamSource = stream;
                    imageSource.EndInit();
                }
                AvatarImg.Source = imageSource;
                FIOTb.Text = chat.UserDB1.FIO;
            }
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.chat = chat;
            App.chatsPage.Refresh();
            App.chatsPage.MessageTypingGrid.Visibility = Visibility.Visible;    
            App.chatsPage.scrollView.ScrollToVerticalOffset(App.chatsPage.scrollView.VerticalOffset + 20000);
        }
    }
}
