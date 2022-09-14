using PowerPlant.Dto;
using PowerPlant.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Application
{
    public static class Mapper
    {
        public static List<PowerProduced> ToUnitCommitment(List<Dto.UnitCommitment> unitCommitment)
        {
            return unitCommitment.Select(u => new PowerProduced() { Name = u.Name, P = u.Power }).ToList();
        }

        public static PowerPlant.Dto.PayLoad ToPlayLoad(Entities.PayLoad payload)
        {
            return new PowerPlant.Dto.PayLoad()
            {
                Fuel = new PowerPlant.Dto.Fuel() { Co2EuroTon = payload.Fuels.Co2EuroTon, GasEuroMWh = payload.Fuels.GasEuroMWh, KerosineEuroMWh = payload.Fuels.KerosineEuroMWh, Wind = payload.Fuels.Wind },
                Load = payload.Load,
                PowerPlants = payload.PowerPlants.Select(p => new PowerPlant.Dto.PowerPlant()
                {
                    Efficiency = p.Efficiency,
                    Name = p.Name,
                    Pmin = p.Pmin,
                    Type = Mapper.ToPowerPlantType(p.Type),
                    Pmax = GetPMax(Mapper.ToPowerPlantType(p.Type), payload.Fuels, p.Pmax),
                    MwhPrice = GetMwhPrice(Mapper.ToPowerPlantType(p.Type), payload.Fuels, p.Efficiency)
                }).ToList(),
            };
        }

        public static Dto.Enum.PowerPlantType ToPowerPlantType(this string type)
        {
             Enum.TryParse("Active", out Dto.Enum.PowerPlantType powerPlantType);
             return powerPlantType;
        }

        private static decimal GetPMax(Dto.Enum.PowerPlantType powerplantType, Entities.Fuel fuel, decimal pmax)
        {
            decimal pmaxValue = new decimal();
            switch (powerplantType)
            {
                case Dto.Enum.PowerPlantType.GasFired:
                    pmaxValue = pmax;
                    break;
                case Dto.Enum.PowerPlantType.TurboJet:
                    pmaxValue = pmax;
                    break;
                case Dto.Enum.PowerPlantType.WindTurbine:
                    pmaxValue = pmax * (fuel.Wind / 100);
                    break;
            }
            return pmaxValue;
        }

        private static decimal GetMwhPrice(Dto.Enum.PowerPlantType powerplantType, Entities.Fuel fuel, decimal efficiency)
        {
            decimal mwhPrice = new decimal();
            switch (powerplantType)
            {
                case Dto.Enum.PowerPlantType.GasFired:
                    mwhPrice = (fuel.GasEuroMWh / efficiency) + (fuel.Co2EuroTon * 0.3m); // Taken into account that a gas-fired powerplant also emits CO2 -  each MWh generated creates 0.3 ton of CO2.
                    break;
                case Dto.Enum.PowerPlantType.TurboJet:
                    mwhPrice = fuel.KerosineEuroMWh / efficiency;
                    break;
                case Dto.Enum.PowerPlantType.WindTurbine:
                    mwhPrice = 0;
                    break;
            }
            return mwhPrice;
        }
    }
}
