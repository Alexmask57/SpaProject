﻿using SPA.Models.DAO;
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
            /*
            List<Document> listDocumentBdd =  tAnimaux_EnquetesBdd(enquete.Id);
            List<Document> animauxASupprimer = listAnimauxBdd;
            foreach (Document animal in enquete.Animaux)
            {
                animal.Enquete.Id = enquete.Id;
                bool exist = false;
                foreach (Animaux_enquete animalBdd in listAnimauxBdd)
                {
                    if (animalBdd.Race == animal.Race && animalBdd.Nombre == animal.Nombre)
                    {
                        exist = true;
                        animauxASupprimer.Remove(animal);
                    }
                }
                if (!exist)
                    Animaux_enquete.AddAnimalEnqueteBdd(animal);
            }
            foreach (Animaux_enquete animalASupprimer in animauxASupprimer)
                Animaux_enquete.DeleteAnimal(animalASupprimer);
            */
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
            string departement = this.Titulaire_enquete.Refuge.Departement.ToString("00");
            string annee = DateTime.Now.ToString("yy");
            string mois = DateTime.Now.ToString("MM");
            this.Id = departement + "/" + annee + "/" + mois + "/" + EnqueteDAO.GenerateId(departement, mois, annee);
        }

    }
}
