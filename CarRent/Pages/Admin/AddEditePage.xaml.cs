using CarRent.DataBase;
using CarRent.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
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
    /// Interaction logic for AddEditePage.xaml
    /// </summary>
    public partial class AddEditePage : Page
    {
        bool IsAdd = true;
        DbPropertyValues OldValues;
        public AddEditePage(DataBase.Car car)
        {
            InitializeComponent();
            if(car.Id != 0)
            {
                OldValues = GlobalSettings.DB.Entry(car).CurrentValues.Clone();
                IsAdd = false;
            }
            ComboBoxModel.ItemsSource = GlobalSettings.DB.Model.ToList();
            DataContext = car;
        }

        private void ButtonPhoto_Click(object sender, RoutedEventArgs e)
        {
            var car = DataContext as Car;
            var dialog = new OpenFileDialog() { Filter = ".png, .jpg, .jpeg| *.png; *.jpg; *.jpeg" };
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                var image = File.ReadAllBytes(dialog.FileName);
                car.Photo = image;
                DataContext = null;
                DataContext = car;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = "";
            var car = DataContext as Car;
            if (car.Model == null)
                errorMessage += "Select car\n";
            if (car.Number == null)
                errorMessage += "Enter name\n";
            if (car.Price == 0)
                errorMessage += "enter price\n";
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }
            if (IsAdd)
            {
                GlobalSettings.DB.Car.Add(car);
            }

            GlobalSettings.DB.SaveChanges();
            NavigationService.GoBack();

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdd)
            {
                var car = DataContext as Car;
                GlobalSettings.DB.Entry(car).CurrentValues.SetValues(OldValues);
            }
            NavigationService.GoBack();
        }
    }
}
