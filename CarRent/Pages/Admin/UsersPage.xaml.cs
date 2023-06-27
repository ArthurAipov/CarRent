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
    /// Interaction logic for UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            DataGridUser.ItemsSource = GlobalSettings.DB.Client.ToList();
        }

        private void DataGridUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var client = DataGridUser.SelectedItem as DataBase.Client;
            if(client == null)
            {
                MessageBox.Show("Select Client");
                return;
            }
            GlobalSettings.MainClient = client;
            NavigationService.Navigate(new ProfileClientPage(true));

        }
    }
}
