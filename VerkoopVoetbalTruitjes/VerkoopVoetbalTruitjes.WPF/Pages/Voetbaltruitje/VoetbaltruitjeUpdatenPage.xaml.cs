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
using VerkoopVoetbalTruitjes.Domain.Enums;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.WPF.Pages.Voetbaltruitje
{
    /// <summary>
    /// Interaction logic for VoetbaltruitjeUpdatenPage.xaml
    /// </summary>
    public partial class VoetbaltruitjeUpdatenPage : Page
    {
        private Domain.Klassen.Voetbaltruitje _voetbaltruitje = (Domain.Klassen.Voetbaltruitje)Application.Current.Properties["Voetbaltruitje"];

        public VoetbaltruitjeUpdatenPage()
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
            ComboBoxCompetitie.SelectedValue = _voetbaltruitje.Club.Competitie;
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
            ComboBoxMaat.SelectedValue = _voetbaltruitje.Kledingmaat.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Seizoen.Text = _voetbaltruitje.Seizoen;
            Versie.Text = _voetbaltruitje.ClubSet.Versie.ToString();
            Thuis.IsChecked = _voetbaltruitje.ClubSet.Thuis;
            Prijs.Text = _voetbaltruitje.Prijs.ToString();
        }

        private void ComboBoxPloeg_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxPloeg.SelectedValue = _voetbaltruitje.Club.Ploeg;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string competitie = ComboBoxCompetitie.SelectedItem.ToString();
                string ploeg = ComboBoxPloeg.SelectedItem.ToString();
                string seizoen = Seizoen.Text;
                bool thuis = _voetbaltruitje.ClubSet.Thuis;
                Kledingmaat kledingmaat;
                if (ComboBoxCompetitie.SelectedIndex == 0)
                {
                    competitie = _voetbaltruitje.Club.Competitie;
                }
                if (ComboBoxPloeg.SelectedIndex == 0)
                {
                    ploeg = _voetbaltruitje.Club.Ploeg;
                }
                if (!double.TryParse(Prijs.Text, out double prijs))
                {
                    prijs = _voetbaltruitje.Prijs;
                }
                if (ComboBoxMaat.SelectedIndex != 0)
                {
                    kledingmaat = (Kledingmaat)Enum.Parse(typeof(Kledingmaat), ComboBoxMaat.SelectedItem.ToString());
                }
                else
                {
                    kledingmaat = _voetbaltruitje.Kledingmaat;
                }
                if (!int.TryParse(Versie.Text, out int versie))
                {
                    versie = _voetbaltruitje.ClubSet.Versie;
                }
                if (string.IsNullOrWhiteSpace(Seizoen.Text))
                {
                    seizoen = _voetbaltruitje.Seizoen;
                }
                if (Thuis.IsChecked == false)
                {
                    thuis = false;
                }
                Club club = new(competitie, ploeg);
                ClubSet clubSet = new(thuis, versie);
                Domain.Klassen.Voetbaltruitje voetbaltruitje = new(_voetbaltruitje.Id, club, seizoen, prijs, kledingmaat, clubSet);
                MainWindow.voetbaltruitjeBeheerder.VoetbaltruitjeUpdaten(voetbaltruitje);
                MessageBox.Show("Voetbaltruitje is bijgewerkt", Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
