namespace ReservoirCalculator.Models
{
    /// <summary>
    /// Базовый класс для расчета объема резервуаров
    /// </summary>
    public abstract class ReservoirBase
    {
        /// <summary>
        /// Диаметр резервуара (м)
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// Высота резервуара (м)
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Толщина стенок (мм)
        /// </summary>
        public double WallThickness { get; set; }

        /// <summary>
        /// Материал днища
        /// </summary>
        public string BottomMaterial { get; set; } = "Сталь";

        /// <summary>
        /// Материал крыши
        /// </summary>
        public string RoofMaterial { get; set; } = "Коническая";

        /// <summary>
        /// Плотность материала (кг/м³)
        /// </summary>
        public double Density { get; set; } = 7850; // Плотность стали

        /// <summary>
        /// Рассчитать объем (м³)
        /// </summary>
        public abstract double CalculateVolume();

        /// <summary>
        /// Рассчитать массу (кг)
        /// </summary>
        public abstract double CalculateMass();

        /// <summary>
        /// Получить радиус резервуара
        /// </summary>
        public double GetRadius() => Diameter / 2.0;

        /// <summary>
        /// Получить площадь основания
        /// </summary>
        public double GetBaseArea() => System.Math.PI * GetRadius() * GetRadius();

        /// <summary>
        /// Получить площадь боковой поверхности
        /// </summary>
        public double GetSurfaceArea() => System.Math.PI * Diameter * Height;
    }
}
