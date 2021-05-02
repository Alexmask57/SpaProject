using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Personne
    {
        private int _id;
        private string _nom;
        private string _prenom;
        private string _adresse;
        private int _code_postal;
        private string _ville;
        private string _email;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }
        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }
        public int Code_postal
        {
            get { return _code_postal; }
            set { _code_postal = value; }
        }
        public string Ville
        {
            get { return _ville; }
            set { _ville = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
