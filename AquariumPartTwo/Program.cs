using AquariumPartTwo.DataContext;
using AquariumPartTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumPartTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new AquariumContext();

            //Gets all Aquariums from database so they can be worked with here
            var allAquariums = db.Aquariums.ToList();

            //Gets all AquaticLifes from database
            var allAquaticLifes = db.AquaticLifes.ToList();

            //Gets all Oceans from database
            var allOceans = db.Oceans.ToList();

            //Creates new Aquarium
            var aquarium = new Aquarium
            {
                Name = "San Fran Aquarium",
                City = "San Francisco"
            };

            db.Aquariums.Add(aquarium);
            db.SaveChanges();

            //READs from Database

            var aquariums = db.Aquariums.ToList();
            var cali = db.Aquariums.Where(w => w.City == "San Francisco");

            //Calls San Fran Aquarium so it can be used in program 
            var sanFranAquarium = db.Aquariums.First(f => f.Name == "San Fran Aquarium");

            //DELETEs from Database

            db.Aquariums.Remove(sanFranAquarium);



            //For Assignment:

            //A SQL Query that given an Aquarium Name, What AquaticLife is there

            var aquariumNameAquaticLife = db.Aquariums;


            //A SQL Query that, given an Ocean, What Aquariums have fish from that ocean


            //A SQL Query that Returns Only the Distinct(new topic) Cities that have aquariums

            var citiesWithAquariums = db.Aquariums.Distinct().Where(Aquarium.City);

            //A SQL Query that Gives the Count(new topic) of How many species of AquaticLife live in each Ocean

            var totalNumOfSpecies = db.AquaticLifes.Count();

        }
    }
}
