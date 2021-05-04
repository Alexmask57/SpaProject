using SPA.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Document
    {
        public Enquete Enquete { get; set; }
        public DateTime Date { get; set; }
        public string Chemin { get; set; }

        /// <summary>
        /// Recupere les documents d'une enquete
        /// </summary>
        /// <param name="id">id de l'enquete</param>
        /// <returns></returns>
        public static List<Document> GetListDocument(string id)
        {
            return DocumentDAO.GetListDocument(id);
        }

        /// <summary>
        /// Creer un document dans la base de données pour l'enquete
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static bool CreerDocumentBdd(Document document)
        {
            return DocumentDAO.AddDocument(document);
        }
    }
}
