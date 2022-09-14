using PowerPlant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Application.Interface
{
    public interface IPowerPlantService
    {
        public List<Entities.PowerProduced> GetPower(Entities.PayLoad payLoadEntities);
    }
}
