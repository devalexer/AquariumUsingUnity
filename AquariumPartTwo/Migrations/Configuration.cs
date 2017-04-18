namespace AquariumPartTwo.Migrations
{
    using AquariumPartTwo.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AquariumPartTwo.DataContext.AquariumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AquariumPartTwo.DataContext.AquariumContext context)
        {

            var oceans = new List<Ocean>
            {
                new Ocean{Name = "Indian", AverageTemperature = 72},
                new Ocean{Name = "Atlantic", AverageTemperature = 68},
                new Ocean{Name = "Pacific", AverageTemperature = 88},
                new Ocean{Name = "Arctic", AverageTemperature = 23},

            };
            oceans.ForEach(oc => context.Oceans.AddOrUpdate(o => o.Name, oc));
            context.SaveChanges();


            var fishes = new List<AquaticLife>
            {
                new AquaticLife{Name = "Mr. Otter", Type = "Otter", Color = "brown"},
                new AquaticLife{Name = "Mrs. Eel", Type = "Eel", Color = "gray"},
                new AquaticLife{Name = "Mr. Starfish", Type = "Starfish", Color = "pink"},
                new AquaticLife{Name = "Mrs. Shark", Type = "Shark", Color = "blue"},
            };

            fishes.ForEach(type => context.AquaticLifes.AddOrUpdate(c => c.Name, type));
            context.SaveChanges();


            var locations = new List<Aquarium>
            {
                new Aquarium{Name = "Suncoast Aquarium", City = "Tampa"},
                new Aquarium{Name = "Frigid Water Aquarium", City = "Boston"},
                new Aquarium{Name = "Sandy Aquarium", City = "Phoenix"},
                new Aquarium{Name = "West Coast Aquarium", City = "Seattle"},

            };

            locations.ForEach(city => context.Aquariums.AddOrUpdate(c => c.Name, city));
            context.SaveChanges();


            var mrPuff = new AquariumAquaticLifeOcean
            {
                AquariumId = locations.First(f => f.Name == "Fish Tank").Id,
                OceanId = oceans.First(f => f.Name == "Indian").Id,
                AquaticLifeId = fishes.First(f => f.Name == "Mr. Puff").Id
            };

            AquariumAquaticLifeOcean.AddOrUpdate(AquariumAquaticLifeOcean => new {a.OceanId, a.AquariumId, a.AquaticLifeId }, mrPuff);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
