using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VerkoopVoetbalTruitjes.Data.Exceptions;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Data.ADO.NET
{
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
            string sql = "UPDATE [dbo].[Klant] SET Naam = @Naam, Adres = @Adres WHERE Id = @Id";
            SqlConnection connection = GetConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", klant.KlantId);
                command.Parameters.AddWithValue("@Naam", klant.Naam);
                command.Parameters.AddWithValue("@Adres", klant.Adres);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new KlantRepositoryADOException("KlantUpdaten - error", ex);
            }
            finally
            {
                connection.Close();
            }
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

        public List<Klant> KlantWeergeven(int id, string naam, string adres)
        {
            List<Klant> klanten = new();
            bool isWhere = true;
            bool isAnd = false;
            string sql = "SELECT * FROM [dbo].[Klant]";
            if (id != 0)
            {
                if (isWhere)
                {
                    sql += " WHERE ";
                    isWhere = false;
                }
                if (isAnd)
                {
                    sql += " AND ";
                }
                else
                {
                    isAnd = true;
                }
                sql += "Id = @Id";
            }
            if (!string.IsNullOrWhiteSpace(naam))
            {
                if (isWhere)
                {
                    sql += " WHERE ";
                    isWhere = false;
                }
                if (isAnd)
                {
                    sql += " AND ";
                }
                else
                {
                    isAnd = true;
                }
                sql += "Naam = @Naam";
            }
            if (!string.IsNullOrWhiteSpace(adres))
            {
                if (isWhere)
                {
                    sql += " WHERE ";
                    isWhere = false;
                }
                if (isAnd)
                {
                    sql += " AND ";
                }
                else
                {
                    isAnd = true;
                }
                sql += "Adres = @Adres";
            }
            SqlConnection connection = GetConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                if (id != 0)
                {
                    command.Parameters.AddWithValue("@Id", id);
                }
                if (!string.IsNullOrWhiteSpace(naam))
                {
                    command.Parameters.AddWithValue("@Naam", naam);
                }
                if (!string.IsNullOrWhiteSpace(adres))
                {
                    command.Parameters.AddWithValue("@Adres", adres);
                }
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    klanten.Add(new Klant((int)reader["Id"], (string)reader["Naam"], (string)reader["Adres"]));
                }
                reader.Close();
                return klanten;
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
