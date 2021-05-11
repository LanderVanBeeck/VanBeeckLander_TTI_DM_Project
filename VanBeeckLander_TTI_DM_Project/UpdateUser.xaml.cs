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
        User UserUpdate = new User();
        public UpdateUser(int userid)
        {  
            InitializeComponent();
            UserUpdate.userId = userid;
            UserUpdate = DatabaseOperations.OphalenUserOpUserID(userid);

        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lijstTalen.Add("Nederlands");
            lijstTalen.Add("Frans");
            lijstTalen.Add("Engels");
            txtUsername.Text = UserUpdate.username;
            txtDisplayname.Text = UserUpdate.displayname;
            txtPassword.Text = UserUpdate.password;
            txtMail.Text = UserUpdate.mail;
            txtBio.Text = UserUpdate.bio;
            txtTitle.Text = UserUpdate.title;
            cmbLanguage.ItemsSource = lijstTalen;
            cmbLanguage.SelectedItem = UserUpdate.language;
            

            
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
