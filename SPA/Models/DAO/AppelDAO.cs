﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SPA.Models.DAO
{
    public static class AppelDAO
    {
        public static List<Appel> GetListAppel(string id)
        {
            List<Appel> appels = new List<Appel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    string query = @"SELECT * FROM Appel WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Appel appel = new Appel();
                            appel.Enquete.Id = dr.GetString(0);
                            appel.Date = dr.GetDateTime(1);
                            appel.Commentaire = dr.GetString(2);
                            appels.Add(appel);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return appels;
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        public static bool AddAppel(Appel appel)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"INSERT INTO Appel (Id_enquete, Date, Commentaire) VALUES (@Id, @Date, @Commentaire);";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", appel.Enquete.Id);
                    cmd.Parameters.AddWithValue("@Date", appel.Date);
                    cmd.Parameters.AddWithValue("@Commentaire", appel.Commentaire);

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
