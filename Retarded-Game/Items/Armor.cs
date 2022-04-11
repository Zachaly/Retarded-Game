using Retarded_Game.BasicStructures.Statistics;

namespace Retarded_Game.Items
{
    enum ArmorType
    {
        Helmet,
        Chestplate,
        Pants,
        Boots
    }

    internal class Armor : EquipmentPart
    {
        public ArmorType ArmorType { get; }
        public Armor(string name, string description, int price, Statistics statsChange, ArmorType type) 
            : base(name, description, price, 0, 0, 0, 0, statsChange)
        {
            ArmorType = type;
        }
    }
}
