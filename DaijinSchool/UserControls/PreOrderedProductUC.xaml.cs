using DaijinSchool.Models;
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

namespace DaijinSchool.UserControls
{
    /// <summary>
    /// Логика взаимодействия для PreOrderedProductUC.xaml
    /// </summary>
    public partial class PreOrderedProductUC : UserControl
    {
        public PreOrderedProductUC(PreOrder preOrder)
        {
            InitializeComponent();
            DataContext = preOrder;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Отложено в оффлайн магазине Daijin");
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Отложено в оффлайн магазине Daijin");
        }
    }
}
