using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SPA.Models;

namespace SPA
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<Personne> liste = PersonneDAO.GetAllPersonne();
            bool res =  PersonneDAO.AddPersonne(new Personne { Nom = "Lallement", Prenom = "Théo", Adresse = "22 j'ai pas entendu ", Code_postal = 57440, Ville = "Angevillers", Email = "teluob.theo@gmail.com" });
            liste = PersonneDAO.GetAllPersonne();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void initConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Server = localhost\\SQLEXPRESS; Database = SPA; Trusted_Connection = True;"))
                {
                    Console.WriteLine("Connexion réussie");
                    //retrieve the SQL Server instance version
                    string query = @"SELECT @@VERSION";

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
                            string test = dr.GetString(0);
                            Console.WriteLine(dr.GetString(0));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
