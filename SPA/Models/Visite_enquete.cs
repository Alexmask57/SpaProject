using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Visite_enquete
    {
        public int Id { get; set; }
        public Enquete Enquete { get; set; }
        public Personne Titulaire_enquete { get; set; }
        public Personne Delegue_enqueteur { get; set; }
        public DateTime Date_visite { get; set; }
        public bool Avis_passage { get; set; }
    }
}
