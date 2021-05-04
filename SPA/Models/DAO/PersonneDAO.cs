using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SPA.Models
{
    public static class PersonneDAO
    {
        public static Personne GetPersonne(int id)
        {
            Personne personne = new Personne();
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"SELECT * FROM Personne WHERE Id = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    //open connection
                    conn.Open();

                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //display retrieved record (first column only/string value)
                            personne.Id = dr.GetInt32(0);
                            personne.Nom = dr.GetString(1);
                            personne.Prenom = dr.GetString(2);
                            personne.Adresse = dr.GetString(3);
                            personne.Code_postal = dr.GetInt32(4);
                            personne.Ville = dr.GetString(5);
                            personne.Email = dr.GetString(6);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return personne;
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public static bool ExistPersonne(Personne personne)
        {
            string nom = personne.Nom;
            string prenom = personne.Prenom;

            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"SELECT * FROM Personne WHERE Nom = @Nom AND Prenom = @Prenom";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nom", nom);
                    cmd.Parameters.AddWithValue("@Prenom", prenom);
                    //open connection
                    conn.Open();

                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records
                    if (dr.HasRows)
                    {
                        res = true;
                    }
                    dr.Close();
                }
                return res;
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
        }
        public static List<Personne> GetAllPersonne()
        {
            List<Personne> list = new List<Personne>();
            Personne personne = new Personne();
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"SELECT * FROM Personne";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    //open connection
                    conn.Open();

                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        { 
                            //display retrieved record (first column only/string value)
                            personne.Id = dr.GetInt32(0);
                            personne.Nom = dr.GetString(1);
                            personne.Prenom = dr.GetString(2);
                            personne.Adresse = dr.GetString(3);
                            personne.Code_postal = dr.GetInt32(4);
                            personne.Ville = dr.GetString(5);
                            personne.Email = dr.GetString(6);
                            list.Add(personne);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return list;
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public static List<Personne> GetAllSalarieBenevole()
        {
            List<Personne> list = new List<Personne>();
            Personne personne = new Personne();
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"SELECT * FROM Personne WHERE Salarie = 1 OR Benevole = 1";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    //open connection
                    conn.Open();

                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //display retrieved record (first column only/string value)
                            personne.Id = dr.GetInt32(0);
                            personne.Nom = dr.GetString(1);
                            personne.Prenom = dr.GetString(2);
                            personne.Adresse = dr.GetString(3);
                            personne.Code_postal = dr.GetInt32(4);
                            personne.Ville = dr.GetString(5);
                            personne.Email = dr.GetString(6);
                            list.Add(personne);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return list;
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// ajoute une personne en base de données et retourne l'id généré
        /// </summary>
        /// <param name="personne"></param>
        /// <returns></returns>
        public static int AddPersonne(Personne personne)
        {
            int res = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"INSERT INTO Personne (Nom, Prenom, Adresse, Code_postal, Ville, Email, Salarie, Benevole, Id_refuge) output INSERTED.Id VALUES (@Nom, @Prenom, @Adresse, @CP, @Ville, @Email, @Salarie, @Benevole, @IdRefuge);";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Nom", personne.Nom);
                    cmd.Parameters.AddWithValue("@Prenom", personne.Prenom);
                    cmd.Parameters.AddWithValue("@Adresse", personne.Adresse);
                    cmd.Parameters.AddWithValue("@CP", personne.Code_postal);
                    cmd.Parameters.AddWithValue("@Ville", personne.Ville);
                    cmd.Parameters.AddWithValue("@Email", personne.Email);
                    cmd.Parameters.AddWithValue("@Salarie", personne.Email);
                    cmd.Parameters.AddWithValue("@Benevole", personne.Email);
                    cmd.Parameters.AddWithValue("@IdRefuge", personne.Email);

                    //open connection
                    conn.Open();

                    res = (int)cmd.ExecuteScalar();
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                res = -1;
                return res;
            }
        }
    }
}
