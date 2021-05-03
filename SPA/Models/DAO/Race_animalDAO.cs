using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SPA.Models.DAO
{
    public static class Race_animalDAO
    {
        public static Race_animal GetRaceAnimal(int Id)
        {
            Race_animal race = new Race_animal();
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    string query = @"SELECT * FROM Race_animal WHERE Id = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            race.Id = dr.GetInt32(0);
                            race.Animal = dr.GetString(1);
                            race.Nom_race = dr.GetString(2);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return race;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
        public static List<Race_animal> GetListRaceAnimal()
        {
            List<Race_animal> races = new List<Race_animal>();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(Variables.connectionSql))
                {
                    string query = @"SELECT * FROM Race_animal";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Race_animal race = new Race_animal();
                            race.Id = dr.GetInt32(0);
                            race.Animal = dr.GetString(1);
                            race.Nom_race = dr.GetString(2);
                            races.Add(race);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }
                    dr.Close();
                }
                return races;
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }
    }
}
