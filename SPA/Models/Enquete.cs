using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Enquete
    {
        public string Id { get; set; }
        public Personne Titulaire_enquete { get; set; }
        public Personne Delegue_enqueteur { get; set; }
        public Personne Infracteur { get; set; }
        public Personne Plaignant { get; set; }
        public string Avis { get; set; }
        public int Etat { get; set; }
        
        /// <summary>
        /// Creer une enquete en base de données
        /// </summary>
        /// <param name="enquete">Enquete à ajouter dans la base de données</param>
        public static void CreerEnqueteBdd(Enquete enquete)
        {
            //Création des personnes en BDD (dans le cas ou elles n'existent pas)
            if (!PersonneDAO.ExistPersonne(enquete.Titulaire_enquete))
                PersonneDAO.AddPersonne(enquete.Titulaire_enquete);
            if (!PersonneDAO.ExistPersonne(enquete.Delegue_enqueteur))
                PersonneDAO.AddPersonne(enquete.Delegue_enqueteur);
            if (!PersonneDAO.ExistPersonne(enquete.Infracteur))
                PersonneDAO.AddPersonne(enquete.Infracteur);
            if (!PersonneDAO.ExistPersonne(enquete.Plaignant))
                PersonneDAO.AddPersonne(enquete.Plaignant);


        }
    }
}
