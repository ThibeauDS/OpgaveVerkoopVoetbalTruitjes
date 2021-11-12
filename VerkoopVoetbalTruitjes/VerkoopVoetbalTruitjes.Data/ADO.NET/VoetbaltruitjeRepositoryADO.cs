using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VerkoopVoetbalTruitjes.Data.Exceptions;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Data.ADO.NET
{
    //TODO: Moet nog geïmplementeerd worden
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
                throw new KlantRepositoryADOException("VoetbaltruitjeToevoegen - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void VoetbaltruitjeUpdaten(Voetbaltruitje voetbaltruitje)
        {
            throw new NotImplementedException();
        }

        public void VoetbaltruitjeVerwijderen(Voetbaltruitje voetbaltruitje)
        {
            throw new NotImplementedException();
        }

        public void VoetbaltruitjeWeergeven(Voetbaltruitje voetbaltruitje)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Voetbaltruitje> VoetbaltruitjeWeergeven(int id, string competitie, string ploeg, string seizoen, double? prijs, bool? thuis, int versie, string maat)
        {
            IEnumerable<Voetbaltruitje> voetbaltruitjes;
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
                //TODO: Implementatie van VoetbaltruitjeWeergeven
                if (id != 0)
                {
                    command.Parameters.AddWithValue("@Id", id);
                }
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    voetbaltruitjes.Add(new Voetbaltruitje();
                }
                reader.Close();
                return voetbaltruitjes;
            }
            catch (Exception ex)
            {
                throw new KlantRepositoryADOException("VoetbaltruitjeWeergeven - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion
    }
}
