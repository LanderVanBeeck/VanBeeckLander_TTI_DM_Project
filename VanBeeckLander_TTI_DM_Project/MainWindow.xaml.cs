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
using Twitch_DAL;
using Twitch_Models;

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
            btnCreateUser.IsEnabled = false;
            btnUpdateUser.IsEnabled = false;
            btnDeleteUser.IsEnabled = false;
            ZoekOpDisplayname.IsEnabled = false;
            ZoekOpTaal.IsEnabled = false;
        }

        private void btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            CreateUser w2 = new CreateUser();
            w2.ShowDialog();
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            if (DataUsers.SelectedIndex!=-1)
            {
                UpdateUser w2 = new UpdateUser();
                w2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a user to update", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (DataUsers.SelectedIndex!=-1)
            {
                
            }
            else
            {
                MessageBox.Show("Please select a user to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ZoekOpDisplayname_Click(object sender, RoutedEventArgs e)
        {
            DataUsers.ItemsSource = DatabaseOperations.OphalenUsersOpDisplayname(txtZoekViaDisplayname.Text);
        }

        private void ZoekOpTaal_Click(object sender, RoutedEventArgs e)
        {
            DataUsers.ItemsSource = DatabaseOperations.OphalenUsersOpTaal(cmbLanguage.Text);
        }

        private void btnShowUsers_Click(object sender, RoutedEventArgs e)
        {
            DataUsers.ItemsSource = DatabaseOperations.OphalenUsers();
            btnCreateUser.IsEnabled = true;
            btnUpdateUser.IsEnabled = true;
            btnDeleteUser.IsEnabled = true;
            ZoekOpDisplayname.IsEnabled = true;
            ZoekOpTaal.IsEnabled = true;
        }
    }
}
