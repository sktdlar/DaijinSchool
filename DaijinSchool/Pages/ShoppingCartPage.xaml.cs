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

namespace DaijinSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShoppingCartPage.xaml
    /// </summary>
    public partial class ShoppingCartPage : Page
    {
        public ShoppingCartPage()
        {
            InitializeComponent();
            ShoppingCart cart = App.db.ShoppingCart.ToList().LastOrDefault(x => x.UserId == App.CurrentUser.id);
                if(cart.UserId == App.CurrentUser.id && cart.IsPreOrdered == 0)
                {
                    foreach (var prods in App.db.ShoppingCartItem.Where(x => x.ShoppingCartId == cart.id).ToList())
                    {
                        ProductsWP.Children.Add(new ShoppingCartItepUC(prods));
                    }
                }
            
            foreach (var item in ProductsWP.Children)
                 {
                     ((ShoppingCartItepUC)item).IsEnabled = false;
                 }
            if(ProductsWP.Children.Count == 0)
            {
                VoidTb.Visibility = Visibility.Visible;
            }
        }

        private void PreOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ProductsWP.Children.Count > 0)
            {
                ShoppingCart cart = App.db.ShoppingCart.ToList().LastOrDefault(x => x.UserId == App.CurrentUser.id);
                if (cart.UserId == App.CurrentUser.id && cart.IsPreOrdered == 0)
                {
                    foreach (var prods in App.db.ShoppingCartItem.Where(x => x.ShoppingCartId == cart.id).ToList())
                    {
                        App.db.PreOrder.Add(new PreOrder()
                        {
                            Count = prods.CountOfItem,
                            ProductId = prods.ProductId,
                            UserId = App.CurrentUser.id,
                            DateOfPreOrder = DateTime.Now,

                        });
                    }
                }
                cart.IsPreOrdered = 1;
                App.db.SaveChanges();
                MessageBox.Show("Предзаказ выполнен успешно! Переход к главной странице...");
                NavigationService.GoBack();
            }
        }
    }
}
