using DaijinSchool.Models;
using DaijinSchool.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DaijinSchool
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DaidjinSchoolEntities db = new DaidjinSchoolEntities();
        public static UserDB CurrentUser;
        public static MainWindow mainWindow;
        public static ChatsPage chatsPage;
        public static Chats chat;
        public static ChatWithFollowersPage chatWithFollowersPage;
        public static AdminProdsPage adminProdsPage;
        public static ShopPage ShopPage;
        public static ChatsPage ChatsPage;
    }
}
