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

namespace VerkoopVoetbalTruitjes.WPF.Pages.Klant
{
    /// <summary>
    /// Interaction logic for KlantZoekenPage.xaml
    /// </summary>
    public partial class KlantZoekenPage : Page
    {
        #region Properties
        #endregion

        public KlantZoekenPage()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                if (string.IsNullOrWhiteSpace(Id.Text))
                {
                    id = 0;
                }
                else
                {
                    id = int.Parse(Id.Text);
                }
                List<Domain.Klassen.Klant> klanten = MainWindow.klantBeheerder.KlantWeergeven(id, Name.Text, Address.Text);
                ObservableCollection<Domain.Klassen.Klant> ts = new();
                foreach (Domain.Klassen.Klant klant in klanten)
                {
                    ts.Add(klant);
                }
                DataGridCustomers.ItemsSource = ts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Properties["SelectedKlant"] = (Domain.Klassen.Klant)DataGridCustomers.CurrentItem;
                NavigationService.Navigate(new Uri("/Pages/Klant/KlantUpdatenPage.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Domain.Klassen.Klant klant = (Domain.Klassen.Klant)DataGridCustomers.CurrentItem;
                MainWindow.klantBeheerder.KlantVerwijderen(klant);
                MessageBox.Show("Klant is verwijderd", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                SearchBtn_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
