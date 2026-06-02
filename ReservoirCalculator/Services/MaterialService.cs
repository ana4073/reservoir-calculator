using System.Collections.ObjectModel;
using ReservoirCalculator.Models;

namespace ReservoirCalculator.Services
{
    /// <summary>
    /// Сервис управления материалами и ценами
    /// </summary>
    public class MaterialService
    {
        private static readonly List<Material> DefaultMaterials = new()
        {
            new Material
            {
                Id = 1,
                Name = "Сталь",
                Grade = "Ст3сп",
                Density = 7850,
                PricePerKg = 45.00,
                Description = "Углеродистая сталь обыкновенного качества"
            },
            new Material
            {
                Id = 2,
                Name = "Сталь",
                Grade = "09Г2С",
                Density = 7850,
                PricePerKg = 52.00,
                Description = "Легированная сталь повышенной прочности"
            },
            new Material
            {
                Id = 3,
                Name = "Нержавеющая сталь",
                Grade = "AISI 304",
                Density = 8000,
                PricePerKg = 280.00,
                Description = "Аустенитная нержавеющая сталь"
            },
            new Material
            {
                Id = 4,
                Name = "Нержавеющая сталь",
                Grade = "AISI 316",
                Density = 8000,
                PricePerKg = 350.00,
                Description = "Молибденсодержащая нержавеющая сталь"
            },
            new Material
            {
                Id = 5,
                Name = "Алюминий",
                Grade = "АМГ-3",
                Density = 2700,
                PricePerKg = 180.00,
                Description = "Алюминиевый сплав с магнием"
            }
        };

        public ObservableCollection<Material> GetAllMaterials()
        {
            return new ObservableCollection<Material>(DefaultMaterials);
        }

        public Material GetMaterialById(int id)
        {
            return DefaultMaterials.FirstOrDefault(m => m.Id == id);
        }

        public double CalculateMaterialCost(double weight, Material material)
        {
            return weight * material.PricePerKg;
        }
    }
}
