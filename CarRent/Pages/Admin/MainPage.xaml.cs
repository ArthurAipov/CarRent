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

namespace CarRent.Pages.Admin
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonUsers_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.NavigationService.Navigate(new UsersPage());
        }

        private void ButtonExite_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ButtonCars_Click(object sender, RoutedEventArgs e)
        {
            AdminFrame.NavigationService.Navigate(new CarsAdminPage());
        }

        private void ButtonModels_Click(object sender, RoutedEventArgs e)
        {
           AdminFrame.NavigationService.Navigate(new ModelsPage());
        }
    }
}
