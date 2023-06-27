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

namespace CarRent.Pages.Client
{
    /// <summary>
    /// Interaction logic for MainPageClient.xaml
    /// </summary>
    public partial class MainPageClient : Page
    {
        public MainPageClient()
        {
            InitializeComponent();
           
        }

        private void ButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileClientPage(false));

        }

        private void buttonCars_Click(object sender, RoutedEventArgs e)
        {
            MainFrameClient.NavigationService.Navigate(new CarsClientPage());
        }

        private void ButtonExite_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ButtonPass_Click(object sender, RoutedEventArgs e)
        {
            if(GlobalSettings.MainClient.Id == 0)
            {
                MessageBox.Show("fill the client form");
                return;
            }
            MainFrameClient.NavigationService.Navigate(new PassListPage());
        }
    }
}
