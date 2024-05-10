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
    /// Логика взаимодействия для ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        public ShopPage()
        {
            InitializeComponent();
            App.ShopPage = this;
            foreach(var prods in App.db.Product.ToList())
            {
                bool isHere = false;
                foreach(var remainder in App.db.Remainder.Where(x => x.ProductId == prods.id).ToList())
                {
                    if (isHere)
                    {

                    }
                    else
                    {
                        isHere = true;
                        if(remainder.Count > 0 && remainder.ProductId == prods.id)
                        {
                            ProductsWP.Children.Add(new ProductUC(remainder));
                        }
                    }
                }
            }
        }
    }
}
