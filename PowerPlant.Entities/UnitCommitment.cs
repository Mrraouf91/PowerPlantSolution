using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Entities
{
    public class UnitCommitment
    {
        public string Name { get; set; }
        public decimal Power { get; set; }
        public decimal MwhPrice { get; set; }
        public decimal Pmax { get; set; }
        public decimal Pmin { get; set; }
    }
}
