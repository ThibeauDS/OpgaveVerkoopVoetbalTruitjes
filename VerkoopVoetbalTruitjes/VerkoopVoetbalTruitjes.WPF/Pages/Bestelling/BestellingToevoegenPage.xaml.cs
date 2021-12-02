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
    /// Interaction logic for BestellingToevoegenPage.xaml
    /// </summary>
    public partial class BestellingToevoegenPage : Page
    {
        #region Properties
        private Domain.Klassen.Klant _klant = (Domain.Klassen.Klant)Application.Current.Properties["Klant"];
        private Domain.Klassen.Klant _klantSave = (Domain.Klassen.Klant)Application.Current.Properties["SavedKlant"];
        private List<VoetbaltruitjesAantal> _truitjes = (List<VoetbaltruitjesAantal>)Application.Current.Properties["Truitjes"];
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
                List<VoetbaltruitjesAantal> voetbaltruitjes = DataGridTruitjes.Items.OfType<VoetbaltruitjesAantal>().ToList();
                bool betaald = false;
                if (IsPayed.IsChecked != false)
                {
                    betaald = true;
                }
                _ = double.TryParse(Price.Text, out double prijs);
                if (Customer.Text != null && _truitjes != null && _truitjes.Count != 0 && _klantSave != null)
                {
                    Dictionary<Domain.Klassen.Voetbaltruitje, int> truitjes = new();
                    foreach (var item in voetbaltruitjes)
                    {
                        truitjes.Add(item.Voetbaltruitje, item.Aantal);
                    }
                    Domain.Klassen.Bestelling bestelling = new(_klantSave, DateTime.Now, prijs, betaald, truitjes);
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
            PrijsLaden();
        }

        private void DeleteVoetbaltruitje_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VoetbaltruitjesAantal x = (VoetbaltruitjesAantal)DataGridTruitjes.CurrentItem;
                foreach (var item in _truitjes)
                {
                    if (item.Voetbaltruitje.Equals(x.Voetbaltruitje) && item.Aantal.Equals(x.Aantal))
                    {
                        _truitjes.Remove(item);
                        break;
                    }
                }
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
            ObservableCollection<VoetbaltruitjesAantal> oc = new();
            if (_truitjes != null && _truitjes.Count != 0)
            {
                foreach (var truitje in _truitjes)
                {
                    VoetbaltruitjesAantal voetbaltruitjesAantal = new(truitje.Voetbaltruitje, truitje.Aantal);
                    oc.Add(voetbaltruitjesAantal);
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

        private void DataGridTruitjes_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            VoetbaltruitjesAantal v = (VoetbaltruitjesAantal)DataGridTruitjes.SelectedItem;
            var truitje = _truitjes.Where(y => y.Voetbaltruitje == v.Voetbaltruitje).ToList()[0];
            var element = (TextBox)e.EditingElement;
            truitje.Aantal = int.Parse(element.Text);
            PrijsLaden();
        }

        private void PrijsLaden()
        {
            if (_truitjes != null)
            {
                double price = 0;
                foreach (var item in _truitjes)
                {
                    price += item.Voetbaltruitje.Prijs * item.Aantal;
                }
                Price.Text = price.ToString("F2");
            }
        }
    }
}
