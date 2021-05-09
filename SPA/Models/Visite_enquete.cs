using SPA.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Visite_enquete
    {
        public int Id { get; set; }
        public Enquete Enquete { get; set; }
        public Personne Titulaire_enquete { get; set; }
        public Personne Delegue_enqueteur { get; set; }
        public DateTime Date_visite { get; set; }
        public bool Avis_passage { get; set; }

        public static List<Visite_enquete> GetVisiteEnquete(string id)
        {
            return Visite_enqueteDAO.GetAllVisiteEnquete(id);
        }

        /// <summary>
        /// Ajoute la visite en base, et retourne l'id genere (-1 si ya un bug)
        /// </summary>
        /// <param name="visite_enquete"></param>
        /// <returns></returns>
        public static int AddVisiteEnqueteBdd(Visite_enquete visite_enquete)
        {
            return Visite_enqueteDAO.AddVisiteEnquete(visite_enquete); ;
        }

        public static bool DeleteVisitesEnquete(Enquete enquete)
        {
            return Visite_enqueteDAO.DeleteVisiteEnquete(enquete);
        }

        public static bool DeleteVisite(Visite_enquete visite)
        {
            return Visite_enqueteDAO.DeleteVisite(visite);
        }
    }
}
