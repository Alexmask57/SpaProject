using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SPA.Models.DAO
{
    public static class DocumentDAO
    {
        /// <summary>
        /// Récupere les commentaires d'une enquete a partir de son id
        /// </summary>
        /// <param name="id">id de l'enquete</param>
        /// <returns></returns>
        public static List<Document> GetListDocument(string id)
        {
            List<Document> documents = new List<Document>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    string query = @"SELECT * FROM Document WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Document document = new Document();
                            document.Enquete.Id = dr.GetString(0);
                            document.Date = dr.GetDateTime(1);
                            document.Chemin = dr.GetString(2);
                            documents.Add(document);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return documents;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Ajout un document pour une enquete
        /// </summary>
        /// <param name="document">Document à ajouter dans la BDD</param>
        /// <returns></returns>
        public static bool AddDocument(Document document)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"INSERT INTO Document (Id_enquete, Date, Chemin) VALUES (@Id, @Date, @Chemin);";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", document.Enquete.Id);
                    cmd.Parameters.AddWithValue("@Date", document.Date);
                    cmd.Parameters.AddWithValue("@CHemin", document.Chemin);

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

        public static bool UpdateDocument(Document document)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"UPDATE Document SET Date = @Date, Chemin = @Chemin;";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Date", document.Date);
                    cmd.Parameters.AddWithValue("@Chemin", document.Chemin);

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

        public static bool DeleteDocument(Enquete enquete)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"DELETE FROM Document WHERE Id = @Id";

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

        public static int GetNombreDocument(string Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"SELECT count(*) FROM Document WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    //open connection
                    conn.Open();

                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            return dr.GetInt32(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
