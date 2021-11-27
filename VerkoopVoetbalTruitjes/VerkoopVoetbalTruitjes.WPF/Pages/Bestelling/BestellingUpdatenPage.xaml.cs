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
            Customer.Text = _geselecteerdeBestellingUpdate.Klant.ToText(true);
            IsPayed.IsChecked = _geselecteerdeBestellingUpdate.Betaald;
            Price.Text = _geselecteerdeBestellingUpdate.Prijs.ToString();
        }

        private void SelectCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Bestelling/BestellingKlantSelecterenPage.xaml", UriKind.Relative));
        }

        private void SelectTruitjeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Bestelling/BestellingTruitjeSelecterenPage.xaml", UriKind.Relative));
        }

        private void DataGridTruitjes_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<KeyValuePair<Domain.Klassen.Voetbaltruitje, int>> oc = new();
            if (_geselecteerdeBestellingUpdate.GeefProducten() != null && _geselecteerdeBestellingUpdate.GeefProducten().Count != 0)
            {
                foreach (var truitje in _geselecteerdeBestellingUpdate.GeefProducten())
                {
                    oc.Add(truitje);
                }
                DataGridTruitjes.ItemsSource = oc;
                Price_Loaded(sender, e);
            }
            else
            {
                oc.Clear();
                DataGridTruitjes.ItemsSource = oc;
            }
        }

        private void DeleteVoetbaltruitje_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<Domain.Klassen.Voetbaltruitje, int> truitjes = new();
                truitjes = (Dictionary<Domain.Klassen.Voetbaltruitje, int>)_geselecteerdeBestellingUpdate.GeefProducten();
                var x = (KeyValuePair<Domain.Klassen.Voetbaltruitje, int>)DataGridTruitjes.CurrentItem;
                Domain.Klassen.Voetbaltruitje voetbaltruitje = x.Key;
                truitjes.Remove(voetbaltruitje);
                Application.Current.Properties["GeselecteerdeBestellingenUpdate"] = truitjes;
                MessageBox.Show("Truitje is verwijderd uit de bestelling", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                DataGridTruitjes_Loaded(sender, e);
                Price_Loaded(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.bestellingBeheerder.BestellingUpdaten(_geselecteerdeBestellingUpdate);
                Application.Current.Properties["GeselecteerdeBestellingenUpdate"] = null;
                Application.Current.Properties["Klant"] = null;
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Price_Loaded(object sender, RoutedEventArgs e)
        {
            Dictionary<Domain.Klassen.Voetbaltruitje, int> truitjes = new();
            truitjes = (Dictionary<Domain.Klassen.Voetbaltruitje, int>)_geselecteerdeBestellingUpdate.GeefProducten();
            if (truitjes != null)
            {
                double price = 0;
                foreach (var item in truitjes.Keys)
                {
                    price += item.Prijs * truitjes[item];
                }
                Price.Text = price.ToString("F2");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["GeselecteerdeBestellingenUpdate"] = null;
            Application.Current.Properties["Klant"] = null;
            NavigationService.GoBack();
        }
    }
}
