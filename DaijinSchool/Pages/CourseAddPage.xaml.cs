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

namespace DaijinSchool.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CourseAddPage.xaml
    /// </summary>
    public partial class CourseAddPage : Page
    {
        Courses courses;
        public CourseAddPage( Courses _courses)
        {
            courses = _courses;
            DataContext = courses;
            InitializeComponent();
            CategoryCB.ItemsSource = App.db.Category.ToList().Where(x => x.InstructorId == App.CurrentUser.id);
            CategoryCB.DisplayMemberPath = "Name";
            if(courses.id > 0)
            {
                CategoryCB.IsEnabled = false;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                ImageEdit.Source = LoadImage(selectedFilePath);
                courses.Image = ConvertBitmapImageToByteArray(LoadImage((selectedFilePath)));
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
        private void ImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                ImageEdit.Source = LoadImage(selectedFilePath);
                courses.Image = ConvertBitmapImageToByteArray(LoadImage(selectedFilePath));
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

        private void AddCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if(courses.Name.Length > 0 && courses.Description.Length > 0 && courses.Duration > 0 && courses.CategoryId != null)
            {
                if(courses.id == 0)
            App.db.Courses.Add(courses);
            App.db.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Пожалуйста введите полные данные");
            }
        }
    }
}
