using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for BestellingToevoegenPage.xaml
    /// </summary>
    public partial class BestellingToevoegenPage : Page
    {
        #region Properties
        private Domain.Klassen.Klant _klantString = (Domain.Klassen.Klant)Application.Current.Properties["Klant"];
        //TODO: Hoe een truitje verplaatsen van SelecteerTruitje naar BestellingToevoegen
        private ObservableCollection<Domain.Klassen.Voetbaltruitje> _truitjes = (ObservableCollection<Domain.Klassen.Voetbaltruitje>)Application.Current.Properties["Truitjes"];
        #endregion

        public BestellingToevoegenPage()
        {
            InitializeComponent();
        }

        private void SelectCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Bestelling/BestellingKlantSelecterenPage.xaml", UriKind.Relative));
        }

        private void SelectTruitjeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Bestelling/BestellingTruitjeSelecterenPage.xaml", UriKind.Relative));
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["Klant"] = null;
            if (_klantString != null)
            {
                Customer.Text = _klantString.ToString();
            }
            //TODO: Oplossen hoe de datagrid niet word leeggemaakt
            DataGridTruitjes.ItemsSource = _truitjes;
        }

        private void Price_Loaded(object sender, RoutedEventArgs e)
        {
            if (_truitjes != null)
            {
                Price.Text = _truitjes[0].Prijs.ToString();
            }
        }
    }
}
