using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumPartTwo.Models
{
    class AquaticLife
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public DateTime DateAddedToTank { get; set; } = DateTime.Now;
        public bool IsInQuarantine { get; set; }


        //public virtual ICollection<Aquarium> Aquariums { get; set; }
        //public virtual ICollection<Ocean> Oceans { get; set; }

    }
}
