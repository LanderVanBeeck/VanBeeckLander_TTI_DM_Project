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
            List<string> lijstTalen = new List<string>();
            lijstTalen.Add("Nederlands");
            lijstTalen.Add("Frans");
            lijstTalen.Add("Engels");
            btnCreateUser.IsEnabled = false;
            btnUpdateUser.IsEnabled = false;
            btnDeleteUser.IsEnabled = false;
            ZoekOpDisplayname.IsEnabled = false;
            ZoekOpTaal.IsEnabled = false;
            cmbLanguage.ItemsSource = lijstTalen;
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
                MessageBox.Show("Selecteer een user om te updaten!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Validation("User");
            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                User user = DataUsers.SelectedItem as User;
                string displayname = user.displayname;

                int oke = DatabaseOperations.DeleteUser(user);
                if (oke > 0)
                {
                    DataUsers.SelectedItem = DatabaseOperations.OphalenUsers();
                    Reset();
                }
                else
                {
                    MessageBox.Show("User is niet verwijderd!");
                }
            }
            else
            {
                MessageBox.Show(foutmeldingen);
            }
        }

        private void ZoekOpDisplayname_Click(object sender, RoutedEventArgs e)
        {
            if (txtZoekViaDisplayname.Text!="")
            {
                DataUsers.ItemsSource = DatabaseOperations.OphalenUsersOpDisplayname(txtZoekViaDisplayname.Text);
            }
            else
            {
                MessageBox.Show("Vul een displayname in", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ZoekOpTaal_Click(object sender, RoutedEventArgs e)
        {
            if (cmbLanguage.SelectedIndex!=-1)
            {
                DataUsers.ItemsSource = DatabaseOperations.OphalenUsersOpTaal(cmbLanguage.Text);
            }
            else
            {
                MessageBox.Show("Selecteer een taal!","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
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

        private string Validation(string columnName)
        {
            if (columnName == "User" && DataUsers.SelectedItem == null)
            {
                return "Selecteer een user!" +Environment.NewLine;
            }
            if (columnName == "displayname" && txtZoekViaDisplayname.Text=="")
            {
                return "Vul een user in om te zoeken!";
            }
            if (columnName == "language" && cmbLanguage.SelectedIndex ==-1)
            {
                return "Selecteer een taal!";
            }
            return "";
        }

        private void Reset()
        {
            DataUsers.SelectedIndex = -1;
            txtZoekViaDisplayname.Text = "";
            cmbLanguage.SelectedIndex = -1;
            cmbLanguage.IsEnabled = true;
        }
    }
}
