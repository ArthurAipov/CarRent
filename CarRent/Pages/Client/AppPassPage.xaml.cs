using CarRent.DataBase;
using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Interaction logic for AppPassPage.xaml
    /// </summary>
    public partial class AppPassPage : Page
    {
        Car MainCar;
        public AppPassPage(Car car)
        {
            InitializeComponent();
            var pass = new Pass();
            MainCar = car;
            pass.DateStart = DateTime.Now;
            pass.DateUntil = DateTime.Now;
            pass.CarId = car.Id;
            pass.StatusId = 1;
            pass.ClientId = GlobalSettings.MainClient.Id;
            DatePickerDateStart.BlackoutDates.AddDatesInPast();
            DatePickerDateUntil.BlackoutDates.AddDatesInPast();
            DataContext = pass;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = "";
            var pass = DataContext as Pass;
            if (pass.DateStart == null)
                errorMessage += "select start date\n";
            if (pass.DateUntil == null)
                errorMessage += "select end date\n";
            if (pass.Deposit == 0)
                errorMessage += "press the button Show total price\n ";
            if (pass.FinallyPrice == 0)
                errorMessage += "press the button Show total price\n";
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            GlobalSettings.DB.Pass.Add(pass);
            GlobalSettings.DB.SaveChanges();
            NavigationService.GoBack();

        }

        private void ButtonTotalPrice_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = "";
            var pass = DataContext as Pass;
            if (pass.DateStart == null)
                errorMessage += "select start date\n";
            if (pass.DateUntil == null)
                errorMessage += "select end date\n";
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }
            var allDays = 1;
            var days = DatePickerDateUntil.SelectedDate.Value.Date - DatePickerDateStart.SelectedDate.Value.Date;
            if (days.Days != 0)
                allDays = days.Days;
            var totalPrice = MainCar.Price * allDays;
            var deposite = 5000;
            pass.Deposit = deposite;
            pass.FinallyPrice = totalPrice + deposite;
            DataContext = null;
            DataContext = pass;
        }
    }
}
