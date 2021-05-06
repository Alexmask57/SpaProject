using SPA.Models.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPA.Models
{
    public class Race_animal
    {
        public int Id { get; set; }
        public string Animal { get; set; }
        public string Nom_race { get; set; }

        public static Race_animal GetRace_AnimalBdd(int id)
        {
            return Race_animalDAO.GetRaceAnimal(id);
        }
        public static Race_animal GetRace_AnimalBdd(string animal, string raceAnimale)
        {
            return Race_animalDAO.GetRaceAnimal(animal, raceAnimale);
        }

        public static List<Race_animal> GetRace_Animals()
        {
            return Race_animalDAO.GetListRaceAnimal();
        }
    }
}
