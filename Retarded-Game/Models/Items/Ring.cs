using Retarded_Game.Models.BasicStructures.Statistics;

namespace Retarded_Game.Models.Items
{
    public class Ring : EquipmentPart
    {
        new public static Ring None { get; } = new Ring("None ring", "None ring", 0, new Statistics());
        public Ring(string name, string description, int price, Statistics statsChange) : base(name, description, price, StatRequirements.None, statsChange)
        {
        }
    }
}
