namespace PowerPlant.Entities
{
    public class PayLoad
    {
        public int Load { get; set; }
        public Fuel Fuels { get; set; }
        public List<PowerPlant> PowerPlants { get; set; }
    }
}