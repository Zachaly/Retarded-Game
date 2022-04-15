using Retarded_Game.BasicStructures.Statistics;
using Retarded_Game.BasicStructures.Enums;

namespace Retarded_Game.Items
{
    internal class Armor : EquipmentPart
    {
        public ArmorType ArmorType { get; }
        public Armor(string name, string description, int price, Statistics statsChange, ArmorType type) 
            : base(name, description, price, StatRequirements.None, statsChange)
        {
            ArmorType = type;
        }
    }
}
