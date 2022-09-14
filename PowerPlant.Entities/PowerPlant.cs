using PowerPlant.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Entities
{
    public class PowerPlant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Efficiency { get; set; }
        public decimal Pmin { get; set; }
        public decimal Pmax { get; set; }
    }
}
