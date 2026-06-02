namespace ReservoirCalculator.Models
{
    /// <summary>
    /// Комплектующее изделие для резервуара
    /// </summary>
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ComponentType Type { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; } // кг
        public double Quantity { get; set; } // Количество на один резервуар
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public double Price { get; set; } // Цена одного компонента
        public string GostNumber { get; set; } // Номер ГОСТа
        public string Dimensions { get; set; } // Размеры

        public double GetTotalWeight() => Weight * Quantity;
        public double GetTotalCost() => Price * Quantity;

        public override string ToString() => $"{Name} (x{Quantity})";
    }
}
