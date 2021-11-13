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
    /// Interaction logic for BestellingTruitjeSelecterenPage.xaml
    /// </summary>
    public partial class BestellingTruitjeSelecterenPage : Page
    {
        public BestellingTruitjeSelecterenPage()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ComboBoxCompetitie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxCompetitie.SelectedIndex != 0)
            {
                ObservableCollection<string> ploegen = new(MainWindow.clubBeheerder.GeefPloegen(ComboBoxCompetitie.SelectedItem.ToString()));
                ploegen.Insert(0, "<geen club>");
                ComboBoxPloeg.ItemsSource = ploegen;
                ComboBoxPloeg.SelectedIndex = 0;
            }
            else
            {
                ComboBoxPloeg.ItemsSource = null;
            }
        }

        private void ComboBoxCompetitie_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> competities = new(MainWindow.clubBeheerder.GeefCompetities());
            competities.Insert(0, "<geen competitie>");
            ComboBoxCompetitie.SelectedIndex = 0;
            ComboBoxCompetitie.ItemsSource = competities;
        }

        private void ComboBoxMaat_Loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> maten = new();
            maten.Insert(0, "<geen maat>");
            maten.Insert(1, "S");
            maten.Insert(2, "M");
            maten.Insert(3, "L");
            maten.Insert(4, "XL");
            ComboBoxMaat.ItemsSource = maten;
            ComboBoxMaat.SelectedIndex = 0;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string competitie = "";
                string ploeg = "";
                double? prijs = null;
                bool? thuis = null;
                string maat = "";
                if (!int.TryParse(Id.Text, out int id))
                {
                    id = 0;
                }
                if (ComboBoxCompetitie.SelectedIndex != 0 && ComboBoxCompetitie != null)
                {
                    competitie = ComboBoxCompetitie.SelectedItem.ToString();
                }
                if (ComboBoxPloeg.SelectedIndex != 0 && ComboBoxPloeg != null && ComboBoxPloeg.Items.Count != 0)
                {
                    ploeg = ComboBoxPloeg.SelectedItem.ToString();
                }
                if (double.TryParse(Prijs.Text, out double prijs2))
                {
                    prijs = prijs2;
                }
                if (!int.TryParse(Versie.Text, out int versie))
                {
                    versie = 0;
                }
                if (Thuis.IsChecked == true)
                {
                    thuis = true;
                }
                if (Uit.IsChecked == true)
                {
                    thuis = false;
                }
                if (Thuis.IsChecked == Uit.IsChecked)
                {
                    thuis = null;
                }
                if (ComboBoxMaat.SelectedIndex != 0 && ComboBoxMaat != null)
                {
                    maat = ComboBoxMaat.SelectedItem.ToString();
                }
                IReadOnlyList<Domain.Klassen.Voetbaltruitje> voetbaltruitjes = MainWindow.voetbaltruitjeBeheerder.VoetbaltruitjeWeergeven(id, competitie, ploeg, Seizoen.Text, prijs, thuis, versie, maat);
                ObservableCollection<Domain.Klassen.Voetbaltruitje> ts = new();
                foreach (var voetbaltruitje in voetbaltruitjes)
                {
                    ts.Add(voetbaltruitje);
                }
                ListViewTruitjes.ItemsSource = ts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewTruitjes.SelectedItem != null)
            {
                ObservableCollection<Domain.Klassen.Voetbaltruitje> voetbaltruitjes = new();
                voetbaltruitjes.Add((Domain.Klassen.Voetbaltruitje)ListViewTruitjes.SelectedItem);
                Application.Current.Properties["Truitjes"] = voetbaltruitjes;
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Er is geen truitje geselecteerd", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
