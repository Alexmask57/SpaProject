using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SPA.Models.DAO
{
    public static class CommentaireDAO
    {
        /// <summary>
        /// Récupere les commentaires d'une enquete a partir de son id
        /// </summary>
        /// <param name="id">id de l'enquete</param>
        /// <returns></returns>
        public static List<Commentaire> GetListCommentaire(string id)
        {
            List<Commentaire> commentaires = new List<Commentaire>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    string query = @"SELECT * FROM Commentaires WHERE Id_enquete = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Commentaire commentaire = new Commentaire();
                            commentaire.Enquete.Id = dr.GetString(0);
                            commentaire.Date = dr.GetDateTime(1);
                            commentaire.Detail = dr.GetString(2);
                            commentaires.Add(commentaire);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return commentaires;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Ajout un commentaire pour une enquete
        /// </summary>
        /// <param name="commentaire">Commentaire à ajouter dans la BDD</param>
        /// <returns></returns>
        public static bool AddCommentaire(Commentaire commentaire)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"INSERT INTO Commentaires (Id_enquete, Date, Commentaire) VALUES (@Id, @Date, @Detail);";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", commentaire.Enquete.Id);
                    cmd.Parameters.AddWithValue("@Date", commentaire.Date);
                    cmd.Parameters.AddWithValue("@Detail", commentaire.Detail);

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

        public static bool UpdateCommentaire(Commentaire commentaire)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"UPDATE Commentaires SET Date = @Date, Commentaire = @Detail WHERE Id_enquete = @Id;";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", commentaire.Enquete.Id);
                    cmd.Parameters.AddWithValue("@Date", commentaire.Date);
                    cmd.Parameters.AddWithValue("@Detail", commentaire.Detail);

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

        public static bool DeleteCommentaire(Enquete enquete)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"DELETE FROM Commentaires WHERE Id_enquete = @Id";

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

        public static bool DeleteCommentaire(Commentaire commentaire)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"DELETE FROM Commentaires WHERE Id_enquete = @Id AND Date = @Date And Commentaire = @Detail";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", commentaire.Enquete.Id);
                    cmd.Parameters.AddWithValue("@Date", commentaire.Date);
                    cmd.Parameters.AddWithValue("@Detail", commentaire.Detail);

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

        public static int GetNombreCommentaire(string Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"SELECT count(*) FROM Commentaires WHERE Id_enquete = @Id";

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
