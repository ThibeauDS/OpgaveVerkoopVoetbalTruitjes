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
            foreach (var voetbaltruitje in producten)
            {
                string sql = "INSERT INTO [dbo].[Bestellingen] (Datum, Verkoopprijs, Betaald, KlantID, TruitjeID) VALUES (@Datum, @Verkoopprijs, @Betaald, @KlantID, @TruitjeID) SELECT SCOPE_IDENTITY()";
                string sql2 = "INSERT INTO [dbo].[BestellingTruitje] (BestellingID, TruitjeID, Aantal) VALUES (@BestellingID, @TruitjeID, @Aantal)";
                SqlConnection connection = GetConnection();
                SqlCommand command = new(sql, connection);
                SqlCommand command2 = new(sql2, connection);
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Datum", bestelling.Tijdstip);
                    command.Parameters.AddWithValue("@Verkoopprijs", bestelling.Prijs);
                    command.Parameters.AddWithValue("@Betaald", bestelling.Betaald);
                    command.Parameters.AddWithValue("@KlantID", bestelling.Klant.KlantId);
                    command.Parameters.AddWithValue("@TruitjeID", voetbaltruitje.Key.Id);
                    bestellingsId = Decimal.ToInt32((decimal)command.ExecuteScalar());
                    command2.Parameters.AddWithValue("@BestellingID", bestellingsId);
                    command2.Parameters.AddWithValue("@TruitjeID", voetbaltruitje.Key.Id);
                    command2.Parameters.AddWithValue("@Aantal", voetbaltruitje.Value);
                    command2.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new BestellingRepositoryADOException("BestellingToevoegen - error", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void BestellingUpdaten(Bestelling bestelling)
        {
            //TODO: Update van een bestelling
            throw new NotImplementedException();
        }

        public void BestellingVerwijderen(Bestelling bestelling)
        {
            //TODO: Delete van bestelling
            throw new NotImplementedException();
        }

        public List<Bestelling> BestellingWeergeven(int id, DateTime? start, DateTime? end, Klant _klantSave)
        {
            List<Bestelling> bestellingen = new();
            Dictionary<Voetbaltruitje, int> producten = new();
            bool isWhere = true;
            bool isAnd = false;
            string sql = "SELECT b.*, bt.BestellingID AS BestellingId, bt.TruitjeID AS TruitjeId, bt.Aantal, t.Id AS VoetbaltruitjeId, t.Maat, t.Seizoen, t.Prijs, t.Versie, t.Thuis, t.Competitie, t.Ploeg, k.Id AS KlantId, k.Naam, k.Adres FROM [dbo].[Bestellingen] b " +
                "INNER JOIN[dbo].[BestellingTruitje] bt ON b.Id = bt.BestellingID " +
                "INNER JOIN[dbo].[Truitje] t ON bt.TruitjeID = t.Id " +
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
                sql += "b.KlantID <= @KlantId";
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
                    Club club = new((string)reader["Competitie"], (string)reader["Ploeg"]);
                    ClubSet clubSet = new((bool)reader["Thuis"], (int)reader["Versie"]);
                    Kledingmaat kledingmaat = (Kledingmaat)Enum.Parse(typeof(Kledingmaat), (string)reader["Maat"]);
                    Voetbaltruitje voetbaltruitje = new((int)reader["VoetbaltruitjeId"], club, (string)reader["Seizoen"], (double)reader["Prijs"], kledingmaat, clubSet);
                    int aantal = (int)reader["Aantal"];
                    producten.Add(voetbaltruitje, aantal);
                    Klant klant = new((int)reader["KlantId"], (string)reader["Naam"], (string)reader["Adres"]);
                    Bestelling bestelling = new((int)reader["Id"], klant, (DateTime)reader["Datum"], (double)reader["Verkoopprijs"], (bool)reader["Betaald"], producten);
                    bestellingen.Add(bestelling);
                    producten.Clear();
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
        #endregion
    }
}
