﻿using System;
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
using System.Windows.Shapes;

namespace VanBeeckLander_TTI_DM_Project
{
    /// <summary>
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Window
    {
        public UpdateUser()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
