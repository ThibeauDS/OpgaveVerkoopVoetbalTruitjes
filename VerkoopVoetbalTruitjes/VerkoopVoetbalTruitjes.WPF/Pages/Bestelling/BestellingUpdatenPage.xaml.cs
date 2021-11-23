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

namespace VerkoopVoetbalTruitjes.WPF.Pages.Bestelling
{
    /// <summary>
    /// Interaction logic for BestellingUpdatenPage.xaml
    /// </summary>
    public partial class BestellingUpdatenPage : Page
    {
        #region Properties
        private Domain.Klassen.Bestelling _geselecteerdeBestellingUpdate = (Domain.Klassen.Bestelling)Application.Current.Properties["GeselecteerdeBestellingenUpdate"];
        #endregion

        public BestellingUpdatenPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Customer.Text = _geselecteerdeBestellingUpdate.Klant.ToString();
        }

        private void SelectCustomerBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SelectTruitjeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridTruitjes_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteVoetbaltruitje_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Price_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
