﻿using DaijinSchool.Models;
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
    /// Логика взаимодействия для FeedBackUC.xaml
    /// </summary>
    public partial class FeedBackUC : UserControl
    {
        public FeedBackUC(Comments comments)
        {
            InitializeComponent();
            DataContext = comments;
            FIOTb.Text = comments.UserDB.FIO;
        }
    }
}
