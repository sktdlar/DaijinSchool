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
    /// Логика взаимодействия для MainEditProfilePage.xaml
    /// </summary>
    public partial class MainEditProfilePage : Page
    {
        public MainEditProfilePage()
        {
            InitializeComponent();
            DataContext = App.db.UserDB.Find(App.CurrentUser.id);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            

        }
        private void ImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                ImageEdit.Source = LoadImage(selectedFilePath);
                App.db.UserDB.Find(App.CurrentUser.id).Image = ConvertBitmapImageToByteArray(LoadImage((selectedFilePath)));
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

        private void SaveChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.SaveChanges();
            NavigationService.GoBack();
        }


    }
        
}

