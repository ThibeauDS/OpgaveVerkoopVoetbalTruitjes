using System;
using System.Collections.Generic;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Data.ADO.NET
{
    //TODO: Moet nog geïmplementeerd worden
    public class ClubRepositoryADO : IClubRepository
    {
        public bool BestaatCompetitie(string competitie)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<string> GeefCompetities()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<string> GeefPloegen(string competitie)
        {
            throw new NotImplementedException();
        }
    }
}
