namespace Retarded_Game.Models.Items
{
    /// <summary>
    /// Base class for item
    /// </summary>
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; }
        public int Price { get; set; }
        public static Item None => new Item("", "", 0);

        public Item(string name, string description, int price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public virtual Item Clone() => new Item(Name, Description, Price);
    }
}
