using ReservoirCalculator.Models;

namespace ReservoirCalculator.Services
{
    /// <summary>
    /// Сервис генерации спецификаций и смет
    /// </summary>
    public class SpecificationService
    {
        public Specification GenerateSpecification(
            ReservoirConfiguration config,
            double reservoirVolume,
            double reservoirMass,
            Material material)
        {
            var spec = new Specification
            {
                ConfigurationName = config.Name,
                ReservoirType = config.ReservoirType,
                ReservoirVolume = reservoirVolume,
                ReservoirMass = reservoirMass,
                ComponentsMass = config.GetTotalComponentsWeight(),
                ComponentsCost = config.GetTotalComponentsCost(),
                MaterialCost = reservoirMass * material.PricePerKg
            };

            // Добавляем материал резервуара
            spec.Items.Add(new SpecificationItem
            {
                Name = $"Материал резервуара ({material.Grade})",
                Type = "Материал",
                Quantity = reservoirMass,
                Weight = reservoirMass,
                Cost = spec.MaterialCost
            });

            // Добавляем комплектующие
            foreach (var component in config.SelectedComponents)
            {
                spec.Items.Add(new SpecificationItem
                {
                    Name = component.Name,
                    Type = component.Type.ToString(),
                    Quantity = component.Quantity,
                    Weight = component.GetTotalWeight(),
                    Cost = component.GetTotalCost()
                });
            }

            return spec;
        }

        public string GenerateSpecificationText(Specification spec)
        {
            var sb = new System.Text.StringBuilder();

            sb.AppendLine("╔════════════════════════════════════════════════════════════════╗");
            sb.AppendLine("║           СПЕЦИФИКАЦИЯ РЕЗЕРВУАРА И КОМПЛЕКТУЮЩИХ            ║");
            sb.AppendLine("╚════════════════════════════════════════════════════════════════╝\n");

            sb.AppendLine($"Конфигурация: {spec.ConfigurationName}");
            sb.AppendLine($"Тип резервуара: {spec.ReservoirType}");
            sb.AppendLine($"Дата создания: {spec.GeneratedDate:dd.MM.yyyy HH:mm}\n");

            sb.AppendLine("━━━ ОСНОВНЫЕ ПАРАМЕТРЫ ━━━");
            sb.AppendLine($"Объём резервуара: {spec.ReservoirVolume:F2} м³");
            sb.AppendLine($"Масса резервуара: {spec.ReservoirMass:F2} кг");
            sb.AppendLine($"Масса комплектующих: {spec.ComponentsMass:F2} кг");
            sb.AppendLine($"Общая масса: {spec.GetTotalWeight():F2} кг\n");

            sb.AppendLine("━━━ СТОИМОСТЬ ━━━");
            sb.AppendLine($"Стоимость материала: {spec.MaterialCost:F2} руб.");
            sb.AppendLine($"Стоимость комплектующих: {spec.ComponentsCost:F2} руб.");
            sb.AppendLine($"Итого: {spec.GetTotalCost():F2} руб.\n");

            sb.AppendLine("━━━ ДЕТАЛИЗИРОВАННАЯ СПЕЦИФИКАЦИЯ ━━━");
            sb.AppendLine($"{'№',-3} {'Наименование',-40} {'Кол-во',-8} {'Вес (кг)',-10} {'Стоимость',-15}");
            sb.AppendLine(new string('─', 80));

            int itemNumber = 1;
            foreach (var item in spec.Items)
            {
                sb.AppendLine($"{itemNumber,-3} {item.Name,-40} {item.Quantity,-8:F2} {item.Weight,-10:F2} {item.Cost,-15:F2}");
                itemNumber++;
            }

            sb.AppendLine("\n" + new string('═', 80));
            sb.AppendLine($"ИТОГО: {spec.GetTotalWeight():F2} кг | {spec.GetTotalCost():F2} руб.");

            return sb.ToString();
        }
    }
}
