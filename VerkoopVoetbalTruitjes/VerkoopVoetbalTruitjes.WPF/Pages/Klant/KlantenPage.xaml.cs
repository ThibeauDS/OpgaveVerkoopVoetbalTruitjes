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

namespace VerkoopVoetbalTruitjes.WPF.Pages.Klant
{
    /// <summary>
    /// Interaction logic for KlantenPage.xaml
    /// </summary>
    public partial class KlantenPage : Page
    {
        #region Properties
        #endregion
        public KlantenPage()
        {
            InitializeComponent();
        }

        private void CreateCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Klant/KlantToevoegenPage.xaml", UriKind.Relative));
        }

        private void FindCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Klant/KlantZoekenPage.xaml", UriKind.Relative));
        }
    }
}
