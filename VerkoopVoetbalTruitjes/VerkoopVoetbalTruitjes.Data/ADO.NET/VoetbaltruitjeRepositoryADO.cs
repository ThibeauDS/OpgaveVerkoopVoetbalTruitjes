using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VerkoopVoetbalTruitjes.Data.Exceptions;
using VerkoopVoetbalTruitjes.Domain.Enums;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Data.ADO.NET
{
    public class VoetbaltruitjeRepositoryADO : IVoetbaltruitjeRepository
    {
        #region Properties
        private readonly string _connectionString;
        #endregion

        #region Constructors
        public VoetbaltruitjeRepositoryADO(string connectionString)
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

        public bool BestaatVoetbaltruitje(int id)
        {
            string sql = "SELECT COUNT(*) FROM [dbo].[Truitje] WHERE Id = @Id";
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
                throw new VoetbaltruitjeRepositoryADOException("BestaatVoetbaltruitje - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void VoetbaltruitjeToevoegen(Voetbaltruitje voetbaltruitje)
        {
            string sql = "INSERT INTO [dbo].[Truitje] (Maat, Seizoen, Prijs, Versie, Thuis, Competitie, Ploeg) VALUES (@Maat, @Seizoen, @Prijs, @Versie, @Thuis, @Competitie, @Ploeg)";
            SqlConnection connection = GetConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Maat", voetbaltruitje.Kledingmaat.ToString());
                command.Parameters.AddWithValue("@Seizoen", voetbaltruitje.Seizoen);
                command.Parameters.AddWithValue("@Prijs", voetbaltruitje.Prijs);
                command.Parameters.AddWithValue("@Versie", voetbaltruitje.ClubSet.Versie);
                command.Parameters.AddWithValue("@Thuis", voetbaltruitje.ClubSet.Thuis);
                command.Parameters.AddWithValue("@Competitie", voetbaltruitje.Club.Competitie);
                command.Parameters.AddWithValue("@Ploeg", voetbaltruitje.Club.Ploeg);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new VoetbaltruitjeRepositoryADOException("VoetbaltruitjeToevoegen - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void VoetbaltruitjeUpdaten(Voetbaltruitje voetbaltruitje)
        {
            string sql = "UPDATE [dbo].[Truitje] SET Maat = @Maat, Seizoen = @Seizoen, Prijs = @Prijs, Versie = @Versie, Thuis = @Thuis, Competitie = @Competitie, Ploeg = @Ploeg WHERE Id = @Id";
            SqlConnection connection = GetConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", voetbaltruitje.Id);
                command.Parameters.AddWithValue("@Maat", voetbaltruitje.Kledingmaat.ToString());
                command.Parameters.AddWithValue("@Seizoen", voetbaltruitje.Seizoen);
                command.Parameters.AddWithValue("@Prijs", voetbaltruitje.Prijs);
                command.Parameters.AddWithValue("@Versie", voetbaltruitje.ClubSet.Versie);
                command.Parameters.AddWithValue("@Thuis", voetbaltruitje.ClubSet.Thuis);
                command.Parameters.AddWithValue("@Competitie", voetbaltruitje.Club.Competitie);
                command.Parameters.AddWithValue("@Ploeg", voetbaltruitje.Club.Ploeg);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new VoetbaltruitjeRepositoryADOException("VoetbaltruitjeVerwijderen - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void VoetbaltruitjeVerwijderen(Voetbaltruitje voetbaltruitje)
        {
            string sql = "DELETE FROM [dbo].[Truitje] WHERE Id = @Id";
            SqlConnection connection = GetConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@Id", voetbaltruitje.Id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new VoetbaltruitjeRepositoryADOException("VoetbaltruitjeVerwijderen - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public IReadOnlyList<Voetbaltruitje> VoetbaltruitjeWeergeven(int id, string competitie, string ploeg, string seizoen, double? prijs, bool? thuis, int versie, string maat)
        {
            List<Voetbaltruitje> voetbaltruitjes = new();
            bool isWhere = true;
            bool isAnd = false;
            string sql = "SELECT * FROM [dbo].[Truitje]";
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
            if (!string.IsNullOrWhiteSpace(competitie))
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
                sql += "Competitie = @Competitie";
            }
            if (!string.IsNullOrWhiteSpace(ploeg))
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
                sql += "Ploeg = @Ploeg";
            }
            if (!string.IsNullOrWhiteSpace(seizoen))
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
                sql += "Seizoen = @Seizoen";
            }
            if (prijs != null)
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
                sql += "Prijs = @Prijs";
            }
            if (thuis != null)
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
                sql += "Thuis = @Thuis";
            }
            if (versie != 0)
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
                sql += "Versie = @Versie";
            }
            if (!string.IsNullOrWhiteSpace(maat))
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
                sql += "Maat = @Maat";
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
                if (!string.IsNullOrWhiteSpace(competitie))
                {
                    command.Parameters.AddWithValue("@Competitie", competitie);
                }
                if (!string.IsNullOrWhiteSpace(ploeg))
                {
                    command.Parameters.AddWithValue("@Ploeg", ploeg);
                }
                if (!string.IsNullOrWhiteSpace(seizoen))
                {
                    command.Parameters.AddWithValue("@Seizoen", seizoen);
                }
                if (prijs != null)
                {
                    command.Parameters.AddWithValue("@Prijs", prijs);
                }
                if (thuis != null)
                {
                    command.Parameters.AddWithValue("@Thuis", thuis);
                }
                if (versie != 0)
                {
                    command.Parameters.AddWithValue("@Versie", versie);
                }
                if (!string.IsNullOrWhiteSpace(maat))
                {
                    command.Parameters.AddWithValue("@Maat", maat);
                }
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Club club = new((string)reader["Competitie"], (string)reader["Ploeg"]);
                    ClubSet clubSet = new((bool)reader["Thuis"], (int)reader["Versie"]);
                    Kledingmaat kledingmaat = (Kledingmaat)Enum.Parse(typeof(Kledingmaat), (string)reader["Maat"]);
                    Voetbaltruitje voetbaltruitje = new((int)reader["Id"], club, (string)reader["Seizoen"], (double)reader["Prijs"], kledingmaat, clubSet);
                    voetbaltruitjes.Add(voetbaltruitje);
                }
                reader.Close();
                return voetbaltruitjes;
            }
            catch (Exception ex)
            {
                throw new VoetbaltruitjeRepositoryADOException("VoetbaltruitjeWeergeven - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion
    }
}
