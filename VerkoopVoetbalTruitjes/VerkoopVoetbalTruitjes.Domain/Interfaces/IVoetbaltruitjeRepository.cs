using VerkoopVoetbalTruitjes.Domain.Klassen;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    public interface IVoetbaltruitjeRepository
    {
        void VoetbaltruitjeToevoegen(Voetbaltruitje voetbaltruitje);
        void VoetbaltruitjeVerwijderen(Voetbaltruitje voetbaltruitje);
        void VoetbaltruitjeUpdaten(Voetbaltruitje voetbaltruitje);
        IReadOnlyList<Voetbaltruitje> VoetbaltruitjeWeergeven(int id, string competitie, string ploeg, string seizoen, double? prijs, bool? thuis, int versie, string maat);
        bool BestaatVoetbaltruitje(int id);
    }
}
