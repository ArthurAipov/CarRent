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

namespace CarRent.Pages.Admin
{
    /// <summary>
    /// Interaction logic for CarsAdminPage.xaml
    /// </summary>
    public partial class CarsAdminPage : Page
    {
        public CarsAdminPage()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            DataGridCars.ItemsSource = GlobalSettings.DB.Car.ToList();
        }

        private void ButtonEdite_Click(object sender, RoutedEventArgs e)
        {
            var car = DataGridCars.SelectedItem as Car;
            if(car == null)
            {
                MessageBox.Show("Select Car");
                return;
            }
            NavigationService.Navigate(new AddEditePage(car));
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditePage(new Car()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
