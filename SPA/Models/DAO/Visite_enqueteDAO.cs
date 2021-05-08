using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SPA.Models.DAO
{
    public static class Visite_enqueteDAO
    {

        public static bool AddVisiteEnquete(Visite_enquete visite_enquete)
        {
            bool res = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    //retrieve the SQL Server instance version
                    string query = @"INSERT INTO Visite_enquete (Id, Id_enquete, Titulaire_enquete, Delegue_enqueteur, Date_visite, Avis_passage) VALUES (@Id, @Titulaire_enquete, @Delegue_enquete, @Infracteur, @Plaignant, 0, '');";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", visite_enquete.Id);
                    cmd.Parameters.AddWithValue("@Id_enquete", visite_enquete.Enquete.Id);
                    cmd.Parameters.AddWithValue("@Titulaire_enquete", visite_enquete.Titulaire_enquete.Id);
                    cmd.Parameters.AddWithValue("@Delegue_enquete", visite_enquete.Delegue_enqueteur.Id);
                    cmd.Parameters.AddWithValue("@Date_visite", visite_enquete.Date_visite);
                    cmd.Parameters.AddWithValue("@Avis_passage", visite_enquete.Avis_passage);

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
        /*
        public static List<Visite_enquete> GetAllVisiteEnquete(string id)
        {
            List<Visite_enquete> listeVisiteEnquete = new List<Visite_enquete>();
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
                            enquete.Etat = dr.GetInt32(5);
                            enquete.Etat = dr.GetInt32(5);
                            enquete.OuvertParLeSiege = IntToBool(dr.GetInt32(6));
                            enquete.Animaux = Animaux_enquete.GetAnimaux_EnquetesBdd(enquete.Id);
                            listeVisiteEnquete.Add(enquete);
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
        */
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
