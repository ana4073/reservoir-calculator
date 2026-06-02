namespace ReservoirCalculator.Models
{
    /// <summary>
    /// Конфигурация резервуара с выбранными комплектующими
    /// </summary>
    public class ReservoirConfiguration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReservoirType { get; set; } // РВС или РГС
        public double Diameter { get; set; }
        public double Height { get; set; }
        public double WallThickness { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public List<Component> SelectedComponents { get; set; } = new();
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public double GetTotalComponentsWeight()
        {
            return SelectedComponents.Sum(c => c.GetTotalWeight());
        }

        public double GetTotalComponentsCost()
        {
            return SelectedComponents.Sum(c => c.GetTotalCost());
        }
    }
}
