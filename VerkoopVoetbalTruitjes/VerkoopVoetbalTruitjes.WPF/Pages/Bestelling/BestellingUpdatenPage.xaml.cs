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
using VerkoopVoetbalTruitjes.Domain.Klassen;

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
            ObservableCollection<VoetbaltruitjesAantal> oc = new();
            if (_geselecteerdeBestellingUpdate.GeefProducten() != null && _geselecteerdeBestellingUpdate.GeefProducten().Count != 0)
            {
                foreach (var truitje in _geselecteerdeBestellingUpdate.GeefProducten())
                {
                    oc.Add(new VoetbaltruitjesAantal(truitje.Key, truitje.Value));
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
                List<VoetbaltruitjesAantal> truitjes = new();
                foreach (var item in _geselecteerdeBestellingUpdate.GeefProducten())
                {
                    truitjes.Add(new VoetbaltruitjesAantal(item.Key, item.Value));
                }
                VoetbaltruitjesAantal x = (VoetbaltruitjesAantal)DataGridTruitjes.CurrentItem;
                foreach (var item in truitjes)
                {
                    if (item.Voetbaltruitje.Equals(x.Voetbaltruitje) && item.Aantal.Equals(x.Aantal))
                    {
                        truitjes.Remove(item);
                        _geselecteerdeBestellingUpdate.VerwijderProduct(item.Voetbaltruitje, item.Aantal);
                        break;
                    }
                }
                Application.Current.Properties["GeselecteerdeBestellingenUpdate"] = _geselecteerdeBestellingUpdate;
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
                MessageBox.Show("Bestelling is geüpdate.", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Price_Loaded(object sender, RoutedEventArgs e)
        {
            PrijsLaden(DictionaryNaarListTruitjes());
        }

        private List<VoetbaltruitjesAantal> DictionaryNaarListTruitjes()
        {
            Dictionary<Domain.Klassen.Voetbaltruitje, int> truitjes = new();
            truitjes = (Dictionary<Domain.Klassen.Voetbaltruitje, int>)_geselecteerdeBestellingUpdate.GeefProducten();
            List<VoetbaltruitjesAantal> voetbaltruitjesAantals = new();
            foreach (var truitje in truitjes)
            {
                voetbaltruitjesAantals.Add(new VoetbaltruitjesAantal(truitje.Key, truitje.Value));
            }
            return voetbaltruitjesAantals;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["GeselecteerdeBestellingenUpdate"] = null;
            Application.Current.Properties["Klant"] = null;
            NavigationService.GoBack();
        }

        private void DataGridTruitjes_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            VoetbaltruitjesAantal v = (VoetbaltruitjesAantal)DataGridTruitjes.SelectedItem;
            List<VoetbaltruitjesAantal> truitjes = DictionaryNaarListTruitjes();
            var truitje = truitjes.Where(y => y.Voetbaltruitje == v.Voetbaltruitje).ToList()[0];
            var element = (TextBox)e.EditingElement;
            truitje.Aantal = int.Parse(element.Text);
            UpdateBestellingTruitjes(truitjes);
            PrijsLaden(DictionaryNaarListTruitjes());
        }

        private void UpdateBestellingTruitjes(List<VoetbaltruitjesAantal> truitjes)
        {
            Dictionary<Domain.Klassen.Voetbaltruitje, int> keyValuePairs = new();
            foreach (var item in truitjes)
            {
                keyValuePairs.Add(item.Voetbaltruitje, item.Aantal);
            }
            _geselecteerdeBestellingUpdate.VoegProductenToe(keyValuePairs);
            Application.Current.Properties["GeselecteerdeBestellingenUpdate"] = _geselecteerdeBestellingUpdate;
        }

        private void PrijsLaden(List<VoetbaltruitjesAantal> truitjes)
        {
            if (truitjes != null)
            {
                double price = 0;
                foreach (var item in truitjes)
                {
                    price += item.Voetbaltruitje.Prijs * item.Aantal;
                }
                Price.Text = price.ToString("F2");
            }
        }
    }
}
