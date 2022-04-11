namespace Retarded_Game.Items
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; }
        int Price { get; set; }

        public Item(string name, string description, int price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
