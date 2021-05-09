using SPA.Models.DAO;
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
        public string Motif { get; set; }
        public string Avis { get; set; } = "";
        public int Etat { get; set; }
        public bool OuvertParLeSiege { get; set; } = false;
        public List<Animaux_enquete> Animaux { get; set; } = new List<Animaux_enquete>();
        public List<Appel> Appel { get; set; } = new List<Appel>();
        public List<Commentaire> Commentaire { get; set; } = new List<Commentaire>();
        public List<Document> Document { get; set; } = new List<Document>();
        public List<Visite_enquete> Visite_enquete { get; set; } = new List<Visite_enquete>();

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

            if (string.IsNullOrEmpty(enquete.Id))
                enquete.GenerateId();

            foreach (Animaux_enquete animal in enquete.Animaux)
            {
                animal.Enquete.Id = enquete.Id;
                Animaux_enquete.AddAnimalEnqueteBdd(animal);
            }
            foreach (Document document in enquete.Document)
            {
                document.Enquete.Id = enquete.Id;
                Models.Document.CreerDocumentBdd(document);
            }
            EnqueteDAO.AddEnquete(enquete);
        }

        public static void UpdateEnqueteBdd(Enquete enquete)
        {
            Enquete enqueteBdd = Enquete.GetEnquete(enquete.Id);
            enquete.Titulaire_enquete = Personne.GetPersonne(enquete.Titulaire_enquete.Nom, enquete.Titulaire_enquete.Prenom);
            enquete.Delegue_enqueteur = Personne.GetPersonne(enquete.Delegue_enqueteur.Nom, enquete.Delegue_enqueteur.Prenom);
            enquete.Plaignant.Id = enqueteBdd.Plaignant.Id;
            enquete.Infracteur.Id = enqueteBdd.Infracteur.Id;

            Personne.UpdatePersonneBdd(enquete.Titulaire_enquete);

            Personne.UpdatePersonneBdd(enquete.Delegue_enqueteur);

            Personne.UpdatePersonneBdd(enquete.Infracteur);
            enquete.Infracteur = Personne.GetPersonne(enquete.Infracteur.Nom, enquete.Infracteur.Prenom);

            Personne.UpdatePersonneBdd(enquete.Plaignant);
            enquete.Plaignant = Personne.GetPersonne(enquete.Plaignant.Nom, enquete.Plaignant.Prenom);

            //update animaux
            List<Animaux_enquete> listAnimauxBdd = Animaux_enquete.GetAnimaux_EnquetesBdd(enquete.Id);
            List<Animaux_enquete> animauxASupprimer = Animaux_enquete.GetAnimaux_EnquetesBdd(enquete.Id);
            foreach (Animaux_enquete animal in enquete.Animaux)
            {
                animal.Enquete.Id = enquete.Id;
                bool exist = false;
                foreach (Animaux_enquete animalBdd in listAnimauxBdd)
                {
                    if (animalBdd.Race.Animal == animal.Race.Animal &&
                        animalBdd.Nombre == animal.Nombre && 
                        animalBdd.Race.Nom_race == animal.Race.Nom_race)
                    {
                        exist = true;
                        animauxASupprimer.Remove(animauxASupprimer.Find(x => x.Race.Id == animalBdd.Race.Id));
                    }
                }
                if (!exist)
                    Animaux_enquete.AddAnimalEnqueteBdd(animal);
            }
            foreach (Animaux_enquete animalASupprimer in animauxASupprimer)
                Animaux_enquete.DeleteAnimal(animalASupprimer);

            //update visite
            List<Visite_enquete> listVisiteBdd = Models.Visite_enquete.GetVisiteEnquete(enquete.Id);
            List<Visite_enquete> visitesAsupprimer = Models.Visite_enquete.GetVisiteEnquete(enquete.Id);
            foreach (Visite_enquete visite in enquete.Visite_enquete)
            {
                visite.Enquete.Id = enquete.Id;
                bool exist = false;
                foreach (Visite_enquete visiteBdd in listVisiteBdd)
                {
                    if (visiteBdd.Titulaire_enquete.Id == visite.Titulaire_enquete.Id &&
                        visiteBdd.Delegue_enqueteur.Id == visite.Delegue_enqueteur.Id &&
                        visiteBdd.Date_visite == visite.Date_visite &&
                        visiteBdd.Avis_passage == visite.Avis_passage)
                    {
                        exist = true;
                        visitesAsupprimer.Remove(visitesAsupprimer.Find(x => x.Id == visiteBdd.Id));
                    }
                }
                if (!exist)
                    Models.Visite_enquete.AddVisiteEnqueteBdd(visite);
            }
            foreach (Visite_enquete visiteAsupprimer in visitesAsupprimer)
                Models.Visite_enquete.DeleteVisite(visiteAsupprimer);

            //update animaux
            List<Commentaire> listCommentairesBdd = Models.Commentaire.GetListCommentaire(enquete.Id);
            List<Commentaire> commentairesASupprimer = Models.Commentaire.GetListCommentaire(enquete.Id);
            foreach (Commentaire commentaire in enquete.Commentaire)
            {
                commentaire.Enquete.Id = enquete.Id;
                bool exist = false;
                foreach (Commentaire commentaireBdd in listCommentairesBdd)
                {
                    if (commentaireBdd.Enquete.Id == commentaire.Enquete.Id &&
                        commentaireBdd.Date == commentaire.Date)
                    {
                        exist = true;
                        commentairesASupprimer.Remove(commentairesASupprimer.Find(x => x.Date == commentaireBdd.Date));
                    }
                }
                if (!exist)
                    Models.Commentaire.CreerCommentaireBdd(commentaire);
            }
            foreach (Commentaire commentaireASupprimer in commentairesASupprimer)
                Models.Commentaire.DeleteCommentaire(commentaireASupprimer);

            //update doc
            foreach (Document document in enquete.Document)
            {
                document.Enquete.Id = enquete.Id;
                Models.Document.CreerDocumentBdd(document);
            }

            //Update enquete uniquement
            EnqueteDAO.UpdateEnquete(enquete);
        }
        public static void DeleteEnquete(Enquete enquete)
        {
            EnqueteDAO.DeleteEnquete(enquete);
            Animaux_enquete.DeleteAnimauxEnquete(enquete);
            Models.Appel.DeleteAppelEnquete(enquete);
            Models.Commentaire.DeleteCommentaire(enquete);
            Models.Document.DeleteDocument(enquete);
            Models.Visite_enquete.DeleteVisitesEnquete(enquete);
        }

        public static List<Enquete> GetEnquetes()
        {
            return EnqueteDAO.GetAllEnquete();
        }

        public static Enquete GetEnquete(string id)
        {
            return EnqueteDAO.GetEnquete(id);
        }

        private void GenerateId()
        {
            string departement = this.Titulaire_enquete.GetDepartement();// this.Titulaire_enquete.Refuge.Departement.ToString("00");
            string annee = DateTime.Now.ToString("yy");
            string mois = DateTime.Now.ToString("MM");
            this.Id = departement + "/" + annee + "/" + mois + "/" + EnqueteDAO.GenerateId(departement, mois, annee);
        }

    }
}
