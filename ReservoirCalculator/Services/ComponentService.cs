using System.Collections.ObjectModel;
using ReservoirCalculator.Models;

namespace ReservoirCalculator.Services
{
    /// <summary>
    /// Сервис управления комплектующими
    /// </summary>
    public class ComponentService
    {
        private static readonly List<Component> DefaultComponents = new()
        {
            // Люки
            new Component
            {
                Id = 1,
                Name = "Люк верхний круглый 600мм",
                Type = ComponentType.Hatch,
                Description = "Люк для входа на крышу резервуара",
                Weight = 8.5,
                Quantity = 1,
                MaterialId = 1,
                Price = 3500,
                GostNumber = "ГОСТ 14501-82",
                Dimensions = "Ø600 мм"
            },
            new Component
            {
                Id = 2,
                Name = "Люк нижний круглый 500мм",
                Type = ComponentType.Hatch,
                Description = "Люк для слива и очистки резервуара",
                Weight = 6.2,
                Quantity = 1,
                MaterialId = 1,
                Price = 2800,
                GostNumber = "ГОСТ 14501-82",
                Dimensions = "Ø500 мм"
            },
            new Component
            {
                Id = 3,
                Name = "Люк прямоугольный 600х400мм",
                Type = ComponentType.Hatch,
                Description = "Люк прямоугольной формы",
                Weight = 7.8,
                Quantity = 1,
                MaterialId = 1,
                Price = 3200,
                GostNumber = "ГОСТ 14501-82",
                Dimensions = "600х400 мм"
            },

            // Патрубки
            new Component
            {
                Id = 4,
                Name = "Патрубок Ø100 мм, L=500мм",
                Type = ComponentType.Pipe,
                Description = "Всасывающий/напорный патрубок",
                Weight = 3.2,
                Quantity = 2,
                MaterialId = 1,
                Price = 1500,
                GostNumber = "ГОСТ 8734-75",
                Dimensions = "Ø100х500 мм"
            },
            new Component
            {
                Id = 5,
                Name = "Патрубок Ø50 мм, L=400мм",
                Type = ComponentType.Pipe,
                Description = "Переливной патрубок",
                Weight = 1.5,
                Quantity = 1,
                MaterialId = 1,
                Price = 800,
                GostNumber = "ГОСТ 8734-75",
                Dimensions = "Ø50х400 мм"
            },
            new Component
            {
                Id = 6,
                Name = "Патрубок Ø75 мм, L=450мм",
                Type = ComponentType.Pipe,
                Description = "Дополнительный патрубок",
                Weight = 2.3,
                Quantity = 1,
                MaterialId = 1,
                Price = 1100,
                GostNumber = "ГОСТ 8734-75",
                Dimensions = "Ø75х450 мм"
            },

            // Лестницы
            new Component
            {
                Id = 7,
                Name = "Лестница внутренняя 8 ступеней",
                Type = ComponentType.Ladder,
                Description = "Внутренняя лестница для входа",
                Weight = 12.5,
                Quantity = 1,
                MaterialId = 1,
                Price = 4200,
                GostNumber = "ГОСТ 9246-81",
                Dimensions = "H=2000 мм"
            },
            new Component
            {
                Id = 8,
                Name = "Лестница внешняя 10 ступеней",
                Type = ComponentType.Ladder,
                Description = "Внешняя лестница для доступа на крышу",
                Weight = 16.8,
                Quantity = 1,
                MaterialId = 1,
                Price = 5500,
                GostNumber = "ГОСТ 9246-81",
                Dimensions = "H=2500 мм"
            },
            new Component
            {
                Id = 9,
                Name = "Трап с поручнями",
                Type = ComponentType.Ladder,
                Description = "Трап для входа и выхода",
                Weight = 9.3,
                Quantity = 1,
                MaterialId = 1,
                Price = 3800,
                GostNumber = "ГОСТ 9246-81",
                Dimensions = "H=1500 мм"
            },

            // Клапаны
            new Component
            {
                Id = 10,
                Name = "Клапан обратный шаровый Ø100",
                Type = ComponentType.Valve,
                Description = "Обратный клапан для предотвращения обратного потока",
                Weight = 4.5,
                Quantity = 1,
                MaterialId = 1,
                Price = 2200,
                GostNumber = "ГОСТ 12815-80",
                Dimensions = "Ø100 мм"
            },
            new Component
            {
                Id = 11,
                Name = "Клапан отсечной Ø100",
                Type = ComponentType.Valve,
                Description = "Отсечной клапан для герметизации",
                Weight = 5.2,
                Quantity = 1,
                MaterialId = 1,
                Price = 2800,
                GostNumber = "ГОСТ 12815-80",
                Dimensions = "Ø100 мм"
            },
            new Component
            {
                Id = 12,
                Name = "Предохранительный клапан",
                Type = ComponentType.Valve,
                Description = "Клапан для сброса давления",
                Weight = 3.8,
                Quantity = 1,
                MaterialId = 1,
                Price = 3500,
                GostNumber = "ГОСТ 12806-80",
                Dimensions = "Ø50 мм"
            },

            // Фланцы
            new Component
            {
                Id = 13,
                Name = "Фланец приварной Ø100",
                Type = ComponentType.Flange,
                Description = "Приварной фланец для соединения",
                Weight = 2.8,
                Quantity = 4,
                MaterialId = 1,
                Price = 450,
                GostNumber = "ГОСТ 12821-80",
                Dimensions = "Ø100 мм"
            },
            new Component
            {
                Id = 14,
                Name = "Фланец приварной Ø50",
                Type = ComponentType.Flange,
                Description = "Приварной фланец меньшего размера",
                Weight = 1.2,
                Quantity = 2,
                MaterialId = 1,
                Price = 250,
                GostNumber = "ГОСТ 12821-80",
                Dimensions = "Ø50 мм"
            },

            // Уплотнения
            new Component
            {
                Id = 15,
                Name = "Прокладка резиновая толщина 3мм",
                Type = ComponentType.Seal,
                Description = "Резиновое уплотнение для люков",
                Weight = 0.5,
                Quantity = 5,
                MaterialId = 1,
                Price = 150,
                GostNumber = "ГОСТ 9833-73",
                Dimensions = "3х1000 мм"
            },

            // Крепёж
            new Component
            {
                Id = 16,
                Name = "Болт M12 ГОСТ 7798-70",
                Type = ComponentType.Fastener,
                Description = "Болт для крепления люков и фланцев",
                Weight = 0.12,
                Quantity = 50,
                MaterialId = 1,
                Price = 8.5,
                GostNumber = "ГОСТ 7798-70",
                Dimensions = "M12х60"
            },
            new Component
            {
                Id = 17,
                Name = "Гайка M12",
                Type = ComponentType.Fastener,
                Description = "Гайка для болтов",
                Weight = 0.04,
                Quantity = 50,
                MaterialId = 1,
                Price = 3.0,
                GostNumber = "ГОСТ 5915-70",
                Dimensions = "M12"
            },

            // Изоляция
            new Component
            {
                Id = 18,
                Name = "Минеральная вата 100мм",
                Type = ComponentType.Insulation,
                Description = "Теплоизоляция для резервуара",
                Weight = 0.1,
                Quantity = 1,
                MaterialId = 1,
                Price = 2500,
                GostNumber = "ГОСТ 9573-96",
                Dimensions = "1000х1000х100 мм"
            },

            // Покрытие
            new Component
            {
                Id = 19,
                Name = "Краска эпоксидная 25кг",
                Type = ComponentType.Coating,
                Description = "Эпоксидная краска для защиты",
                Weight = 25.0,
                Quantity = 1,
                MaterialId = 1,
                Price = 4800,
                GostNumber = "ГОСТ 28183-89",
                Dimensions = "25 кг"
            }
        };

        public ObservableCollection<Component> GetAllComponents()
        {
            return new ObservableCollection<Component>(DefaultComponents);
        }

        public ObservableCollection<Component> GetComponentsByType(ComponentType type)
        {
            return new ObservableCollection<Component>(
                DefaultComponents.Where(c => c.Type == type).ToList()
            );
        }

        public Component GetComponentById(int id)
        {
            return DefaultComponents.FirstOrDefault(c => c.Id == id);
        }

        public List<Component> GetStandardComponents(string reservoirType)
        {
            // Стандартный набор для резервуара
            var standardIds = new[] { 1, 4, 5, 7, 10, 13, 15, 16, 17, 19 };
            return DefaultComponents.Where(c => standardIds.Contains(c.Id)).ToList();
        }
    }
}
