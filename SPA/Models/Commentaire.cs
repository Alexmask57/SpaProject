using SPA.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Commentaire
    {
        public Enquete Enquete { get; set; } = new Enquete();
        public DateTime Date { get; set; }
        public string Detail { get; set; }

        /// <summary>
        /// Recupere les commentaires d'une enquete
        /// </summary>
        /// <param name="id">id de l'enquete</param>
        /// <returns></returns>
        public static List<Commentaire> GetListCommentaire(string id)
        {
            return CommentaireDAO.GetListCommentaire(id);
        }

        /// <summary>
        /// Creer un commentaire dans la base de données pour l'enquete
        /// </summary>
        /// <param name="commentaire"></param>
        /// <returns></returns>
        public static bool CreerCommentaireBdd(Commentaire commentaire)
        {
            return CommentaireDAO.AddCommentaire(commentaire);
        }

        public static bool UpdateCommentaireBdd(Commentaire commentaire)
        {
            return CommentaireDAO.UpdateCommentaire(commentaire);
        }

        public static int NombreCommentaireEnquete(Enquete enquete)
        {
            return Animaux_enqueteDAO.GetNombreAnimaux(enquete.Id);
        }
    }
}
