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
using VerkoopVoetbalTruitjes.WPF.Pages;

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
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        private void KlantenBtn_Click(object sender, RoutedEventArgs e)
        {
            MainView.Content = _klantenPage;
        }

        private void BestellingenBtn_Click(object sender, RoutedEventArgs e)
        {
            MainView.Content = _bestellingenPage;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            KlantenBtn_Click(sender, e);
        }
    }
}
