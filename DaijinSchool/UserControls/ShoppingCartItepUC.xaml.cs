using DaijinSchool.Models;
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
    /// Логика взаимодействия для ShoppingCartItepUC.xaml
    /// </summary>
    public partial class ShoppingCartItepUC : UserControl
    {
        ShoppingCartItem ShoppingCartItem;
        public ShoppingCartItepUC(ShoppingCartItem shoppingCartItem)
        {
            InitializeComponent();
            ShoppingCartItem = shoppingCartItem;
            DataContext = ShoppingCartItem; 
            if(ShoppingCartItem.Product.Image != null )
            {
            BitmapImage bitmapImage = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(shoppingCartItem.Product.Image))
                {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                }
                ImageImg.Source = bitmapImage;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
