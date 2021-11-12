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

namespace VerkoopVoetbalTruitjes.WPF.Pages.Klant
{
    /// <summary>
    /// Interaction logic for KlantUpdatenPage.xaml
    /// </summary>
    public partial class KlantUpdatenPage : Page
    {
        public KlantUpdatenPage()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Domain.Klassen.Klant klant = KlantZoekenPage._selectedKlant;
                klant.ZetNaam(Name.Text);
                klant.ZetAdres(Address.Text);
                MainWindow.klantBeheerder.KlantUpdaten(klant);
                MessageBox.Show("Klant is aangepast", Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
