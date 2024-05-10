using DaijinSchool.Models;
using DaijinSchool.UserControls;
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
    /// Логика взаимодействия для AddEditProdPage.xaml
    /// </summary>
    public partial class AddEditProdPage : Page
    {
        Product product;
        public AddEditProdPage(Product _product)
        {
            InitializeComponent();
            product = _product;
            DataContext = product;
            CategoryTb.ItemsSource = App.db.ProductCategory.ToList();
            CategoryTb.DisplayMemberPath = "Name";
            ProductWP.Children.Add(new ProductAddEditUC(product));
            if(product.id != 0)
            {
                TitlePageTb.Content = "Изменение товара";
                SaveBtn.Content = "Сохранить";
            }
        }

        private void NameProd_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductWP.Children.Clear();
            ProductWP.Children.Add(new ProductAddEditUC(product));
        }

        private void DescriptionTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductWP.Children.Clear();
            ProductWP.Children.Add(new ProductAddEditUC(product));

        }

        private void PriceTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductWP.Children.Clear();
            ProductWP.Children.Add(new ProductAddEditUC(product));
        }

        private void CategoryTb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductWP.Children.Clear();
            ProductWP.Children.Add(new ProductAddEditUC(product));
        }

        private void DescriptionTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if(textBox.Text.Length >= 150)
            {
                e.Handled = true;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(product.Name?.Length > 0 && product.Description?.Length > 0 && product.ProductCategory != null && product.Price != null)
            {
                if(product.id == 0)
                {
                    product.CategoryId = product.ProductCategory.id;
                    App.db.Product.Add(product);
                }
                App.db.SaveChanges();
                NavigationService.GoBack();
            }
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                ImageProd.Source = LoadImage(selectedFilePath);
                product.Image = ConvertBitmapImageToByteArray(LoadImage(selectedFilePath));
                ProductWP.Children.Clear();
                ProductWP.Children.Add(new ProductAddEditUC(product));
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
