namespace PowerPlant.Dto
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
