using Retarded_Game.Fighters.Players;

namespace Retarded_Game.Items
{
    public class Consumable : Item
    {
        public delegate void UseItem(Player player, Fighter target);
        event UseItem Usage;

        public Consumable(string name, string description, int price, UseItem usage) 
            : base(name, description, price)
        {
            Usage += usage;
        }

        public void Use(Fighter target)
        {
            Usage(MainWindow.Player, target);
        }
    }
}
