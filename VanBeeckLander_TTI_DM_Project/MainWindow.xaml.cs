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

namespace VanBeeckLander_TTI_DM_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            CreateUser w2 = new CreateUser();
            w2.ShowDialog();
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            UpdateUser w2 = new UpdateUser();
            w2.ShowDialog();
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ZoekOpDisplayname_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ZoekOpTaal_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
