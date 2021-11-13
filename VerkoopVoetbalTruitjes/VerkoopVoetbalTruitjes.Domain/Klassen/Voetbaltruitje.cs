using System;
using System.Collections.Generic;
using VerkoopVoetbalTruitjes.Domain.Enums;
using VerkoopVoetbalTruitjes.Domain.Exceptions;

namespace VerkoopVoetbalTruitjes.Domain.Klassen
{
    public class Voetbaltruitje
    {
        #region Properties
        public int Id { get; private set; }
        public Club Club { get; private set; }
        public string Seizoen { get; private set; }
        public double Prijs { get; private set; }
        public Kledingmaat Kledingmaat { get; set; }
        public ClubSet ClubSet { get; private set; }
        //public Personalisatie Personalisatie { get; private set; }
        #endregion

        #region Constructors
        public Voetbaltruitje(int id, Club club, string seizoen, double prijs, Kledingmaat kledingmaat, ClubSet clubSet)
            : this(club, seizoen, prijs, kledingmaat, clubSet)
        {
            ZetId(id);
        }
        public Voetbaltruitje(Club club, string seizoen, double prijs, Kledingmaat kledingmaat, ClubSet clubSet)
        {
            ZetClub(club);
            Seizoen = seizoen;
            ZetPrijs(prijs);
            Kledingmaat = kledingmaat;
            ZetClubSet(clubSet);
        }
        #endregion

        #region Methods
        public void ZetId(int id)
        {
            if (id <= 0) throw new VoetbaltruitjeException("Voetbaltruitje - invalid id");
            Id = id;
        }
        public void ZetPrijs(double prijs)
        {
            if (prijs <= 0) throw new VoetbaltruitjeException("Voetbaltruitje - invalid prijs");
            this.Prijs = prijs;
        }
        public void ZetSeizoen(string seizoen)
        {
            if (string.IsNullOrWhiteSpace(seizoen))
            {
                throw new VoetbaltruitjeException("ZetSeizoen = null/Empty");
            }
            this.Seizoen = seizoen;
        }
        public void ZetClub(Club club)
        {
            if (club == null) throw new VoetbaltruitjeException("ZetClub = null");
            this.Club = club;
        }
        public void ZetClubSet(ClubSet clubSet)
        {
            if (clubSet == null) throw new VoetbaltruitjeException("ZetClubSet - null");
            this.ClubSet = clubSet;
        }
        public override string ToString()
        {
            string thuis = "Uit";
            if (ClubSet.Thuis == true)
            {
                thuis = "Thuis";
            }
            return $"{Id} - {Club.Competitie} - {Club.Ploeg} - {Seizoen} - {Prijs} - {Kledingmaat} - {thuis} - {ClubSet.Versie}";
        }

        public override bool Equals(object obj)
        {
            return obj is Voetbaltruitje voetbaltruitje &&
                   Id == voetbaltruitje.Id &&
                   EqualityComparer<Club>.Default.Equals(Club, voetbaltruitje.Club) &&
                   Seizoen == voetbaltruitje.Seizoen &&
                   Prijs == voetbaltruitje.Prijs &&
                   Kledingmaat == voetbaltruitje.Kledingmaat &&
                   EqualityComparer<ClubSet>.Default.Equals(ClubSet, voetbaltruitje.ClubSet);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Club, Seizoen, Prijs, Kledingmaat, ClubSet);
        }
        #endregion
    }
}
