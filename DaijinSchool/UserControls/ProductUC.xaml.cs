using DaijinSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
    /// Логика взаимодействия для ProductUC.xaml
    /// </summary>
    public partial class ProductUC : UserControl
    {
        Product Product;
        Remainder remainder;
        public ProductUC(Remainder product)
        {
            InitializeComponent();
            DataContext = product.Product;
            remainder = product;
            Product = product.Product;
            CountTb.Text = product.Count.ToString();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!(App.db.Remainder.First(x => x.id == remainder.id).Count == 0))
            {
                var cartId = App.db.ShoppingCart.Where(x => x.UserId == App.CurrentUser.id).ToList().LastOrDefault()?.id;
                if (App.db.ShoppingCart.Where(x => x.UserId == App.CurrentUser.id).Any() && cartId != null)
                {
                    if (App.db.ShoppingCart.Find(cartId).IsPreOrdered != 0)
                    {
                        App.db.ShoppingCart.Add(new ShoppingCart()
                        {
                            IsPreOrdered = 0,
                            UserId = App.CurrentUser.id,

                        });
                        App.db.SaveChanges();
                        App.db.ShoppingCartItem.Add(new ShoppingCartItem()
                        {
                            ProductId = Product.id,
                            ShoppingCartId = App.db.ShoppingCart.ToList().Last(x => x.UserDB == App.CurrentUser).id,
                            CountOfItem = 1,
                        });
                        App.db.SaveChanges() ;
                        remainder.Count--;
                    }
                    else
                    {
                        bool Finded = false;
                        foreach (ShoppingCartItem cart in App.db.ShoppingCartItem)
                        {
                            if (cart.ProductId == Product.id && cart.ShoppingCartId == cartId)
                            {
                                App.db.ShoppingCartItem.Find(cart.id).CountOfItem++;
                                Finded = true;
                                break;
                            }
                        }
                        App.db.SaveChanges();
                        if (!Finded)
                        {
                            App.db.ShoppingCartItem.Add(new ShoppingCartItem()
                            {
                                ProductId = Product.id,
                                ShoppingCartId = cartId,
                                CountOfItem = 1,
                            });
                        App.db.SaveChanges();
                        remainder.Count--;


                        }
                    }
                }
                else
                {
                    App.db.ShoppingCart.Add(new ShoppingCart()
                    {
                        IsPreOrdered = 0,
                        UserId = App.CurrentUser.id,
                    });
                    App.db.SaveChanges();
                    App.db.ShoppingCartItem.Add(new ShoppingCartItem()
                    {
                        ProductId = Product.id,
                        ShoppingCartId = cartId,
                        CountOfItem = 1,
                    });
                    App.db.SaveChanges();
                App.db.Remainder.First(x => x.ProductId == Product.id).Count--;
                }
                App.db.SaveChanges();
                MessageBox.Show("Товар добавлен в корзину");
                App.ShopPage.ProductsWP.Children.Clear();
                foreach (var prods in App.db.Product.ToList())
                {
                    bool isHere = false;
                    foreach (var remainder in App.db.Remainder.Where(x => x.ProductId == prods.id).ToList())
                    {
                        if (isHere)
                        {

                        }
                        else
                        {
                            isHere = true;
                            if (remainder.Count > 0 && remainder.ProductId == prods.id)
                            {
                                App.ShopPage.ProductsWP.Children.Add(new ProductUC(remainder));
                            }
                        }
                    }
                }
            }
            else
            {
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
