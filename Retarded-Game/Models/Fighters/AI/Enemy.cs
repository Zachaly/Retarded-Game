using System;
using System.Collections.Generic;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.Items;
using Retarded_Game.Services;

namespace Retarded_Game.Models.Fighters.AI
{
    /// <summary>
    /// Character controlled by computer during fight
    /// </summary>
    public class Enemy : Fighter
    {
        private readonly List<EnemyAction> _actions;
        private ActionPicker _actionPicker;
        private readonly int _baseExpGain;
        private readonly int _baseMoneyGain;

        public List<Item> ItemDrops { get; }
        public int ExpGain => _baseExpGain * Level;
        public int MoneyGain => _baseMoneyGain * Level;

        public Enemy(string name, int level, List<EnemyAction> actions, List<Item> itemDrops) : base(name, level)
        {
            _actions = actions;
            ItemDrops = itemDrops;
        }

        public void SetActionPicker(Player target) => _actionPicker = new ActionPicker(this, _actions, target);

        public EnemyAction GetEnemyAction() => _actionPicker.GetAction();

        public void Die(Player player)
        {
            player.Equipment.AllItems.AddRange(DropItems());
            player.Experience += ExpGain;
            player.Money += MoneyGain;
        }

        public List<Item> DropItems()
        {
            var items = new List<Item>();
            Random random = new Random();

            int numberOfItems = random.Next(0, 3);

            for(int i = 0; i < numberOfItems; i++)
                items.Add(ItemDrops[random.Next(0, ItemDrops.Count)].Clone());

            return items;
        }
    }
}
