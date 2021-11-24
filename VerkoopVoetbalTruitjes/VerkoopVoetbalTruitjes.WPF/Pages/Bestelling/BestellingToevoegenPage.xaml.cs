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
        private Domain.Klassen.Klant _klant = (Domain.Klassen.Klant)Application.Current.Properties["Klant"];
        private Domain.Klassen.Klant _klantSave = (Domain.Klassen.Klant)Application.Current.Properties["SavedKlant"];
        private Dictionary<Domain.Klassen.Voetbaltruitje, int> _truitjes = (Dictionary<Domain.Klassen.Voetbaltruitje, int>)Application.Current.Properties["Truitjes"];
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
            try
            {
                bool betaald = false;
                if (IsPayed.IsChecked != false)
                {
                    betaald = true;
                }
                double.TryParse(Price.Text, out double prijs);
                if (Customer.Text != null && _truitjes != null && _truitjes.Count != 0 && _klantSave != null)
                {
                    Domain.Klassen.Bestelling bestelling = new(_klantSave, DateTime.Now, prijs, betaald, _truitjes);
                    MainWindow.bestellingBeheerder.BestellingToevoegen(bestelling);
                    Application.Current.Properties["Truitjes"] = null;
                    Customer.Text = null;
                    Price.Text = null;
                    IsPayed.IsChecked = false;
                    _truitjes.Clear();
                    DataGridTruitjes_Loaded(sender, e);
                    MessageBox.Show("Bestelling geplaatst", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["Klant"] = null;
            if (_klant != null)
            {
                Customer.Text = _klant.ToText(true);
                Application.Current.Properties["SavedKlant"] = _klant;
                _klantSave = _klant;
            }
        }

        private void Price_Loaded(object sender, RoutedEventArgs e)
        {
            if (_truitjes != null)
            {
                double price = 0;
                foreach (var item in _truitjes.Keys)
                {
                    price += item.Prijs * _truitjes[item];
                }
                Price.Text = price.ToString("F2");
            }
        }

        private void DeleteVoetbaltruitje_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = (KeyValuePair<Domain.Klassen.Voetbaltruitje, int>)DataGridTruitjes.CurrentItem;
                Domain.Klassen.Voetbaltruitje voetbaltruitje = x.Key;
                _truitjes.Remove(voetbaltruitje);
                Application.Current.Properties["Truitjes"] = _truitjes;
                MessageBox.Show("Truitje is verwijderd uit de bestelling", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                DataGridTruitjes_Loaded(sender, e);
                Price_Loaded(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DataGridTruitjes_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: Samen met de docent eens bekijken hoe dit valt correct op te lossen zonder de observableCollection te verliezen
            ObservableCollection<KeyValuePair<Domain.Klassen.Voetbaltruitje, int>> oc = new();
            if (_truitjes != null && _truitjes.Count != 0)
            {
                foreach (var truitje in _truitjes)
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
    }
}
