using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquariumPartTwo.Models;

namespace AquariumPartTwo.DataContext
{
    class AquariumContext :DbContext
    {
        public AquariumContext():base()
{

        }

        public DbSet<Aquarium> Aquariums { get; set; }
        public DbSet<AquaticLife> AquaticLifes { get; set; }
        public DbSet<Ocean> Oceans { get; set; }
        public DbSet<AquariumAquaticLifeOcean> AquariumAquaticLIfeOcean { get; set; }

    }

}
