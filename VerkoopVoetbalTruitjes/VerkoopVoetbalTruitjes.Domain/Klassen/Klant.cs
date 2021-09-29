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
        public int KlantNummer { get; private set; }
        private List<Bestellingen> BestellingenList;
        #endregion

        #region Constructors
        public Klant(string naam, string adres, int klantNummer)
        {
            ZetNaam(naam);
            ZetAdres(adres);
            ZetKlantenNummer(klantNummer);
        }
        #endregion

        #region Methods
        public void VoegBestellingToe(bool isBetaald, decimal verkoopprijs, Truitje truitje)
        {
            BestellingenList.Add(new Bestellingen(isBetaald, verkoopprijs, truitje));
        }
        public void VerwijderBestelling(Bestellingen bestelling)
        {
            
        }
        public List<Bestellingen> GeefBestellingen()
        {
            return BestellingenList;
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
            if (string.IsNullOrEmpty(adres) || adres.Length < 5)
            {
                throw new KlantException("Adres moet minstens 5 karakters hebben.");
            }
            else
            {
                Adres = adres;
            }
        }
        public void ZetKlantenNummer(int klantNummer)
        {
            if (klantNummer <= 0)
            {
                throw new KlantException("Klantennummer mag niet 0 of kleiner zijn dan 0.");
            }
            else
            {
                KlantNummer = klantNummer;
            }
        }
        public void Korting()
        {
            if (BestellingenList.Count < 5)
            {
                // 0%
            }

            if (BestellingenList.Count >= 5)
            {
                //10%
            }

            if (BestellingenList.Count >= 10)
            {
                //20%
            }
        }
        #endregion
    }
}
