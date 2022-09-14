using PowerPlant.Dto;

namespace PowerPlant.Dto
{
    public class PayLoad
    {
        public int Load { get; set; }
        public Fuel Fuel { get; set; }
        public List<PowerPlant> PowerPlants { get; set; }
    }
}