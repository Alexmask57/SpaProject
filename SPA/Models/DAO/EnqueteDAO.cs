using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SPA.Models
{
    public static class EnqueteDAO
    {
        public static Enquete GetEnquete(string id)
        {
            Enquete enquete = new Enquete();
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
                            enquete.Id = dr.GetString(0);
                            enquete.Titulaire_enquete = Personne.GetPersonneById(dr.GetInt32(1));
                            enquete.Delegue_enqueteur = Personne.GetPersonneById(dr.GetInt32(2));
                            enquete.Plaignant = Personne.GetPersonneById(dr.GetInt32(3));
                            enquete.Infracteur = Personne.GetPersonneById(dr.GetInt32(4));
                            enquete.Avis = dr.GetString(5);
                            enquete.Etat = dr.GetInt32(6);
                            enquete.OuvertParLeSiege = IntToBool(dr.GetInt32(7));
                            enquete.Motif = dr.GetString(8);
                            enquete.Animaux = Animaux_enquete.GetAnimaux_EnquetesBdd(enquete.Id);
                            enquete.Document = Document.GetListDocument(enquete.Id);
                            enquete.Commentaire = Commentaire.GetListCommentaire(enquete.Id);
                            enquete.Visite_enquete = Visite_enquete.GetVisiteEnquete(enquete.Id);
                            enquete.Appel = Appel.GetListAppel(enquete.Id);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return enquete;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Enquete> GetAllEnquete()
        {
            List<Enquete> listEnquetes = new List<Enquete>();
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    string query = @"SELECT * FROM Enquete";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Enquete enquete = new Enquete();
                            //display retrieved record (first column only/string value)
                            enquete.Id = dr.GetString(0);
                            enquete.Titulaire_enquete = Personne.GetPersonneById(dr.GetInt32(1));
                            enquete.Delegue_enqueteur = Personne.GetPersonneById(dr.GetInt32(2));
                            enquete.Plaignant = Personne.GetPersonneById(dr.GetInt32(3));
                            enquete.Infracteur = Personne.GetPersonneById(dr.GetInt32(4));
                            enquete.Avis = dr.GetString(5);
                            enquete.Etat = dr.GetInt32(6);
                            enquete.OuvertParLeSiege = IntToBool(dr.GetInt32(7));
                            enquete.Motif = dr.GetString(8);
                            enquete.Animaux = Animaux_enquete.GetAnimaux_EnquetesBdd(enquete.Id);
                            enquete.Document = Document.GetListDocument(enquete.Id);
                            enquete.Commentaire = Commentaire.GetListCommentaire(enquete.Id);
                            enquete.Visite_enquete = Visite_enquete.GetVisiteEnquete(enquete.Id);
                            enquete.Appel = Appel.GetListAppel(enquete.Id);
                            listEnquetes.Add(enquete);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return listEnquetes;
            }
            catch (Exception ex)
            {
                throw;
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
                    string query = @"INSERT INTO Enquete (Id, Titulaire_enquete, Delegue_enqueteur, Infracteur, Plaignant, Etat, Avis, OuvertParLeSiege, Motif) VALUES (@Id, @Titulaire_enquete, @Delegue_enquete, @Infracteur, @Plaignant, 0, '', @Siege, @Motif);";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", enquete.Id);
                    cmd.Parameters.AddWithValue("@Titulaire_enquete", enquete.Titulaire_enquete.Id);
                    cmd.Parameters.AddWithValue("@Delegue_enquete", enquete.Delegue_enqueteur.Id);
                    cmd.Parameters.AddWithValue("@Infracteur", enquete.Infracteur.Id);
                    cmd.Parameters.AddWithValue("@Plaignant", enquete.Plaignant.Id);
                    cmd.Parameters.AddWithValue("@Siege", BoolToInt(enquete.OuvertParLeSiege));
                    cmd.Parameters.AddWithValue("@Motif", enquete.Motif);

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

        public static bool UpdateEnquete(Enquete enquete)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"UPDATE Enquete SET Titulaire_enquete = @Titulaire_enquete, Delegue_enqueteur = @Delegue_enqueteur, Infracteur = @Infracteur, Plaignant = @Plaignant, Etat = @Etat, Avis = @Avis, Motif = @Motif WHERE Id = @Id;";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", enquete.Id);
                    cmd.Parameters.AddWithValue("@Titulaire_enquete", enquete.Titulaire_enquete.Id);
                    cmd.Parameters.AddWithValue("@Delegue_enqueteur", enquete.Delegue_enqueteur.Id);
                    cmd.Parameters.AddWithValue("@Infracteur", enquete.Infracteur.Id);
                    cmd.Parameters.AddWithValue("@Plaignant", enquete.Plaignant.Id);
                    cmd.Parameters.AddWithValue("@Etat", enquete.Etat);
                    cmd.Parameters.AddWithValue("@Avis", enquete.Avis);
                    cmd.Parameters.AddWithValue("@Siege", BoolToInt(enquete.OuvertParLeSiege));
                    cmd.Parameters.AddWithValue("@Motif", enquete.Motif);

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


        public static string GenerateId(string departement, string mois, string annee)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"select MAX(id)
                                    from (
	                                    select SUBSTRING(E.Id, 1, 2)  as departement, SUBSTRING(E.Id, CHARINDEX('/', E.Id)+1, 2) as annee, SUBSTRING(E.Id, CHARINDEX('/', E.Id, CHARINDEX('/', E.Id) + 1)+1, 2) as mois, RIGHT(E.Id, 3) as id
	                                    from Enquete E
                                    ) t1
                                    where departement = @departement
                                    and annee = @annee
                                    and mois = @mois";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@departement", departement);
                    cmd.Parameters.AddWithValue("@annee", annee);
                    cmd.Parameters.AddWithValue("@mois", mois);
                    //open connection
                    conn.Open();

                    //execute the SQLCommand
                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            if (dr.IsDBNull(0))
                                return "000";
                            else
                            {
                                int id = Int32.Parse(dr.GetString(0)) + 1;
                                return id.ToString("000");
                            }
                            
                        }
                    }
                    dr.Close();
                }
                return "000";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool DeleteEnquete(Enquete enquete)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"DELETE FROM Enquete WHERE Id = @Id";

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
