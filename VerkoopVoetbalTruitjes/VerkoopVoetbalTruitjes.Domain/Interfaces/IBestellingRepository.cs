using System;
using System.Collections.Generic;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    public interface IBestellingRepository
    {
        bool BestaatBestelling(int id);
        void BestellingToevoegen(Bestelling bestelling);
        void BestellingVerwijderen(Bestelling bestelling);
        void BestellingUpdaten(Bestelling bestelling);
        List<Bestelling> BestellingWeergeven(int id, DateTime? start, DateTime? end, Klant _klantSave);
    }
}
