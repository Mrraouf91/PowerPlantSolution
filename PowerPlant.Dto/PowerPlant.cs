using PowerPlant.Dto.Enum;

namespace PowerPlant.Dto
{
    public class PowerPlant
    {
        public string Name { get; set; }
        public PowerPlantType Type { get; set; }
        public decimal Efficiency { get; set; }
        public decimal Pmin { get; set; }
        public decimal Pmax { get; set; }
        public decimal MwhPrice { get; set; }
    }
}