namespace Retarded_Game.Items
{
    delegate void UseItem(Player player, Fighter target);

    internal class Consumable : Item
    {
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
