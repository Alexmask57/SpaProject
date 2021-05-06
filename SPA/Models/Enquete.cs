using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Enquete
    {
        public string Id { get; set; }
        public Personne Titulaire_enquete { get; set; } = new Personne();
        public Personne Delegue_enqueteur { get; set; } = new Personne();
        public Personne Infracteur { get; set; } = new Personne();
        public Personne Plaignant { get; set; } = new Personne();
        public string Avis { get; set; }
        public int Etat { get; set; }
        public List<Animaux_enquete> Animaux { get; set; } = new List<Animaux_enquete>();
        
        /// <summary>
        /// Creer une enquete en base de données
        /// </summary>
        /// <param name="enquete">Enquete à ajouter dans la base de données</param>
        public static void CreerEnqueteBdd(Enquete enquete)
        {

            //Création des personnes en BDD (dans le cas ou elles n'existent pas)
            if (!PersonneDAO.ExistPersonne(enquete.Titulaire_enquete))
                enquete.Titulaire_enquete.Id = PersonneDAO.AddPersonne(enquete.Titulaire_enquete);
            else
                enquete.Titulaire_enquete = PersonneDAO.GetPersonne(enquete.Titulaire_enquete.Nom, enquete.Titulaire_enquete.Prenom);
            if (!PersonneDAO.ExistPersonne(enquete.Delegue_enqueteur))
                enquete.Delegue_enqueteur.Id =  PersonneDAO.AddPersonne(enquete.Delegue_enqueteur);
            else
                enquete.Delegue_enqueteur = PersonneDAO.GetPersonne(enquete.Delegue_enqueteur.Nom, enquete.Delegue_enqueteur.Prenom);
            if (!PersonneDAO.ExistPersonne(enquete.Infracteur))
                enquete.Infracteur.Id =  PersonneDAO.AddPersonne(enquete.Infracteur);
            else
                enquete.Infracteur = PersonneDAO.GetPersonne(enquete.Infracteur.Nom, enquete.Infracteur.Prenom);
            if (!PersonneDAO.ExistPersonne(enquete.Plaignant))
                enquete.Plaignant.Id = PersonneDAO.AddPersonne(enquete.Plaignant);
            else
                enquete.Plaignant = PersonneDAO.GetPersonne(enquete.Plaignant.Nom, enquete.Plaignant.Prenom);

            enquete.GenerateId();

            foreach (Animaux_enquete animal in enquete.Animaux)
            {
                animal.Enquete.Id = enquete.Id;
                Animaux_enquete.AddAnimalEnqueteBdd(animal);
            }
            EnqueteDAO.AddEnquete(enquete);
        }
        
        private void GenerateId()
        {
            string departement = this.Titulaire_enquete.Refuge.Departement.ToString("00");
            string annee = DateTime.Now.ToString("yy");
            string mois = DateTime.Now.ToString("MM");
            this.Id = departement + "/" + annee + "/" + mois + "/" + EnqueteDAO.GenerateId(departement, mois, annee);
        }
        
    }
}
