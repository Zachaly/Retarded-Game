using Retarded_Game.Models.BasicStructures.Statistics;
using Retarded_Game.Models.BasicStructures.Enums;

namespace Retarded_Game.Models.Items
{
    /// <summary>
    /// Class describing armor
    /// </summary>
    public class Armor : EquipmentPart
    {
        public ArmorType ArmorType { get; }
        public Armor(string name, string description, int price, Statistics statsChange, ArmorType type) 
            : base(name, description, price, StatRequirements.None, statsChange) 
            => ArmorType = type;

        /// <summary>
        /// Default armor of given type
        /// </summary>
        public static Armor None(ArmorType type) => new Armor("None", "", 0, new Statistics(), type);
    }
}
