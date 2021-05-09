using SPA.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Appel
    {
        public Enquete Enquete { get; set; } = new Enquete();
        public DateTime Date { get; set; }
        public string Commentaire { get; set; }

        /// <summary>
        /// Recupere les appels d'une enquete
        /// </summary>
        /// <param name="id">id de l'enquete</param>
        /// <returns></returns>
        public static List<Appel> GetListAppel(string id)
        {
            return AppelDAO.GetListAppel(id);
        }

        /// <summary>
        /// Creer un appel dans la base de données pour l'enquete
        /// </summary>
        /// <param name="appel"></param>
        /// <returns></returns>
        public static bool CreerAppelBdd(Appel appel)
        {
            return AppelDAO.AddAppel(appel);
        }

        public static bool UpdateAppelBdd(Appel appel)
        {
            return AppelDAO.UpdateAppel(appel);
        }

        public static bool DeleteAppelEnquete(Enquete enquete)
        {
            return AppelDAO.DeleteAppelsEnquete(enquete);
        }

        public static bool DeleteAppel(Appel appel)
        {
            return AppelDAO.DeleteAppel(appel);
        }

        public static int NombreAppelEnquete(Enquete enquete)
        {
            return AppelDAO.GetNombreAppel(enquete.Id);
        }
    }
}
