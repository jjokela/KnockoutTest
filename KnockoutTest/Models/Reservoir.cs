using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutTest.Models
{
    public class Reservoir
    {
        public int ReservoirId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Trap> Traps { get; set; }

        public Reservoir()
        {
            Traps = new List<Trap>();
        }
    }
}