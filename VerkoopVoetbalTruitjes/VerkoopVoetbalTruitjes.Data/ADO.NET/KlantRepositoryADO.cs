using System;
using System.Data;
using System.Data.SqlClient;
using VerkoopVoetbalTruitjes.Data.Exceptions;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Data.ADO.NET
{
    //TODO: Moet nog geïmplementeerd worden
    public class KlantRepositoryADO : IKlantRepository
    {
        #region Properties
        private string _connectionString;
        #endregion

        #region Constructors
        public KlantRepositoryADO(string connectionString)
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
        public bool BestaatKlant(int id)
        {
            string sql = "SELECT COUNT(*) FROM [dbo].[Klant] WHERE Id = @Id";
            SqlConnection connection = GetConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id);
                int n = (int)command.ExecuteScalar();
                if (n > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new KlantRepositoryADOException("BestaatKlant - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void KlantToevoegen(Klant klant)
        {
            string sql = "INSERT INTO [dbo].[Klant] (Naam, Adres) VALUES (@Naam, @Adres)";
            SqlConnection connection = GetConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Naam", klant.Naam);
                command.Parameters.AddWithValue("@Adres", klant.Adres);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new KlantRepositoryADOException("KlantToevoegen - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void KlantUpdaten(Klant klant)
        {
            throw new NotImplementedException();
        }

        public void KlantVerwijderen(Klant klant)
        {
            string sql = "DELETE FROM [dbo].[Klant] WHERE Id = @Id";
            SqlConnection connection = GetConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", klant.KlantId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new KlantRepositoryADOException("KlantVerwijderen - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public Klant KlantWeergeven(Klant klant)
        {
            Klant klant1 = null;
            int id = 0;
            string sql = "SELECT * FROM [dbo].[Klant] WHERE Naam = @Naam AND Adres = @Adres";
            if (klant.KlantId != 0)
            {
                sql = "SELECT * FROM [dbo].[Klant] WHERE Id = @Id AND Naam = @Naam AND Adres = @Adres";
            }
            SqlConnection connection = GetConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                if (klant.KlantId != 0)
                {
                    command.Parameters.AddWithValue("@Id", klant.KlantId);
                }
                command.Parameters.AddWithValue("@Naam", klant.Naam);
                command.Parameters.AddWithValue("@Adres", klant.Adres);
                IDataReader reader = command.ExecuteReader();
                reader.Read();
                klant1 = new((int)reader["Id"], (string)reader["Naam"], (string)reader["Adres"]);
                reader.Close();
                return klant1;
            }
            catch (Exception ex)
            {
                throw new KlantRepositoryADOException("KlantWeergeven - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion
    }
}
