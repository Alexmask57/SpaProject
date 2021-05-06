using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SPA.Models.DAO
{
    public static class RefugeDAO
    {
        /// <summary>
        /// Recupere le refuge d'une personne
        /// </summary>
        /// <param name="personne">personne</param>
        /// <returns></returns>
        public static Refuge GetRefuge(Personne personne)
        {
            Refuge refuge = new Refuge();
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    string query = @"SELECT * FROM Refuge WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", personne.Refuge.Id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            refuge.Id = dr.GetInt32(0);
                            refuge.Nom = dr.GetString(1);
                            refuge.Departement = dr.GetInt32(2);
                        }
                    }
                    else
                    {
                        return null;
                    }
                    dr.Close();
                }
                return refuge;
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public static Refuge GetRefugeById(int entier)
        {
            Refuge refuge = new Refuge();
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    string query = @"SELECT * FROM Refuge WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", entier);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            refuge.Id = dr.GetInt32(0);
                            refuge.Nom = dr.GetString(1);
                            refuge.Departement = dr.GetInt32(2);
                        }
                    }
                    else
                    {
                        return null;
                    }
                    dr.Close();
                }
                return refuge;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
