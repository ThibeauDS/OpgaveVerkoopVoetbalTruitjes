using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;
using VerkoopVoetbalTruitjes.Data.Exceptions;

namespace VerkoopVoetbalTruitjes.Data.ADO.NET
{
    //TODO: Moet nog geïmplementeerd worden
    public class ClubRepositoryADO : IClubRepository
    {
        #region Properties
        private readonly string _connectionString;
        #endregion

        #region Constructors
        public ClubRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        } 
        #endregion

        private SqlConnection getConnection()
        {
            SqlConnection connection = new(_connectionString);
            return connection;
        }

        //public bool BestaatCompetitie(string competitie)
        //{
        //    throw new NotImplementedException();
        //}

        public IReadOnlyList<string> GeefCompetities()
        {
            List<string> competities = new();
            SqlConnection connection = getConnection();
            string query = "SELECT DISTINCT Competitie FROM dbo.Club ORDER by competitie";
            using SqlCommand command = new(query, connection);
            try
            {
                connection.Open();
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

                throw new ClubRepositoryADOException("Geefcompetities", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public IReadOnlyList<string> GeefPloegen(string competitie)
        {
            List<string> ploegen = new();
            SqlConnection connection = getConnection();
            string query = "SELECT DISTINCT Ploeg FROM dbo.Club WHERE Competitie = @Competitie ORDER by Ploeg";
            using SqlCommand command = new(query, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Competitie", competitie);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string ploeg = (string)dataReader["Ploeg"];
                    ploegen.Add(ploeg);
                }

                dataReader.Close();
                return ploegen;
            }
            catch (Exception ex)
            {

                throw new ClubRepositoryADOException("GeefPloegen", ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
