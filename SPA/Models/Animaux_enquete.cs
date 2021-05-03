using SPA.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Animaux_enquete
    {
        public int Id { get; set; }
        public Race_animal Race { get; set; }
        public int Nombre { get; set; }

        public static List<Animaux_enquete> GetAnimaux_EnquetesBdd(string id)
        {
            return Animaux_enqueteDAO.GetAnimaux(id);
        }

        public static bool AddAnimalEnqueteBdd (Animaux_enquete animal)
        {
            return Animaux_enqueteDAO.AddAnimalEnquete(animal);
        }
    }
}
