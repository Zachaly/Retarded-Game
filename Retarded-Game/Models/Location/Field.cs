using Retarded_Game.Models.BasicStructures.Enums;
using Retarded_Game.Models.Fighters.AI;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Retarded_Game.Models.Location
{
    public class Field
    {
        private readonly Random _random = new Random();
        private int RandomChance => _random.Next(0, 101);

        public bool Crossable { get; private set; } = false;
        public bool CanEnemySpawn { get; set; } = false;
        public bool CanFindItem { get; set; } = false;

        public int EnemySpawnChance { get; set; } = 0;
        public int ItemFindChance { get; set; } = 0;

        public List<Item> Items { get; set; }
        public List<(Enemy enemy, int spawnChance)> Enemies { get; set; }

        public FieldType Type { get; }
        public int XPosition { get; }
        public int YPosition { get; }

        public Field(FieldType type,List<Item> items, List<(Enemy enemy, int spawnChance)> enemies, int xPosition, int yPosition)
        {
            Type = type;
            XPosition = xPosition;
            YPosition = yPosition;
            Items = items;
            Enemies = enemies;

            AdjustToType();
        }

        private void AdjustToType()
        {
            if (Type != FieldType.Wall)
            {
                Crossable = true;
            }
            else
                return;

            if (Type == FieldType.Fight ||
                Type == FieldType.RewardedFight ||
                Type == FieldType.Random)
                CanEnemySpawn = true;

            if(Type == FieldType.Item ||
               Type == FieldType.RewardedFight ||
               Type == FieldType.Random)
               CanFindItem = true;

            if (CanFindItem)
                ItemFindChance = RandomChance;
            if (CanEnemySpawn)
                EnemySpawnChance = RandomChance;
        }

        public void Cleared()
        {
            CanFindItem = false;
            CanEnemySpawn = false;
            EnemySpawnChance = 0;
            ItemFindChance = 0;
        }

        public void GiveItems(Player player)
        {
            int numberOfItems = _random.Next(0, 3);

            for (int i = 0; i < numberOfItems; i++)
                player.Equipment.AllItems.Add(Items[_random.Next(0, Items.Count)].Clone());
        }

        public Enemy GetEnemy()
        {
            var enemies = Enemies.Where(enemy => enemy.spawnChance <= RandomChance).ToList();

            if(enemies.Count == 0)
                return enemies[_random.Next(0, Enemies.Count)].enemy;

            enemies.Sort((enemy1, enemy2) => 
            { 
                if(enemy1.spawnChance == enemy2.spawnChance)
                    return 0;
                if (enemy1.spawnChance > enemy2.spawnChance)
                    return 1;
                
                return -1;
            });

            return enemies.First().enemy;
        }
    }
}
