using System;
using System.Collections.Generic;
using VerkoopVoetbalTruitjes.Domain.Exceptions;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    public class Klant
    {
        #region Properties
        public int KlantId { get; private set; }
        public string Naam { get; private set; }
        public string Adres { get; private set; }
        private List<Bestelling> _bestellingen = new List<Bestelling>();
        #endregion

        #region Constructors
        public Klant(int klantId, string naam, string adres, List<Bestelling> bestellingen) : this(klantId, naam, adres)
        {
            if (bestellingen == null) throw new KlantException("Klant - bestellingen null");
            _bestellingen = bestellingen;
            foreach (Bestelling b in bestellingen) b.ZetKlant(this);
        }
        public Klant(int klantId, string naam, string adres)
        {
            ZetKlantId(klantId);
            ZetNaam(naam);
            ZetAdres(adres);
        }
        public Klant(string naam, string adres)
        {
            ZetNaam(naam);
            ZetAdres(adres);
        }
        #endregion

        #region Methods
        public void ZetKlantId(int id)
        {
            if (id <= 0) throw new KlantException("Klant - invalid id");
            KlantId = id;
        }
        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                throw new KlantException("Klant naam invalid");
            }
            if (naam.Trim().Length < 1) throw new KlantException("Klant naam invalid");
            Naam = naam;
        }
        public void ZetAdres(string adres)
        {
            if (string.IsNullOrWhiteSpace(adres))
            {
                throw new KlantException("Klant adres invalid");
            }
            if (adres.Trim().Length < 5) throw new KlantException("Klant adres invalid");
            Adres = adres;
        }
        public IReadOnlyList<Bestelling> GetBestellingen()
        {
            return _bestellingen.AsReadOnly();
        }
        public void VerwijderBestelling(Bestelling bestelling)
        {
            if (bestelling == null) throw new KlantException("Klant : VerwijderBestelling - bestelling is null");
            if (!_bestellingen.Contains(bestelling))
            {
                throw new KlantException("Klant : RemoveBestelling - bestelling does not exists");
            }
            else
            {
                if (bestelling.Klant == this)
                {
                    bestelling.VerwijderKlant();
                    _bestellingen.Remove(bestelling);
                }

            }
        }
        public void VoegToeBestelling(Bestelling bestelling)
        {
            if (bestelling == null) throw new KlantException("Klant : VerwijderBestelling - bestelling is null");
            if (_bestellingen.Contains(bestelling))
            {
                throw new KlantException("Klant : AddBestelling - bestelling already exists");
            }
            else
            {
                _bestellingen.Add(bestelling);
                if (bestelling.Klant != this)
                    bestelling.ZetKlant(this);
            }
        }
        public bool HeeftBestelling(Bestelling bestelling)
        {
            if (_bestellingen.Contains(bestelling)) return true;
            else return false;
        }
        public int Korting() //procent
        {
            if (_bestellingen.Count < 5) return 0;
            if (_bestellingen.Count <= 10) return 10;
            else return 20;
        }
        public override string ToString()
        {
            //return $"[Klant] {KlantId},{Naam},{Adres},{_bestellingen.Count}";
            string res = $"[Klant] {KlantId},{Naam},{Adres},{_bestellingen.Count}";
            foreach (var x in _bestellingen)
            {
                res += $"\n{x}";
            }
            return res;
        }
        public string ToText(bool kort = true)
        {
            if (kort)
                return $"[Klant] {KlantId},{Naam},{Adres},{_bestellingen.Count}";
            else
            {
                string res = $"[Klant] {KlantId},{Naam},{Adres},{_bestellingen.Count}";
                foreach (var x in _bestellingen)
                {
                    res += $"\n{x}";
                }
                return res;
            }
        }
        public void Show()
        {
            Console.WriteLine(this);
            foreach (Bestelling b in _bestellingen) Console.WriteLine($"    bestelling:{b}");
        }

        public override bool Equals(object obj)
        {
            return obj is Klant klant &&
                   Naam == klant.Naam &&
                   Adres == klant.Adres;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Naam, Adres);
        }
        #endregion
    }
}
