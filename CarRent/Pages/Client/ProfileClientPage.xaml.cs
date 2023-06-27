using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CarRent.Pages.Client
{
    /// <summary>
    /// Interaction logic for ProfileClientPage.xaml
    /// </summary>
    public partial class ProfileClientPage : Page
    {
        bool IsAdmin = false;
        bool IsAdd = true;
        DbPropertyValues OldValues;
        DataBase.Client MainClient;
        public ProfileClientPage(bool Admin)
        {
            InitializeComponent();
            if (Admin)
            {
                TextBoxName.IsEnabled = false;
                TextBoxPassportData.IsEnabled = false;
                TextBoxPhone.IsEnabled = false; 
                ComboBoxCity.IsEnabled = false;
                IsAdmin = Admin;
                ButtonSave.Visibility = Visibility.Hidden;
            }
            MainClient = GlobalSettings.MainClient;
            if (MainClient.Id != 0)
            {
                IsAdd = false;
                OldValues = GlobalSettings.DB.Entry(MainClient).CurrentValues.Clone();
            }
            ComboBoxCity.ItemsSource = GlobalSettings.DB.City.ToList();
            DataContext = MainClient;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = "";
            var client = DataContext as DataBase.Client;
            if (client.PassportData == null)
                errorMessage += "Enter passport data \n";
            else
            {
                var pattern = @"^[0-9]{10}$";
                if (!Regex.IsMatch(client.PassportData, pattern))
                {
                    errorMessage += "Enter Correct PassportData \n";
                }
            }
            if (client.FullName == null)
                errorMessage += "Enter full name\n";
            if (client.City == null)
                errorMessage += "Select city\n";
            if (client.Phone == null)
                errorMessage += "Enter phone\n";
            else
            {
                var pattern = @"^[0-9]{13}$";
                if (!Regex.IsMatch(client.Phone, pattern))
                {
                    errorMessage += "Enter Correct phone \n";
                }
            }
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            if (IsAdd)
            {
                GlobalSettings.DB.Client.Add(client);
            }

            GlobalSettings.DB.SaveChanges();
            GlobalSettings.MainClient = client;
            NavigationService.GoBack();

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdmin)
            {
                if (!IsAdd)
                {
                    var client = DataContext as DataBase.Client;
                    GlobalSettings.DB.Entry(client).CurrentValues.SetValues(OldValues);
                }
            }
            NavigationService.GoBack();
        }
    }
}
