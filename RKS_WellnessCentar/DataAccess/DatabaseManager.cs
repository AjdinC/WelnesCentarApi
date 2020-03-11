using Dapper;
using Dapper.Contrib.Extensions;
using RKS_WellnessCentar.Models;
using RKS_WellnessCentar.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace RKS_WellnessCentar.DataAccess
{
    public partial class DatabaseManager
    {
        string sqlConnectionString;
        private static DatabaseManager _Instance;

        public static DatabaseManager Instance
        {
            get { if (_Instance == null) _Instance = new DatabaseManager(); return DatabaseManager._Instance; }
            set { DatabaseManager._Instance = value; }
        }

        public string SqlConnectionString
        { get { return sqlConnectionString; } set { sqlConnectionString = value; } }
        public DatabaseManager()
        {

        }

        public IEnumerable<T> GetList<T>(string database, string tableName = null)
        {
            string TableName = tableName;
            if (TableName == null)
            {
                TableName = (typeof(T)).Name;
            }
            using (var sqlConnection =
    new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                sqlConnection.Open();
                string query = String.Format(@"Select * from {0} ", TableName);

                //query += " where DataDeleted=0 ";
                var returnValue =
                    sqlConnection.Query<T>(query);

                sqlConnection.Close();
                return returnValue;

            }
        }

        public T GetByID<T>(string database, object ID, string tableName = null)
        {
            string TableName = tableName;

            if (TableName == null)
            {
                TableName = (typeof(T)).Name;
            }
            using (var sqlConnection =
            new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                sqlConnection.Open();
                string query = String.Format(@"Select * from  {0} ", TableName);


                query += " where ID=@ID";
                var returnValue =
                    sqlConnection.Query<T>(query, new { ID = ID });

                sqlConnection.Close();
                return returnValue.FirstOrDefault();

            }
        }

        public bool DeleteRecord(string database, string tableName, long ID)
        {
            using (var sqlConnection =
         new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                sqlConnection.Open();
                try
                {
                    string sql = "update " + tableName + " set DataDeleted=1,DataDeletedDate=@DateDeletedDate where id=@ID";
                    var returnId = sqlConnection.Query<int>(sql, new { ID = ID, DateDeletedDate = DateTime.Now }).SingleOrDefault();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    sqlConnection.Close();
                }

            }

        }

        public bool Update<T>(string database, T entity) where T : class
        {

            using (var sqlConnection =
        new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                sqlConnection.Open();
                try
                {
                    var returnId = sqlConnection.UpdateAsync(entity).GetAwaiter().GetResult();

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    sqlConnection.Close();
                }
                return true;

            }
        }

        public bool Delete<T>(string database, long ID, string tableName = null) where T : class
        {
            string TableName = tableName;
            if (TableName == null)
            {
                TableName = (typeof(T)).Name;
            }
            return DeleteRecord(database, TableName, ID);
        }



        public bool Insert<T>(string database, T entity) where T : class
        {

            using (var sqlConnection =
        new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                sqlConnection.Open();
                try
                {
                    var returnId = sqlConnection.InsertAsync(entity).GetAwaiter().GetResult();

                }

                catch (Exception ex)
                {

                    return false;
                }
                finally
                {
                    sqlConnection.Close();
                }
                return true;
               
            }
        }
        public Korisnik Login(string database, string KorisnickoIme, string Lozinka, string tableName = null)
        {
            using (var sqlConnection =
            new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                sqlConnection.Open();
                string query = String.Format(@"SELECT * FROM Korisnik WHERE KorisnickoIme = @KorisnickoIme AND Lozinka = @Lozinka COLLATE SQL_Latin1_General_CP1_CS_AS");

                var returnValue =
                    sqlConnection.Query<Korisnik>(query, new { KorisnickoIme = KorisnickoIme, Lozinka = Lozinka });

                sqlConnection.Close();
                return returnValue.FirstOrDefault();

            }
        }
        public Korisnik Registracija(string database,string ime, string prezime, string email, string telefon, string korisnickoIme, string lozinka)
        {
            using (var sqlConnection =
                new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                sqlConnection.Open();
                string query = String.Format(@"INSERT INTO Korisnik VALUES(Ime = @ime,Prezime =@prezime, Email = @Email, Telefon = @telefon, KorisnickoIme = @korisnickoIme, Lozinka = @lozinka");

                var returnValue = sqlConnection.Query<Korisnik>(query, new { Ime = ime, Prezime = prezime, Email = email, Telefon = telefon, KorisnickoIme = korisnickoIme, Lozinka = lozinka });


                sqlConnection.Close();
                return returnValue.FirstOrDefault();
            }
        }

        public IEnumerable<T> GetTretmaniSlike<T>(string database, string tableName = null)
        {
            string TableName = tableName;
            if (TableName == null)
            {
                TableName = (typeof(T)).Name;
            }
            using (var sqlConnection =
    new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                sqlConnection.Open();
                string query = String.Format(@"Select T.ID AS id,T.Naziv AS naziv,T.Opis AS opis,T.Cijena AS cijena,
S.URL AS urlSlika
 from Tretman AS T
 left join Slika AS S ON (T.ID = S.FK_Tretman) ", TableName);

                //query += " where DataDeleted=0 ";
                var returnValue =
                    sqlConnection.Query<T>(query);

                sqlConnection.Close();
                return returnValue;

            }
        }
        public List<Detalji> GetTretmanDetalji(string database, object ID)
        {
          
            using (var sqlConnection =
            new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                sqlConnection.Open();
                string query = String.Format(@"select *
from Detalji ");


                query += " where FK_Tretman=@ID";
                var returnValue =
                    sqlConnection.Query<Detalji>(query, new { ID = ID });

                sqlConnection.Close();
                return returnValue.ToList();

            }
        }
        public bool UpdateLozinka(string database, int id, string lozinka)
        {
            using (var sqlConnection =
                new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                try
                {
                    sqlConnection.Open();
                    string query = String.Format(@"UPDATE Korisnik SET Lozinka = @lozinka WHERE ID = @id");

                    var returnValue = sqlConnection.Query(query, new { id,  lozinka});


                    sqlConnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
               
            }
        }
        public bool AzurirajKorisnickiRacun(string database, int id, string ime, string prezime, string email, string telefon, string korisnickoIme)
        {
            using (var sqlConnection =
                new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                try
                {
                    sqlConnection.Open();
                    string query = String.Format(@"UPDATE Korisnik SET Ime = @ime, Prezime = @prezime, Email = @email, Telefon = @telefon, KorisnickoIme = @korisnickoIme 
WHERE ID = @id");
                    
                    var returnValue = sqlConnection.Query(query, new { id, ime,prezime,email,telefon,korisnickoIme });


                    sqlConnection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }

        public List<MojeRezervacijeVM> GetKorisnikRezervacije(string database, object ID)
        {

            using (var sqlConnection =
            new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                sqlConnection.Open();
                string query = String.Format(@"select r.*,t.Naziv AS tretmanNaziv,sr.Naziv AS statusRezervacije,s.URL AS urlSlika
from Rezervacija AS r
LEFT JOIN StatusRezervacije AS sr ON (sr.ID = r.FK_StatusRezervacije)
LEFT JOIN Tretman AS t ON (t.ID = r.FK_Tretman)
LEFT JOIN Slika AS s ON (s.FK_Tretman = t.ID)");


                query += " where r.FK_Korisnik=@ID AND r.DataDeleted = 0";
                var returnValue =
                    sqlConnection.Query<MojeRezervacijeVM>(query, new { ID = ID });

                sqlConnection.Close();
                return returnValue.ToList();
            }
        }
        public List<Rezervacija> GetRezervacije(string database, object ID)
        {

            using (var sqlConnection =
            new SqlConnection(String.Format(sqlConnectionString, database)))
            {
                sqlConnection.Open();
                string query = String.Format(@"select * from Rezervacija");


                query += " where FK_Korisnik=@ID";
                var returnValue =
                    sqlConnection.Query<Rezervacija>(query, new { ID = ID });

                sqlConnection.Close();
                return returnValue.ToList();
            }
        }
    }
}
