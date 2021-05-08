using SPA.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Animaux_enquete
    {
        public Enquete Enquete { get; set; } = new Enquete();
        public Race_animal Race { get; set; } = new Race_animal();
        public int Nombre { get; set; }

        /// <summary>
        /// recupere les animaux d'une enquete
        /// </summary>
        /// <param name="id">i de l'enquete</param>
        /// <returns></returns>
        public static List<Animaux_enquete> GetAnimaux_EnquetesBdd(string id)
        {
            return Animaux_enqueteDAO.GetAnimaux(id);
        }

        /// <summary>
        /// Ajoute un animal pour une enquete
        /// </summary>
        /// <param name="animal">Animal à ajouter</param>
        /// <returns></returns>
        public static bool AddAnimalEnqueteBdd (Animaux_enquete animal)
        {
            return Animaux_enqueteDAO.AddAnimalEnquete(animal);
        }

        public static bool UpdateAnimalEnqueteBdd(Animaux_enquete animal)
        {
            return Animaux_enqueteDAO.UpdateAnimalEnquete(animal);
        }

        public static int NombreAnimauxEnquete(Enquete enquete)
        {
            return Animaux_enqueteDAO.GetNombreAnimaux(enquete.Id);
        }

        public static bool DeleteAnimauxEnquete(Enquete enquete)
        {
            return Animaux_enqueteDAO.DeleteAnimauxEnquete(enquete);
        }

        public static bool DeleteAnimal(Animaux_enquete animal)
        {
            return Animaux_enqueteDAO.DeleteAnimal(animal);
        }
    }
}
