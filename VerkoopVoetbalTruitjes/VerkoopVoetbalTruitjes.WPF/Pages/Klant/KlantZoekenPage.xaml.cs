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
        public KlantZoekenPage()
        {
            InitializeComponent();
        }

        private void Id_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Domain.Klassen.Klant klant = new(Name.Text, Address.Text);
                if (!string.IsNullOrWhiteSpace(Id.Text))
                {
                    klant.ZetKlantId(int.Parse(Id.Text));
                }
                Domain.Klassen.Klant klantDb = MainWindow.klantBeheerder.KlantWeergeven(klant);
                ObservableCollection<Domain.Klassen.Klant> ts = new();
                ts.Add(klantDb);
                DataGridCustomers.ItemsSource = ts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            Domain.Klassen.Klant klant = (Domain.Klassen.Klant)sender;
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Domain.Klassen.Klant klant = (Domain.Klassen.Klant)sender;
                MainWindow.klantBeheerder.KlantVerwijderen(klant);
                DataGridCustomers.ItemsSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
