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
using VerkoopVoetbalTruitjes.WPF.Pages.Bestelling;
using VerkoopVoetbalTruitjes.WPF.Pages.Dashboard;
using VerkoopVoetbalTruitjes.WPF.Pages.Klant;
using VerkoopVoetbalTruitjes.WPF.Pages.Voetbaltruitje;
using VerkoopVoetbalTruitjes.Domain.Beheerders;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using System.Configuration;
using VerkoopVoetbalTruitjes.Data.ADO.NET;

namespace VerkoopVoetbalTruitjes.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties
        private KlantenPage _klantenPage = new();
        private BestellingenPage _bestellingenPage = new();
        private VoetbaltruitjePage _voetbaltruitjePage = new();
        private DashboardPage _dashbordPage = new();
        public string connectionString;
        public static KlantBeheerder klantBeheerder;
        public static VoetbaltruitjeBeheerder voetbaltruitjeBeheerder;
        public static BestellingBeheerder bestellingBeheerder;
        public static ClubBeheerder clubBeheerder;
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            klantBeheerder = new(new KlantRepositoryADO(connectionString));
            voetbaltruitjeBeheerder = new(new VoetbaltruitjeRepositoryADO(connectionString));
            bestellingBeheerder = new(new BestellingRepositoryADO(connectionString));
            clubBeheerder = new(new ClubRepositoryADO(connectionString));
        }
        #endregion

        private void KlantenBtn_Click(object sender, RoutedEventArgs e)
        {
            MainView.Navigate(_klantenPage);
        }

        private void BestellingenBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Properties["GeselecteerdeBestellingenUpdate"] = null;
            MainView.Navigate(_bestellingenPage);
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            DashboardBtn_Click(sender, e);
        }

        private void VoetbaltruitjeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainView.Navigate(_voetbaltruitjePage);
        }

        private void DashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            MainView.Navigate(_dashbordPage);
        }
    }
}
