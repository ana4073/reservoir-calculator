namespace ReservoirCalculator.Models
{
    /// <summary>
    /// Материал (сталь, нержавейка, алюминий)
    /// </summary>
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; } // Марка стали
        public double Density { get; set; } // кг/м³
        public double PricePerKg { get; set; } // Цена за кг в рублях
        public string Description { get; set; }

        public override string ToString() => $"{Name} ({Grade}) - {PricePerKg} руб/кг";
    }
}
