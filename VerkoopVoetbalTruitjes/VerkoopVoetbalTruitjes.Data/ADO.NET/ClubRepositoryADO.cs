using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;
using VerkoopVoetbalTruitjes.Domain.Exceptions;

namespace VerkoopVoetbalTruitjes.Data.ADO.NET
{
    //TODO: Moet nog geïmplementeerd worden
    public class ClubRepositoryADO : IClubRepository
    {
        private string _connectionString;

        public ClubRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return connection;
        }

        public bool BestaatCompetitie(string competitie)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<string> GeefCompetitie()
        {
            List<string> competities = new List<string>();
            SqlConnection connection = getConnection();
            string query = "SELECT DISTINCT competitie FROM dbo.ClubCompetitie ORDER by competitie";
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                try
                {
                    command.CommandText = query;
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string competitie = (string)dataReader["competitie"];
                        competities.Add(competitie);
                    }

                    dataReader.Close();
                    return competities;
                }
                catch (Exception ex)
                {

                    throw new ClubException("Geefcompetities", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IReadOnlyList<string> GeefPloegen(string competitie)
        {
            throw new NotImplementedException();
        }
    }
}
