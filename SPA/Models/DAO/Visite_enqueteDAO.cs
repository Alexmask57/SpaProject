using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SPA.Models.DAO
{
    public static class Visite_enqueteDAO
    {

        public static int AddVisiteEnquete(Visite_enquete visite_enquete)
        {
            int res = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"INSERT INTO Visite_enquete (Id, Id_enquete, Titulaire_enquete, Delegue_enqueteur, Date_visite, Avis_passage) output INSERTED.Id VALUES (@Id, @Titulaire_enquete, @Delegue_enquete, @Infracteur, @Plaignant, 0, '');";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", visite_enquete.Id);
                    cmd.Parameters.AddWithValue("@Id_enquete", visite_enquete.Enquete.Id);
                    cmd.Parameters.AddWithValue("@Titulaire_enquete", visite_enquete.Titulaire_enquete.Id);
                    cmd.Parameters.AddWithValue("@Delegue_enquete", visite_enquete.Delegue_enqueteur.Id);
                    cmd.Parameters.AddWithValue("@Date_visite", visite_enquete.Date_visite);
                    cmd.Parameters.AddWithValue("@Avis_passage", visite_enquete.Avis_passage);

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

        public static List<Visite_enquete> GetAllVisiteEnquete(string id)
        {
            List<Visite_enquete> listeVisiteEnquete = new List<Visite_enquete>();
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    string query = @"SELECT * FROM Visite_enquete WHERE Id_enquete = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Visite_enquete visite_enquete = new Visite_enquete();
                            //display retrieved record (first column only/string value)
                            visite_enquete.Id = dr.GetInt32(0);
                            visite_enquete.Enquete.Id = id;
                            visite_enquete.Titulaire_enquete = Personne.GetPersonneById(dr.GetInt32(1));
                            visite_enquete.Delegue_enqueteur = Personne.GetPersonneById(dr.GetInt32(2));
                            visite_enquete.Date_visite = dr.GetDateTime(3);
                            visite_enquete.Avis_passage = IntToBool(dr.GetInt32(4));
                            listeVisiteEnquete.Add(visite_enquete);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return listeVisiteEnquete;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool DeleteVisiteEnquete(Enquete enquete)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"DELETE FROM Visite_enquete WHERE Id_enquete = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", enquete.Id);

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

        public static bool UpdateVisiteEnquete(Visite_enquete visite_enquete)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"UPDATE Visite_enquete SET Titulaire_enquete = @Titulaire_enquete, Delegue_enquete = @Delegue_enquete, Date_visite = @Date_visite, Avis_passage = @Avis_passage WHERE Id_enquete = @Id;";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", visite_enquete.Id);
                    cmd.Parameters.AddWithValue("@Id_enquete", visite_enquete.Enquete.Id);
                    cmd.Parameters.AddWithValue("@Titulaire_enquete", visite_enquete.Titulaire_enquete.Id);
                    cmd.Parameters.AddWithValue("@Delegue_enquete", visite_enquete.Delegue_enqueteur.Id);
                    cmd.Parameters.AddWithValue("@Date_visite", visite_enquete.Date_visite);
                    cmd.Parameters.AddWithValue("@Avis_passage", BoolToInt(visite_enquete.Avis_passage));

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

        public static bool DeleteVisite(Visite_enquete visite)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"DELETE FROM Visite_enquete WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", visite.Id);

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
