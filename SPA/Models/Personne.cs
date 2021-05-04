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
        public bool Salarie { get; set; }
        public bool Benevole { get; set; }
        public Refuge Refuge { get; set; }

        public static Personne GetPersonneById(int id)
        {
            return PersonneDAO.GetPersonne(id);
        }

        /// <summary>
        /// recupere les salaries et les benevoles
        /// </summary>
        /// <returns></returns>
        public static List<Personne> GetSalarieBenvole()
        {
            return PersonneDAO.GetAllSalarieBenevole();
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
