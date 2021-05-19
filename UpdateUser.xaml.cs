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
using Twitch_Models;
using Twitch_DAL;

namespace VanBeeckLander_TTI_DM_Project
{
    /// <summary>
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Window
    {
        List<string> lijstTalen = new List<string>();
        User userUpdate = new User();
        public UpdateUser(int userid)
        {
            InitializeComponent();
            userUpdate.userId = userid;
            userUpdate = DatabaseOperations.OphalenUserOpUserID(userid);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lijstTalen.Add("Nederlands");
            lijstTalen.Add("Frans");
            lijstTalen.Add("Engels");
            txtUsername.Text = userUpdate.username;
            txtDisplayname.Text = userUpdate.displayname;
            txtPassword.Text = userUpdate.password;
            txtMail.Text = userUpdate.mail;
            txtBio.Text = userUpdate.bio;
            txtTitle.Text = userUpdate.title;
            cmbLanguage.ItemsSource = lijstTalen;
            cmbLanguage.SelectedItem = userUpdate.language;
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
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
                userUpdate.username = txtUsername.Text;
                userUpdate.displayname = txtDisplayname.Text;
                userUpdate.password = txtPassword.Text;
                userUpdate.mail = txtMail.Text;
                userUpdate.bio = txtBio.Text;
                userUpdate.title = txtTitle.Text;
                userUpdate.language = cmbLanguage.Text;
                int ok = DatabaseOperations.UpdateUser(userUpdate);
                if (ok > 0)
                {
                    MessageBox.Show("Gebruiker is succesvol aangepast");
                }
                else
                {
                    MessageBox.Show("Gebruiker is niet aangepast!");
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string Validation(string columnName)
        {
            if (columnName == "Username" && txtUsername.Text == null)
            {
                return "Vul een username in!" + Environment.NewLine;
            }
            if (columnName == "Displayname" && txtDisplayname.Text == null)
            {
                return "Vul een displayname in!" + Environment.NewLine;
            }
            if (columnName == "Password" && txtPassword.Text == null)
            {
                return "Vul een password in!" + Environment.NewLine;
            }
            if (columnName == "Mail" && txtMail.Text == null)
            {
                return "Vul een mailadres in!" + Environment.NewLine;
            }
            if (columnName == "Bio" && txtBio.Text == null)
            {
                return "Vul een bio in!" + Environment.NewLine;
            }
            if (columnName == "Title" && txtTitle.Text == null)
            {
                return "Vul een title in!" + Environment.NewLine;
            }
            if (columnName == "Language" && cmbLanguage.SelectedItem==null)
            {
                return "Selecteer een taal!" + Environment.NewLine;
            }
            return "";
        }
    }
}
