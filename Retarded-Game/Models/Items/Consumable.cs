using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.Models.Items
{
    public class Consumable : Item
    {
        public delegate void UseItem(Player player, Fighter target);
        event UseItem _usage;

        public Consumable(string name, string description, int price, UseItem usage) 
            : base(name, description, price)
        {
            _usage += usage;
        }

        public void Use(Player player, Fighter target)
        {
            _usage(player, target);
        }
    }
}
