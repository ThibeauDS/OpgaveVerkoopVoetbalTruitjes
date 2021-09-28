using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerkoopVoetbalTruitjes.Domain.Exceptions;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    public class Klant
    {
        #region Properties
        public string Naam { get; private set; }
        public string Adres { get; private set; }
        private int _klantNummer;
        #endregion

        #region Constructors
        public Klant(string naam, string adres, int klantNummer)
        {
        }
        #endregion

        #region Methods
        public void VoegBestellingToe() { }
        public void VerwijderBestelling() { }
        public Bestellingen GeefBestellingen()
        {
            return new Bestellingen();
        }
        public void ZetNaam(string naam)
        {
            if (string.IsNullOrEmpty(naam))
            {
                throw new KlantException("Naam mag niet leeg zijn.");
            }
            else
            {
                Naam = naam;
            }
        }
        public void ZetAdres(string adres)
        {
            if (string.IsNullOrEmpty(adres) || adres.Length > 5)
            {
                throw new KlantException("");
            }
        }
        #endregion
    }
}
