using CarRent.Models;
using CarRent.Pages.Client;
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
    /// Interaction logic for AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = "";
            if (string.IsNullOrWhiteSpace(TextBoxLogin.Text))
                errorMessage += "Enter Login \n";
            if (string.IsNullOrWhiteSpace(TextBoxPassword.Text))
                errorMessage += "Enter Password \n";
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            var user = GlobalSettings.DB.User.FirstOrDefault(u => u.Password == TextBoxPassword.Text && u.Login == TextBoxLogin.Text);
            if (user == null)
            {
                MessageBox.Show("Wrong Password or Login");
                return;
            }

            if (user.RoleId == 1)
            {
                NavigationService.Navigate(new Admin.MainPage());
            }

            if (user.RoleId == 2)
            {
                var client = GlobalSettings.DB.Client.FirstOrDefault(u => u.UserId == user.Id);
                if (client != null)
                    GlobalSettings.MainClient = client;
                else
                    GlobalSettings.MainClient = new DataBase.Client() { UserId = user.Id};
                NavigationService.Navigate(new MainPageClient());
            }

        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
