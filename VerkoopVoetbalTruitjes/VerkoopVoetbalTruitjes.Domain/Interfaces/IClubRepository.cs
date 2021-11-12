using System.Collections.Generic;

namespace VerkoopVoetbalTruitjes.Domain.Interfaces
{
    public interface IClubRepository
    {
        IReadOnlyList<string> GeefCompetities();
        //bool BestaatCompetitie(string competitie);
        IReadOnlyList<string> GeefPloegen(string competitie);
    }
}
