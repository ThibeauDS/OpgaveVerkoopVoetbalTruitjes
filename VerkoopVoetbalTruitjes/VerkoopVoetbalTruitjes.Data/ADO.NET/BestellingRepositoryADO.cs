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

        public bool BestaatBestelling(int id)
        {
            string sql = "SELECT COUNT(*) FROM [dbo].[Bestellingen] WHERE Id = @Id";
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
                throw new BestellingRepositoryADOException("BestaatBestelling - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void BestellingToevoegen(Bestelling bestelling)
        {
            int bestellingsId;
            var producten = bestelling.GeefProducten();

            string sql = "INSERT INTO [dbo].[Bestellingen] (Datum, Verkoopprijs, Betaald, KlantID) VALUES (@Datum, @Verkoopprijs, @Betaald, @KlantID) SELECT SCOPE_IDENTITY()";
            SqlConnection connection = GetConnection();
            using SqlCommand command = new(sql, connection);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            try
            {
                command.Parameters.AddWithValue("@Datum", bestelling.Tijdstip);
                command.Parameters.AddWithValue("@Verkoopprijs", bestelling.Prijs);
                command.Parameters.AddWithValue("@Betaald", bestelling.Betaald);
                command.Parameters.AddWithValue("@KlantID", bestelling.Klant.KlantId);
                bestellingsId = Decimal.ToInt32((decimal)command.ExecuteScalar());

                foreach (var voetbaltruitje in producten)
                {
                    string sql2 = "INSERT INTO [dbo].[BestellingTruitje] (BestellingID, TruitjeID, Aantal) VALUES (@BestellingID, @TruitjeID, @Aantal)";
                    SqlCommand command2 = new(sql2, connection);
                    command2.Transaction = transaction;
                    command2.Parameters.AddWithValue("@BestellingID", bestellingsId);
                    command2.Parameters.AddWithValue("@TruitjeID", voetbaltruitje.Key.Id);
                    command2.Parameters.AddWithValue("@Aantal", voetbaltruitje.Value);
                    command2.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new BestellingRepositoryADOException("BestellingToevoegen - error", ex);
            }
            finally
            {
                connection.Close();
            }

        }

        public void BestellingUpdaten(Bestelling bestelling)
        {
            //TODO: Update van een bestelling
            var producten = bestelling.GeefProducten();
            string sql = "UPDATE [dbo].[Bestellingen] SET Verkoopprijs = @Verkoopprijs, Betaald = @Betaald, KlantID = @KlantID WHERE Id = @Id";
            string sql2 = "INSERT INTO [dbo].[BestellingTruitje] (BestellingID, TruitjeID, Aantal) VALUES (@BestellingID, @TruitjeID, @Aantal)";
            string sql3 = "DELETE FROM [dbo].[BestellingTruitje] WHERE BestellingID = @BestellingID";
            SqlConnection connection = GetConnection();
            SqlCommand command = new(sql, connection);
            SqlCommand command3 = new(sql3, connection);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            command3.Transaction = transaction;
            try
            {
                command.Parameters.AddWithValue("@Verkoopprijs", bestelling.Prijs);
                command.Parameters.AddWithValue("@Betaald", bestelling.Betaald);
                command.Parameters.AddWithValue("@KlantID", bestelling.Klant.KlantId);
                command.Parameters.AddWithValue("@Id", bestelling.BestellingId);
                command.ExecuteNonQuery();
                command3.Parameters.AddWithValue("@BestellingID", bestelling.BestellingId);
                command3.ExecuteNonQuery();

                foreach (var voetbaltruitje in producten)
                {
                    SqlCommand command2 = new(sql2, connection);
                    command2.Transaction = transaction;
                    command2.Parameters.AddWithValue("@BestellingID", bestelling.BestellingId);
                    command2.Parameters.AddWithValue("@TruitjeID", voetbaltruitje.Key.Id);
                    command2.Parameters.AddWithValue("@Aantal", voetbaltruitje.Value);
                    command2.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new BestellingRepositoryADOException("BestellingToevoegen - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void BestellingVerwijderen(Bestelling bestelling)
        {
            string sql = "DELETE FROM [dbo].[BestellingTruitje] WHERE BestellingID = @BestellingID";
            string sql2 = "DELETE FROM [dbo].[Bestellingen] WHERE Id = @BestellingID";
            SqlConnection connection = GetConnection();
            using SqlCommand command = new(sql, connection);
            using SqlCommand command2 = new(sql2, connection);
            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            command2.Transaction = transaction;
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@BestellingID", bestelling.BestellingId);
                command.ExecuteNonQuery();

                command2.Parameters.AddWithValue("@BestellingID", bestelling.BestellingId);
                command2.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new BestellingRepositoryADOException("BestellingVerwijderen - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Bestelling> BestellingWeergeven(int id, DateTime? start, DateTime? end, Klant _klantSave)
        {
            List<Bestelling> bestellingen = new();
            bool isWhere = true;
            bool isAnd = false;
            string sql = "SELECT b.*, k.Id AS KlantId, k.Naam, k.Adres FROM [dbo].[Bestellingen] b " +
                "INNER JOIN [dbo].[Klant] k ON b.KlantID = k.Id";
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
                sql += "b.Id = @Id";
            }
            if (start != null)
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
                sql += "b.Datum >= @Start";
            }
            if (end != null)
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
                sql += "b.Datum <= @Einde";
            }
            if (_klantSave != null)
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
                sql += "b.KlantID = @KlantId";
            }
            SqlConnection connection = GetConnection();
            SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                if (id != 0)
                {
                    command.Parameters.AddWithValue("@Id", id);
                }
                if (start != null)
                {
                    command.Parameters.AddWithValue("@Start", start);
                }
                if (end != null)
                {
                    command.Parameters.AddWithValue("@Einde", end);
                }
                if (_klantSave != null)
                {
                    command.Parameters.AddWithValue("@KlantID", _klantSave.KlantId);
                }
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Klant klant = new((int)reader["KlantId"], (string)reader["Naam"], (string)reader["Adres"]);
                    int bestellingId = (int)reader["Id"];
                    Bestelling bestelling = new(bestellingId, klant, (DateTime)reader["Datum"], (double)reader["Verkoopprijs"], (bool)reader["Betaald"], BestellingProductenWeergeven(bestellingId));
                    bestellingen.Add(bestelling);
                }
                return bestellingen;
            }
            catch (Exception ex)
            {
                throw new BestellingRepositoryADOException("BestellingWeergeven - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        private Dictionary<Voetbaltruitje, int> BestellingProductenWeergeven(int bestellingsId)
        {
            Dictionary<Voetbaltruitje, int> producten = new();
            string sql2 = "SELECT bt.Id AS BTId, bt.BestellingID, bt.TruitjeID, bt.Aantal, t.* FROM [dbo].[BestellingTruitje] bt " +
                "INNER JOIN [dbo].[Truitje] t ON bt.TruitjeID = t.Id;";
            SqlConnection connection = GetConnection();
            SqlCommand command2 = new(sql2, connection);
            try
            {
                connection.Open();
                IDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    if (bestellingsId == (int)reader2["BestellingID"])
                    {
                        Club club = new((string)reader2["Competitie"], (string)reader2["Ploeg"]);
                        ClubSet clubSet = new((bool)reader2["Thuis"], (int)reader2["Versie"]);
                        Kledingmaat kledingmaat = (Kledingmaat)Enum.Parse(typeof(Kledingmaat), (string)reader2["Maat"]);
                        Voetbaltruitje voetbaltruitje = new((int)reader2["Id"], club, (string)reader2["Seizoen"], (double)reader2["Prijs"], kledingmaat, clubSet);
                        int aantal = (int)reader2["Aantal"];
                        producten.Add(voetbaltruitje, aantal);
                    }
                }
                return producten;
            }
            catch (Exception ex)
            {
                throw new BestellingRepositoryADOException("BestellingProductenWeergeven - error", ex);
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion
    }
}
