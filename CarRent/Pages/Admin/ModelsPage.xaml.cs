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
    /// Interaction logic for ModelsPage.xaml
    /// </summary>
    public partial class ModelsPage : Page
    {
        public ModelsPage()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            DataGridModels.ItemsSource = GlobalSettings.DB.Model.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditeModel(new Model()));
        }

        private void ButtonEdite_Click(object sender, RoutedEventArgs e)
        {
            var model = DataGridModels.SelectedItem as Model;
            if(model == null)
            {
                MessageBox.Show("Select model");
                return;
            }

            NavigationService.Navigate(new AddEditeModel(model));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
