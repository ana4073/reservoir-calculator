namespace ReservoirCalculator.Models
{
    /// <summary>
    /// Резервуар горизонтальный стальной (РГС)
    /// Цилиндрический резервуар с горизонтальной ориентацией
    /// </summary>
    public class RGS : ReservoirBase
    {
        /// <summary>
        /// Длина резервуара (м) - использует свойство Height для длины
        /// </summary>
        public double Length
        {
            get => Height;
            set => Height = value;
        }

        /// <summary>
        /// Тип днища: Плоское, Эллиптическое, Полусферичное
        /// </summary>
        public string BottomType { get; set; } = "Эллиптическое";

        /// <summary>
        /// Рассчитать объем РГС (м³)
        /// </summary>
        public override double CalculateVolume()
        {
            // Объем основного цилиндра
            double cylinderVolume = GetBaseArea() * Height;

            // Объем дниш (2 штуки)
            double bottomVolume = 0;
            switch (BottomType)
            {
                case "Плоское":
                    bottomVolume = 0;
                    break;

                case "Эллиптическое":
                    // Эллиптическое днище = 1/6 * π * D * h
                    // где h - высота эллиптического днища (обычно D/4)
                    double ellipsoidHeight = Diameter / 4.0;
                    bottomVolume = 2 * (1.0 / 6.0) * System.Math.PI * Diameter * ellipsoidHeight;
                    break;

                case "Полусферичное":
                    // Полусферичное днище = 2/3 * π * r³ (для 2-х дниш)
                    double radius = GetRadius();
                    bottomVolume = 2 * (2.0 / 3.0) * System.Math.PI * radius * radius * radius;
                    break;
            }

            return cylinderVolume + bottomVolume;
        }

        /// <summary>
        /// Рассчитать массу материала (кг)
        /// </summary>
        public override double CalculateMass()
        {
            double radius = GetRadius();
            double wallThicknessM = WallThickness / 1000.0; // Конвертируем мм в м

            // Площадь боковой поверхности
            double wallArea = System.Math.PI * Diameter * Height;
            double wallVolume = wallArea * wallThicknessM;

            // Площадь дниш
            double bottomArea = GetBaseArea() * 2; // 2 днища
            double bottomVolume = bottomArea * wallThicknessM;

            // Общий объем материала
            double totalMaterialVolume = wallVolume + bottomVolume;
            return totalMaterialVolume * Density;
        }
    }
}
