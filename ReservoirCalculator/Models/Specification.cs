namespace ReservoirCalculator.Models
{
    /// <summary>
    /// Спецификация материалов и комплектующих
    /// </summary>
    public class Specification
    {
        public string ConfigurationName { get; set; }
        public string ReservoirType { get; set; }
        public double ReservoirVolume { get; set; }
        public double ReservoirMass { get; set; }
        public double ComponentsMass { get; set; }
        public double ComponentsCost { get; set; }
        public double MaterialCost { get; set; }
        public List<SpecificationItem> Items { get; set; } = new();
        public DateTime GeneratedDate { get; set; } = DateTime.Now;

        public double GetTotalCost() => MaterialCost + ComponentsCost;
        public double GetTotalWeight() => ReservoirMass + ComponentsMass;
    }

    public class SpecificationItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Quantity { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }
    }
}
