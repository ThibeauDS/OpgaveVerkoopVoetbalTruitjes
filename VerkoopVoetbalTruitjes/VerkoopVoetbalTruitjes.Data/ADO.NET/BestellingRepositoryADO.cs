using System;
using System.Data.SqlClient;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Data.ADO.NET
{
    //TODO: Moet nog geïmplementeerd worden
    public class BestellingRepositoryADO : IBestellingRepository
    {
        #region Properties
        private readonly string _connectionString;
        #endregion

        #region Constructors
        public BestellingRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Methods
        private SqlConnection GetConnection()
        {
            SqlConnection connection = new(_connectionString);
            return connection;
        }

        public bool BestaatBestelling(Bestelling bestelling)
        {
            throw new NotImplementedException();
        }

        public void BestellingToevoegen(Bestelling bestelling)
        {
            throw new NotImplementedException();
        }

        public void BestellingUpdaten(Bestelling bestelling)
        {
            throw new NotImplementedException();
        }

        public void BestellingVerwijderen(Bestelling bestelling)
        {
            throw new NotImplementedException();
        }

        public void BestellingWeergeven(Bestelling bestelling)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
