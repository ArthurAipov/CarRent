using CarRent.DataBase;
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

namespace CarRent.Pages.Admin
{
    /// <summary>
    /// Interaction logic for AddEditeModel.xaml
    /// </summary>
    public partial class AddEditeModel : Page
    {
        bool IsAdd = true;
        DbPropertyValues OldValues;
        public AddEditeModel(DataBase.Model model)
        {
            InitializeComponent();
            if (model.Id != 0)
            {
                OldValues = GlobalSettings.DB.Entry(model).CurrentValues.Clone();
                IsAdd = false;
            }
            ComboBoxBrend.ItemsSource = GlobalSettings.DB.Brend.ToList();
            ComboBoxModelType.ItemsSource = GlobalSettings.DB.ModelType.ToList();
            ComboBoxTransmissionBox.ItemsSource = GlobalSettings.DB.TransmissionBox.ToList();
            DataContext = model;

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (!IsAdd)
            {
                var model = DataContext as Model;
                GlobalSettings.DB.Entry(model).CurrentValues.SetValues(OldValues);
            }
            NavigationService.GoBack();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = "";
            var model = DataContext as Model;
            if (model.Name == null)
                errorMessage += "Enter Name \n";
            if (model.Horsepower.ToString() == null || model.Horsepower == 0)
                errorMessage += "enter horsepower \n";
            else
            {
                var pattern = @"[0-9]$";
                if (!Regex.IsMatch(model.Horsepower.ToString(), pattern))
                {
                    errorMessage += "Enter correct horsepower \n";
                }
            }
            if (model.EngineCapacity == null || model.EngineCapacity.Length != 3)
                errorMessage += "enter EngineCapacity\n";
            else
            {
                var engineCapacity = model.EngineCapacity;
                var pattern = @"[0-9]$";
                if (!Regex.IsMatch(engineCapacity[0].ToString(), pattern) ||
                    engineCapacity[1].ToString() != "." ||
                    !Regex.IsMatch(engineCapacity[0].ToString(), pattern))
                {
                    errorMessage += "Enter correct EngineCapacity \n";
                }
            }

            if (model.ModelType == null)
                errorMessage += "select Type\n";
            if (model.TransmissionBox == null)
                errorMessage += "select TransmissionBox\n";
            if (model.Brend == null)
                errorMessage += "select Brend\n";
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            if (IsAdd)
            {
                GlobalSettings.DB.Model.Add(model);
            }

            GlobalSettings.DB.SaveChanges();
            NavigationService.GoBack();


        }
    }
}
