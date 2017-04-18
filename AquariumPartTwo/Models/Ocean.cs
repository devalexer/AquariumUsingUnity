using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumPartTwo.Models
{
    class Ocean
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? AverageTemperature { get; set; }

       // public virtual ICollection<AquaticLife> AquaticLifes { get; set; }
    }
}
