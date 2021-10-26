using VerkoopVoetbalTruitjes.Domain.Klassen;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    public interface IVoetbaltruitjeRepository
    {
        bool BestaatVoetbaltruitje(Voetbaltruitje voetbaltruitje);
        void VoetbaltruitjeToevoegen(Voetbaltruitje voetbaltruitje);
        void VoetbaltruitjeVerwijderen(Voetbaltruitje voetbaltruitje);
        void VoetbaltruitjeUpdaten(Voetbaltruitje voetbaltruitje);
        void VoetbaltruitjeWeergeven(Voetbaltruitje voetbaltruitje);
        IReadOnlyList<Voetbaltruitje> GeefTruitjes(string competitie, string club, string seizoen, string kledingmaat, int? versie, bool? thuis, double? prijs, bool strikt = true);
    }
}
