using CarRent.DataBase;
using CarRent.Models;
using CarRent.Pages;
using System;
using System.Collections.Generic;
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

namespace CarRent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            //var firsNumber = "T076TM116";
            //var secondNumber = "T766TM116";
            //var thirdNumber = "T176TM116";
            //var fourthNumber = "T186TM116";

            //var numberList = new List<string> { firsNumber, secondNumber, thirdNumber, fourthNumber };
            //var i = 0;
            //foreach (var model in GlobalSettings.DB.Model)
            //{
            //    var number = numberList[i];
            //    var modelId = model.Id;
            //    var price = random.Next(1500, 4000);
            //    var newCar = new Car() { ModelId = modelId, Number = number, Price = price };
            //    i++;
            //    GlobalSettings.DB.Car.Add(newCar);
            //}
            //GlobalSettings.DB.SaveChanges();
            var files = Directory.GetFiles(@"C:\Users\aipov\OneDrive\Изображения\Cars");
            foreach (var car in GlobalSettings.DB.Car)
            {
                var file = files.FirstOrDefault(f => f.Contains(car.ModelId.ToString()));
                if (file != null)
                {
                    var bytes = File.ReadAllBytes(file);
                    car.Photo = bytes;
                }
            }
            GlobalSettings.DB.SaveChanges();
            MainFrame.NavigationService.Navigate(new AutorizationPage());

        }
    }
}
