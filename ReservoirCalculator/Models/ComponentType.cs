namespace ReservoirCalculator.Models
{
    /// <summary>
    /// Тип комплектующего
    /// </summary>
    public enum ComponentType
    {
        /// <summary>Люк верхний/нижний</summary>
        Hatch,
        
        /// <summary>Патрубок</summary>
        Pipe,
        
        /// <summary>Лестница/трап</summary>
        Ladder,
        
        /// <summary>Клапан</summary>
        Valve,
        
        /// <summary>Фланец</summary>
        Flange,
        
        /// <summary>Крышка люка</summary>
        HatchCover,
        
        /// <summary>Уплотнение</summary>
        Seal,
        
        /// <summary>Крепёж (болты, гайки)</summary>
        Fastener,
        
        /// <summary>Изоляция</summary>
        Insulation,
        
        /// <summary>Покрытие (краска)</summary>
        Coating
    }
}
