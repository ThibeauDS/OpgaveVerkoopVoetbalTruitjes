using System.Collections.Generic;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    public interface IClubRepository
    {
        IReadOnlyList<string> GeefCompetities();
    }
}
