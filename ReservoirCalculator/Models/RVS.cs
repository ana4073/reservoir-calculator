namespace ReservoirCalculator.Models
{
    /// <summary>
    /// Резервуар вертикальный стальной (РВС)
    /// Цилиндрический резервуар с вертикальной ориентацией
    /// </summary>
    public class RVS : ReservoirBase
    {
        /// <summary>
        /// Высота конической крыши (м)
        /// </summary>
        public double RoofHeight { get; set; } = 0.5;

        /// <summary>
        /// Тип крыши: Коническая, Плоская, Полусферичная
        /// </summary>
        public string RoofType { get; set; } = "Коническая";

        /// <summary>
        /// Рассчитать объем РВС (м³)
        /// </summary>
        public override double CalculateVolume()
        {
            // Объем цилиндра
            double cylinderVolume = GetBaseArea() * Height;

            // Объем крыши
            double roofVolume = 0;
            switch (RoofType)
            {
                case "Коническая":
                    // Объем конуса = 1/3 * π * r² * h
                    roofVolume = (1.0 / 3.0) * GetBaseArea() * RoofHeight;
                    break;

                case "Плоская":
                    roofVolume = 0; // Плоская крыша не добавляет объем
                    break;

                case "Полусферичная":
                    // Объем полусферы = 2/3 * π * r³
                    double radius = GetRadius();
                    roofVolume = (2.0 / 3.0) * System.Math.PI * radius * radius * radius;
                    break;
            }

            return cylinderVolume + roofVolume;
        }

        /// <summary>
        /// Рассчитать массу материала (кг)
        /// </summary>
        public override double CalculateMass()
        {
            double radius = GetRadius();
            double wallThicknessM = WallThickness / 1000.0; // Конвертируем мм в м

            // Площадь боковой поверхности стенок
            double wallArea = GetSurfaceArea();
            double wallVolume = wallArea * wallThicknessM;

            // Площадь днища
            double bottomArea = GetBaseArea();
            double bottomVolume = bottomArea * wallThicknessM;

            // Площадь крыши
            double roofArea = GetBaseArea(); // Приблизительно
            double roofVolume = roofArea * wallThicknessM;

            // Общий объем материала
            double totalMaterialVolume = wallVolume + bottomVolume + roofVolume;
            return totalMaterialVolume * Density;
        }
    }
}
