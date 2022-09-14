using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Dto
{
    public class ProducedPower
    {
        public List<UnitCommitment> UnitCommitments { get; set; }
        public bool IsSucceeded { get; set; }
       
    }
}
