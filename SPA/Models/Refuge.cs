using SPA.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Refuge
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Departement { get; set; }


        /// <summary>
        /// Recupere le refuge d'une personne (null dans le cas ou la personne n'est pas associée à un refuge)
        /// </summary>
        /// <param name="personne">personne</param>
        /// <returns></returns>
        public static Refuge GetRefuge(Personne personne)
        {
            return RefugeDAO.GetRefuge(personne);
        }
        public static Refuge GetRefugeById(int id)
        {
            return RefugeDAO.GetRefugeById(id);
        }
    }
}
