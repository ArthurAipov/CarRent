using CarRent.DataBase;
using CarRent.Models;
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

namespace CarRent.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = "";
            if (string.IsNullOrWhiteSpace(TextBoxLogin.Text))
                errorMessage += "Enter Login \n";
            if (string.IsNullOrWhiteSpace(TextBoxPassword.Text))
                errorMessage += "Enter Password";
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            var user = GlobalSettings.DB.User.FirstOrDefault(u => u.Login == TextBoxLogin.Text);
            if(user != null)
            {
                MessageBox.Show("Enter new login");
                return;
            }
            var newUser = new User() { Login = TextBoxLogin.Text, Password = TextBoxPassword.Text, RoleId = 2 };
            GlobalSettings.DB.User.Add(newUser);
            GlobalSettings.DB.SaveChanges();
            NavigationService.GoBack();


        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
