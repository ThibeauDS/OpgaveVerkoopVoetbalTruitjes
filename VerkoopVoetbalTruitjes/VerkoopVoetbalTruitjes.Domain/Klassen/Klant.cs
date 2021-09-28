using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    public class Klant
    {
        #region Properties
        private string _naam = "";
        private string _adres = "";
        private int _klantNummer;
        #endregion

        #region Constructors
        public Klant(string naam, string adres, int klantNummer)
        {
            _naam = naam;
            _adres = adres;
            _klantNummer = klantNummer;
        }
        #endregion

        #region Methods
        public void VoegBestellingToe() { }
        public void VerwijderBestelling() { }
        public void GeefBestellingen() { }
        #endregion
    }
}
