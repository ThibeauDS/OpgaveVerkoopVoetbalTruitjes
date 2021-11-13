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
    /// Interaction logic for BestellingKlantSelecterenPage.xaml
    /// </summary>
    public partial class BestellingKlantSelecterenPage : Page
    {
        public BestellingKlantSelecterenPage()
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
                ListViewCustomers.ItemsSource = ts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ListViewCustomers.SelectedItem != null)
                {
                    var x = ListViewCustomers.SelectedItem.ToString();
                    Application.Current.Properties["Klant"] = (Domain.Klassen.Klant)ListViewCustomers.SelectedItem;
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Er is geen klant geselecteerd", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
