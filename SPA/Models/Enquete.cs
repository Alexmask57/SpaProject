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
            if (!Personne.ExistPersonneBdd(enquete.Titulaire_enquete))
                enquete.Titulaire_enquete.Id = Personne.AddPersonneBdd(enquete.Titulaire_enquete);
            else
                enquete.Titulaire_enquete = Personne.GetPersonne(enquete.Titulaire_enquete.Nom, enquete.Titulaire_enquete.Prenom);

            if (!Personne.ExistPersonneBdd(enquete.Delegue_enqueteur))
                enquete.Delegue_enqueteur.Id = Personne.AddPersonneBdd(enquete.Delegue_enqueteur);
            else
                enquete.Delegue_enqueteur = Personne.GetPersonne(enquete.Delegue_enqueteur.Nom, enquete.Delegue_enqueteur.Prenom);

            if (!Personne.ExistPersonneBdd(enquete.Infracteur))
                enquete.Infracteur.Id = Personne.AddPersonneBdd(enquete.Infracteur);
            else
                enquete.Infracteur = Personne.GetPersonne(enquete.Infracteur.Nom, enquete.Infracteur.Prenom);

            if (!Personne.ExistPersonneBdd(enquete.Plaignant))
                enquete.Plaignant.Id = Personne.AddPersonneBdd(enquete.Plaignant);
            else
                enquete.Plaignant = Personne.GetPersonne(enquete.Plaignant.Nom, enquete.Plaignant.Prenom);

            enquete.GenerateId();

            foreach (Animaux_enquete animal in enquete.Animaux)
            {
                animal.Enquete.Id = enquete.Id;
                Animaux_enquete.AddAnimalEnqueteBdd(animal);
            }
            EnqueteDAO.AddEnquete(enquete);
        }

        public static void UpdateEnqueteBdd(Enquete enquete)
        {
            //TODO

            //Update enquete uniquement
            EnqueteDAO.UpdateEnquete(enquete);
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
