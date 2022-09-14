using PowerPlant.Application.Interface;
using PowerPlant.Dto;
using Microsoft.AspNetCore.Http;
namespace PowerPlant.Application.Service
{
    public class PowerPlantService : IPowerPlantService
    {
        public List<Entities.PowerProduced> GetPower(Entities.PayLoad payLoadEntities)
        {
            var payload = Mapper.ToPlayLoad(payLoadEntities);

            var unitCommitmentList = new List<PowerPlant.Dto.UnitCommitment>();

            if (payload != null && payload.PowerPlants.Count > new int())
            {
                unitCommitmentList = GetUnitsWhilePowerIsInMinValue(payload.PowerPlants);
                decimal remainingPower = payload.Load - unitCommitmentList.Sum(u => u.Power);
                if (remainingPower > new decimal())
                {
                    // try to increase the unit power taking in count the pmax and the price
                    foreach (Dto.UnitCommitment unitCommitmentItem in unitCommitmentList.OrderBy(p => p.MwhPrice).ThenBy(p => p.Pmin))
                    {
                        if (remainingPower > new decimal())
                        {
                            decimal differnceBetweenMaxAndMin = unitCommitmentItem.Pmax - unitCommitmentItem.Pmin;
                            if (differnceBetweenMaxAndMin > remainingPower)
                            {
                                unitCommitmentItem.Power = unitCommitmentItem.Pmin + remainingPower;
                                remainingPower = new decimal();
                            }
                            else if (differnceBetweenMaxAndMin == remainingPower)
                            {
                                unitCommitmentItem.Power = unitCommitmentItem.Pmax;
                                remainingPower = unitCommitmentItem.Pmin;
                            }
                            else
                            {
                                unitCommitmentItem.Power = unitCommitmentItem.Pmax;
                                remainingPower = remainingPower - differnceBetweenMaxAndMin;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            var response = SetResponse(unitCommitmentList, payload.Load);
           
            return response.IsSucceeded ? Mapper.ToUnitCommitment(response.UnitCommitments) : null ;
        }

        #region SetResponse
        private PowerPlant.Dto.ProducedPower SetResponse(List<Dto.UnitCommitment> unitCommitmentList, int load)
        {
            var responseDto = new ProducedPower();
            if (unitCommitmentList.Sum(u => u.Power) == load)
            {
                responseDto.UnitCommitments = unitCommitmentList.OrderBy(u => u.MwhPrice).ThenBy(u => u.Pmin).ToList();
                responseDto.IsSucceeded = true;
            }
            else
            {
                responseDto.UnitCommitments = new List<Dto.UnitCommitment>();
                responseDto.IsSucceeded = false;
                
            }
            return responseDto;
        }

        private List<Dto.UnitCommitment> GetUnitsWhilePowerIsInMinValue(List<PowerPlant.Dto.PowerPlant> powerplants)
        {
            var unitCommitmentDtos = powerplants.Select(p => new Dto.UnitCommitment()
            {
                Name = p.Name,
                MwhPrice = p.MwhPrice,
                Power = p.Pmin,
                Pmax = p.Pmax,
                Pmin = p.Pmin
            }).ToList();

            return unitCommitmentDtos;
        }
        #endregion
    }

}
