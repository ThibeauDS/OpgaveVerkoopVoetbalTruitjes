using System;
using System.Collections.Generic;
using System.Configuration;
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
using VerkoopVoetbalTruitjes.Data.ADO.NET;
using VerkoopVoetbalTruitjes.Domain.Beheerders;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.WPF.Pages.Klant
{
    /// <summary>
    /// Interaction logic for KlantToevoegen.xaml
    /// </summary>
    public partial class KlantToevoegenPage : Page
    {
        #region Properties
        private string _connectionString;
        private KlantBeheerder _klantBeheerder;
        #endregion
        public KlantToevoegenPage()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _klantBeheerder = new(new KlantRepositoryADO(_connectionString));
                Domain.Klassen.Klant klant = new(Name.Text, Address.Text);
                _klantBeheerder.KlantToevoegen(klant);
                MessageBox.Show("Klant is aangemaakt", Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
