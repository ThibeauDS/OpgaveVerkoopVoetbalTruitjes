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

namespace VerkoopVoetbalTruitjes.WPF.Pages
{
    /// <summary>
    /// Interaction logic for DashbordPage.xaml
    /// </summary>
    public partial class DashbordPage : Page
    {
        public DashbordPage()
        {
            InitializeComponent();
        }

        private void MessageTxt_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;

            if (dt.Hour < 12 && dt.Hour >= 5)
            {
                MessageTxt.Text = $"Goedemorgen, het is {dt.Hour}:{dt.Minute}";
            }
            if (dt.Hour >= 12 && dt.Hour < 18)
            {
                MessageTxt.Text = $"Goedemiddag, het is {dt.Hour}:{dt.Minute}";
            }
            if (dt.Hour >= 18 && dt.Hour < 24)
            {
                MessageTxt.Text = $"Goedeavond, het is {dt.Hour}:{dt.Minute}";
            }
            if (dt.Hour >= 24 && dt.Hour < 5)
            {
                MessageTxt.Text = $"Goedenacht, het is {dt.Hour}:{dt.Minute}";
            }
        }
    }
}
