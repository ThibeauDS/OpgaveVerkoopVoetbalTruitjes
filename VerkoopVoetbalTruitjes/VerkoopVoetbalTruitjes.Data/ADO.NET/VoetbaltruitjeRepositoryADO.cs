using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VerkoopVoetbalTruitjes.Domain.Interfaces;
using VerkoopVoetbalTruitjes.Domain.Klassen;

namespace VerkoopVoetbalTruitjes.Data.ADO.NET
{
    //TODO: Moet nog geïmplementeerd worden
    public class VoetbaltruitjeRepositoryADO : IVoetbaltruitjeRepository
    {
        private string _connectionString;

        public VoetbaltruitjeRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return connection;
        }
        public bool BestaatVoetbaltruitje(Voetbaltruitje voetbaltruitje)
        {
            throw new NotImplementedException();
        }

        public void VoetbaltruitjeToevoegen(Voetbaltruitje voetbaltruitje)
        {
            throw new NotImplementedException();
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

        public IReadOnlyList<Voetbaltruitje> GeefTruitjes(string competitie, string club, string seizoen, string kledingmaat, int? versie, bool? thuis, double? prijs, bool strikt = true)
        {
            List<Voetbaltruitje> voetbaltruitjes = new();
            SqlConnection connection = getConnection();
            string query = "SELECT * FROM dbo.Voetbaltruitje WHERE ";
            bool AND = false;
            if (!string.IsNullOrWhiteSpace(competitie))
            {
                AND = true;
                if (strikt)
                {
                    query += " competitie=@competitie";
                }
                else
                {
                    query += " UPPER(competitie)=UPPER(@competitie)";
                }
            }
            if (!string.IsNullOrWhiteSpace(club))
            {
                if (AND) query += " AND "; else AND = true;
                if (strikt)
                {
                    query += " club=@club";
                }
                else
                {
                    query += " UPPER(club)=UPPER(@club)";
                }
            }
            if (!string.IsNullOrWhiteSpace(seizoen))
            {
                if (AND) query += " AND "; else AND = true;
                if (strikt)
                {
                    query += " seizoen=@seizoen";
                }
                else
                {
                    query += " UPPER(seizoen)=UPPER(@seizoen)";
                }
            }
            if (!string.IsNullOrWhiteSpace(kledingmaat))
            {
                if (AND) query += " AND "; else AND = true;
                if (strikt)
                {
                    query += " kledingmaat=@kledingmaat";
                }
                else
                {
                    query += " UPPER(kledingmaat)=UPPER(@kledingmaat)";
                }
            }
            if (versie != null)
            {

            }
            if (thuis != null)
            {

            }
            if (prijs != null)
            {

            }

            using (SqlCommand command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    if (!string.IsNullOrWhiteSpace(competitie))
                    {
                        command.Parameters.Add(new SqlParameter("@competitie", SqlDbType.NVarChar));
                        command.Parameters[@competitie].Value = competitie;
                    }
                    command.CommandText = query;
                    if (!string.IsNullOrWhiteSpace(club))
                    {
                        command.Parameters.Add(new SqlParameter("@club", SqlDbType.NVarChar));
                        command.Parameters[@club].Value = club;
                    }
                    command.CommandText = query;
                    if (!string.IsNullOrWhiteSpace(seizoen))
                    {
                        command.Parameters.Add(new SqlParameter("@seizoen", SqlDbType.NVarChar));
                        command.Parameters[@seizoen].Value = seizoen;
                    }
                    command.CommandText = query;
                    if (!string.IsNullOrWhiteSpace(kledingmaat))
                    {
                        command.Parameters.Add(new SqlParameter("@kledingmaat", SqlDbType.NVarChar));
                        command.Parameters[@kledingmaat].Value = kledingmaat;
                    }
                    command.CommandText = query;

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int voetbaltruitjeId = (int)dataReader["Id"];
                    }
                }
                catch (System.Exception)
                {

                    throw;
                }
                return voetbaltruitjes;
            }
        }
    }
}
