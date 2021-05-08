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
                throw;
            }
        }

        public static Personne GetPersonne(string nom, string prenom)
        {
            Personne personne = new Personne();
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"SELECT * FROM Personne WHERE Nom = @nom and Prenom = @prenom";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@prenom", prenom);
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
                            personne.Salarie = IntToBool(dr.GetInt32(7));
                            personne.Benevole = IntToBool(dr.GetInt32(8));
                            personne.Refuge = Refuge.GetRefugeById(dr.GetInt32(9));
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
                throw;
            }
        }

        public static bool UpdatePersonne(Personne personne)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"UPDATE Personne SET Nom = @Nom, Prenom = @Prenom, Adresse = @Adresse, Code_postal = @Code_postal, Ville = @Ville, Email = @Email, Salarie = @Salarie, Benevole = @Benevole, Id_refuge = @IdRefuge WHERE Id = @Id;";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", personne.Id);
                    cmd.Parameters.AddWithValue("@Nom", personne.Nom);
                    cmd.Parameters.AddWithValue("@Prenom", personne.Prenom);
                    cmd.Parameters.AddWithValue("@Adresse", personne.Adresse);
                    cmd.Parameters.AddWithValue("@Code_postal", personne.Code_postal);
                    cmd.Parameters.AddWithValue("@Ville", personne.Ville);
                    cmd.Parameters.AddWithValue("@Email", personne.Email);
                    cmd.Parameters.AddWithValue("@Salarie", BoolToInt(personne.Salarie));
                    cmd.Parameters.AddWithValue("@Benevole", BoolToInt(personne.Benevole));
                    cmd.Parameters.AddWithValue("@IdRefuge", personne.Refuge.Id);

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
                throw;
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
                throw;
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
                            personne.Salarie = IntToBool(dr.GetInt32(7));
                            personne.Benevole = IntToBool(dr.GetInt32(8));
                            personne.Refuge = Refuge.GetRefugeById(dr.GetInt32(9));
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
                throw;
            }
        }

        public static List<Personne> GetAllSalarieBenevole()
        {
            List<Personne> list = new List<Personne>();
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
                            Personne personne = new Personne();
                            //display retrieved record (first column only/string value)
                            personne.Id = dr.GetInt32(0);
                            personne.Nom = dr.GetString(1);
                            personne.Prenom = dr.GetString(2);
                            personne.Adresse = dr.GetString(3);
                            personne.Code_postal = dr.GetInt32(4);
                            personne.Ville = dr.GetString(5);
                            personne.Email = dr.GetString(6);
                            personne.Salarie = IntToBool(dr.GetInt32(7));
                            personne.Benevole = IntToBool(dr.GetInt32(8));
                            if (personne.Benevole || personne.Salarie)
                                personne.Refuge = Refuge.GetRefugeById(dr.GetInt32(9));
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
                throw;
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
                    cmd.Parameters.AddWithValue("@Salarie", BoolToInt(personne.Salarie));
                    cmd.Parameters.AddWithValue("@Benevole", BoolToInt(personne.Benevole));
                    cmd.Parameters.AddWithValue("@IdRefuge", personne.Refuge.Id);

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
                throw;
            }
        }

        public static bool DeletePersonne(Personne personne)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"DELETE FROM Personne WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", personne.Id);

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
                throw;
            }
        }

        private static bool IntToBool(int entier)
        {
            if (entier == 1)
                return true;
            else
                return false;
        }

        private static int BoolToInt(bool booleen)
        {
            if (booleen)
                return 1;
            return 0;
        }
    }
}
