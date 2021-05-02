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

        public static Personne GetPersonneById(int id)
        {
            return PersonneDAO.GetPersonne(id);
        }
    }
}
