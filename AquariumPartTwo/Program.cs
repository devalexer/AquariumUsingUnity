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

            //var aquariums = db.Aquariums.ToList();

            //var cali = db.Aquariums.Where(w => w.City == "San Francisco");

        }
    }
}
