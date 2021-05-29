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
using System.Windows.Shapes;
using Twitch_DAL;
using Twitch_Models;


namespace VanBeeckLander_TTI_DM_Project
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        List<string> lijstTalen = new List<string>();
        User userCreate = new User();
        public CreateUser()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lijstTalen.Add("Nederlands");
            lijstTalen.Add("Frans");
            lijstTalen.Add("Engels");
            cmbLanguage.ItemsSource = lijstTalen;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            #region Validation
            string foutmeldingen = Validation("Username");
            foutmeldingen += Validation("Displayname");
            foutmeldingen += Validation("Password");
            foutmeldingen += Validation("Mail");
            foutmeldingen += Validation("Bio");
            foutmeldingen += Validation("Title");
            foutmeldingen += Validation("Language");
            #endregion

            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                User userCreate = new User();
                userCreate.username = txtUsername.Text;
                userCreate.displayname = txtDisplayname.Text;
                userCreate.password = txtPassword.Text;
                userCreate.mail = txtMail.Text;
                userCreate.bio = txtBio.Text;
                userCreate.title = txtTitle.Text;
                userCreate.language = cmbLanguage.Text;

                
                
                    int ok = DatabaseOperations.ToevoegenUser(userCreate);

                    if (ok > 0)
                    {
                        MessageBox.Show("Gebruiker is succesvol toegevoegd!");
                    this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Gebruiker is niet toegevoegd, controleer uw velden!");
                    }
                
            }
        }

        private string Validation(string columnName)
        {
            if (columnName == "Language" && cmbLanguage.SelectedItem == null)
            {
                return "Kies een taal!" + Environment.NewLine;
            }
            return "";
        }
    }
}
