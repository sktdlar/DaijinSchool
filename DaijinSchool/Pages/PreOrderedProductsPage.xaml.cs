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
    /// Логика взаимодействия для PreOrderedProductsPage.xaml
    /// </summary>
    public partial class PreOrderedProductsPage : Page
    {
        public PreOrderedProductsPage()
        {
            InitializeComponent();
            foreach(var item in App.db.PreOrder.ToList().Where(x => x.UserId == App.CurrentUser.id))
            {
                ProductsWP.Children.Add(new PreOrderedProductUC(item));
            }
        }
    }
}
