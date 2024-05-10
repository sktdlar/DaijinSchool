using DaijinSchool.Models;
using Microsoft.Win32;
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

namespace DaijinSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        UserDB user = null;
        int part = 0;
        public RegPage(UserDB _user)
        {
            InitializeComponent();
            user = _user;
            DataContext = user;
            RoleCb.ItemsSource = App.db.Role.ToList().Where(x => x.id != 1);
            RoleCb.DisplayMemberPath = "Name";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(part == 0)
            {
                if(user.FirstName?.Length > 0 && user.LastName?.Length > 0 && user.Patronymic?.Length > 0 && user.Role?.id > 1)
                {
                    FirstPart.Visibility = Visibility.Collapsed;
                    SeccondPart.Visibility = Visibility.Visible;
                    SaveBtn.Content = "Завершить регистрацию";
                    part++;
                }
                else
                {
                    MessageBox.Show($"Пожалуйста заполните свои ФИО и Выберите роль на платформе") ;
                }
            }
            if(part == 1)
            {
                if (user.Password == Pass2.Text && user.Password?.Length > 0 && user.Email?.Length > 0)
                {
                    if(App.db.UserDB.Where(x => x.Email == user.Email).Any())
                    {
                        MessageBox.Show("Пользователь с данной почтой уже зарегистрирован");
                    }
                    else
                    {
                        App.db.UserDB.Add(user);
                        App.db.SaveChanges();
                        NavigationService.Navigate(new AuthPage());
                    }
                }
            }
        }

        private void Pass2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(pass.Text == Pass2.Text)
            {
                Pass2.Background = System.Windows.Media.Brushes.LightGreen;
            }
            else
            {
                Pass2.Background = null;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                ImageEdit.Source = LoadImage(selectedFilePath);
                user.Image = ConvertBitmapImageToByteArray(LoadImage(selectedFilePath));
            }
        }
        private BitmapImage LoadImage(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = fileStream;
                    bitmapImage.EndInit();
                    return bitmapImage;
                }
            }
            catch
            {
                return null;
            }
        }
        public byte[] ConvertBitmapImageToByteArray(BitmapImage bitmapImage)
        {
            byte[] byteArray = null;
            if (bitmapImage != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                    encoder.Save(memoryStream);

                    byteArray = memoryStream.ToArray();
                }
            }
            return byteArray;
        }
    }
}
