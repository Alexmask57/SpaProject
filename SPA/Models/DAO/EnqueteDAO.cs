using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SPA.Models
{
    public static class EnqueteDAO
    {
        public static Session GetEnquete(string id)
        {
            Session session = new Session();
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"SELECT * FROM Enquete WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
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
                            session.Id = dr.GetInt32(0);
                            session.Login = dr.GetString(1);
                            session.Password = dr.GetString(2);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return session;
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }


        public static bool AddEnquete(Enquete enquete)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"INSERT INTO Enquete (Id, Titulaire_enquete, Delegue_enquete, Infracteur, Plaignant, Etat, Avis) VALUES (@Id, @Titulaire_enquete, @Delegue_enquete, @Infracteur, @Plaignant, 0, '');";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", enquete.Id);
                    cmd.Parameters.AddWithValue("@Titulaire_enquete", enquete.Titulaire_enquete.Id);
                    cmd.Parameters.AddWithValue("@Delegue_enquete", enquete.Delegue_enqueteur.Id);
                    cmd.Parameters.AddWithValue("@Infracteur", enquete.Delegue_enqueteur.Id);
                    cmd.Parameters.AddWithValue("@Plaignant", enquete.Delegue_enqueteur.Id);

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
                Console.WriteLine("Exception: " + ex.Message);
                res = false;
                return res;
            }
        }
    }
}
