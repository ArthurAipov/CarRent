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

namespace CarRent.Pages.Client
{
    /// <summary>
    /// Interaction logic for CarsClientPage.xaml
    /// </summary>
    public partial class CarsClientPage : Page
    {
        public CarsClientPage()
        {
            InitializeComponent();
            ListViewCars.ItemsSource = GlobalSettings.DB.Car.ToList();
            ComboBoxBrend.ItemsSource = GlobalSettings.DB.Brend.ToList();
            ComboBoxModelType.ItemsSource = GlobalSettings.DB.ModelType.ToList();
        }

        private void Refresh()
        {
            var listCars = GlobalSettings.DB.Car.ToList();
            if (ComboBoxBrend.SelectedItem != null)
            {
                var selectedBrebd = ComboBoxBrend.SelectedItem as Brend;
                listCars = listCars.Where(u => u.Model.BrendId == selectedBrebd.Id).ToList();
            }
            if (!string.IsNullOrWhiteSpace(TextBoxSearch.Text))
            {
                var carName = TextBoxSearch.Text.ToLower();
                listCars = listCars.Where(u => u.Model.Name.ToLower().Contains(carName)).ToList();
            }
            if(ComboBoxModelType.SelectedItem != null)
            {
                var selectedType = ComboBoxModelType.SelectedItem as ModelType;
                listCars = listCars.Where(u => u.Model.ModelTypeId == selectedType.Id).ToList();
            }

            ListViewCars.ItemsSource = listCars;
        }

        private void ComboBoxBrend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void ButtonClearFilter_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxBrend.SelectedItem = null;
            ComboBoxModelType.SelectedItem = null;
            TextBoxSearch.Text = "";
            Refresh();
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void ComboBoxModelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void ListViewCars_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var car = ListViewCars.SelectedItem as Car;
            if(car == null)
            {
                MessageBox.Show("Select car");
                return;
            }
            if(GlobalSettings.MainClient.Id == 0)
            {
                MessageBox.Show("fill the client form");
                return;
            }
            NavigationService.Navigate(new AppPassPage(car));
        }
    }
}
