using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumPartTwo.Models
{
    class Aquarium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public virtual ICollection<AquaticLife> AquaticLifes { get; set; }
    }
}
