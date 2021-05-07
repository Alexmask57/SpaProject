using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public int Code_postal { get; set; }
        public string Ville { get; set; }
        public string Email { get; set; }
        public bool Salarie { get; set; } = false;
        public bool Benevole { get; set; } = false;
        public Refuge Refuge { get; set; } = new Refuge();

        public static Personne GetPersonneById(int id)
        {
            return PersonneDAO.GetPersonne(id);
        }

        public static Personne GetPersonne(string nom, string prenom)
        {
            return PersonneDAO.GetPersonne(nom, prenom);
        }

        /// <summary>
        /// recupere les salaries et les benevoles
        /// </summary>
        /// <returns></returns>
        public static List<Personne> GetSalarieBenvole()
        {
            return PersonneDAO.GetAllSalarieBenevole();
        }

        public static int AddPersonneBdd(Personne personne)
        {
            return PersonneDAO.AddPersonne(personne);
        }

        public static bool ExistPersonneBdd(Personne personne)
        {
            return PersonneDAO.ExistPersonne(personne);
        }

        public static bool UpdatePersonneBdd(Personne personne)
        {
            return PersonneDAO.UpdatePersonne(personne);
        }

        /// <summary>
        /// Récûpère le departement 
        /// </summary>
        /// <returns></returns>
        public string GetDepartement()
        {
            string departement = "";
            //Les departements ne commencant pas par 97
            if (!this.Code_postal.ToString().StartsWith("97"))
                departement = this.Code_postal.ToString().Substring(0, 2);
            else
                departement = this.Code_postal.ToString().Substring(0, 3);

            return departement;
        }
    }
}
