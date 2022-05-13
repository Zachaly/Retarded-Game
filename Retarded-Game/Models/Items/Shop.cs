using System.Collections.Generic;
using Retarded_Game.Models.Fighters.Players;
using System.Linq;

namespace Retarded_Game.Models.Items
{
    public class Shop
    {
        private readonly List<Item> _basicOffer;
        public List<Item> Offer => _basicOffer;

        public Shop() => _basicOffer = new List<Item>();

        public void BuyItem(Item item, Player player)
        {
            player.Money -= item.Price;
            player.Equipment.AllItems.Add(item);
            _basicOffer.Remove(item);
        }

        public void AppendOffer(List<Item> items) => _basicOffer.AddRange(items);

        /// <summary>
        /// Sets items standard to the shop
        /// </summary>
        public void SetStandardOffer()
        {
            List<Item> basicOffer = new List<Item>();

            UpgradeMaterial material = new UpgradeMaterial("Iron slab", "", 15, 1);

            basicOffer.Add(material.Clone());
            basicOffer.Add(material.Clone());
            basicOffer.Add(material);

            Consumable healthPotion = new Consumable("Minor healing potion", "Heals 10 hp", 5,
                (player, target) => player.Statistics.BaseStats.CurrentHP += 10);

            Consumable manaPotion = new Consumable("Minor mana potion", "Gives 5 mana", 5,
                (player, target) => player.Statistics.BaseStats.CurrentMana += 5);

            for (int i = 0; i < 5; i++)
            {
                basicOffer.Add(healthPotion.Clone());
                basicOffer.Add(manaPotion.Clone());
            }

            _basicOffer.AddRange(basicOffer);
        }
    }
}
