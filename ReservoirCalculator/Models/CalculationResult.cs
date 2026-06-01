namespace ReservoirCalculator.Models
{
    /// <summary>
    /// Результаты расчета резервуара
    /// </summary>
    public class CalculationResult
    {
        public string ReservoirType { get; set; } = "";
        public double Volume { get; set; }
        public double Mass { get; set; }
        public double Diameter { get; set; }
        public double Height { get; set; }
        public double WallThickness { get; set; }
        public double SurfaceArea { get; set; }
        public string BottomMaterial { get; set; } = "";
        public string RoofMaterial { get; set; } = "";
        public DateTime CalculationDate { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"Резервуар: {ReservoirType}\n" +
                   $"Объем: {Volume:F2} м³\n" +
                   $"Масса: {Mass:F2} кг\n" +
                   $"Диаметр: {Diameter:F2} м\n" +
                   $"Высота/Длина: {Height:F2} м\n" +
                   $"Толщина стенок: {WallThickness:F2} мм\n" +
                   $"Площадь поверхности: {SurfaceArea:F2} м²\n" +
                   $"Материал днища: {BottomMaterial}\n" +
                   $"Материал крыши: {RoofMaterial}";
        }
    }
}
