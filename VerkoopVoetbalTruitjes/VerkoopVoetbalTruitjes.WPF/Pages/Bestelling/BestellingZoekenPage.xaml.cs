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
    /// Interaction logic for BestellingZoekenPage.xaml
    /// </summary>
    public partial class BestellingZoekenPage : Page
    {
        #region Properties
        private Domain.Klassen.Klant _klant = (Domain.Klassen.Klant)Application.Current.Properties["Klant"];
        private Domain.Klassen.Klant _klantSave;
        #endregion

        public BestellingZoekenPage()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = 0;
                DateTime? start = null;
                DateTime? end = null;
                if (!string.IsNullOrWhiteSpace(Id.Text))
                {
                    id = int.Parse(Id.Text);
                }
                if (StartDate.SelectedDate != null)
                {
                    start = StartDate.SelectedDate;
                }
                if (EndDate.SelectedDate != null)
                {
                    end = EndDate.SelectedDate;
                }
                List<Domain.Klassen.Bestelling> bestellingen = MainWindow.bestellingBeheerder.BestellingWeergeven(id, start, end, _klantSave);
                ObservableCollection<Domain.Klassen.Bestelling> ts = new();
                foreach (Domain.Klassen.Bestelling bestelling in bestellingen)
                {
                    ts.Add(bestelling);
                }
                ListViewOrders.ItemsSource = ts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SelectTruitjeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Bestelling/BestellingKlantSelecterenPage.xaml", UriKind.Relative));
        }

        private void UpdateVoetbaltruitje_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["GeselecteerdeBestellingenUpdate"] = (Domain.Klassen.Bestelling)ListViewOrders.SelectedItem;
            NavigationService.Navigate(new Uri("/Pages/Bestelling/BestellingUpdatenPage.xaml", UriKind.Relative));
        }

        private void DeleteVoetbaltruitje_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Domain.Klassen.Bestelling bestelling = (Domain.Klassen.Bestelling)ListViewOrders.SelectedItem;
                MainWindow.bestellingBeheerder.BestellingVerwijderen(bestelling);
                MessageBox.Show("Bestelling is verwijderd", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                SearchBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Customer_Loaded(object sender, RoutedEventArgs e)
        {
            if (_klant != null)
            {
                if (_klantSave != _klant && _klantSave != null)
                {
                    _klantSave = _klant;
                    Customer.Text = _klantSave.ToString();
                }
                else
                {
                    _klantSave = _klant;
                    Customer.Text = _klant.ToString();
                }
            }
        }
    }
}
