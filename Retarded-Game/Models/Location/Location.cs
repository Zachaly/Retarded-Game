using Retarded_Game.Models.BasicStructures.Enums;
using Retarded_Game.Models.Fighters.AI;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Models.Location
{
    public class Location
    {
        public string Name { get; }
        public string Description { get; }
        public LocationSize Size { get; }
        public List<List<Field>> Fields { get; set; }
        public List<(Enemy Enemy, int SpawnChance)> Enemies { get; }
        public List<Item> Items { get; }

        public (int x, int y) PlayerPosition { get; set; }

        public Location(string name, string description, LocationSize size,
            List<(Enemy Enemy, int SpawnChance)> enemies, List<Item> items)
        {
            Name = name;
            Description = description;
            Size = size;
            Enemies = enemies;
            Items = items;

            Size.SetSize();
            GenerateFields();
        }

        private void GenerateFields()
        {
            Fields = new List<List<Field>>();
            for(int i = 0; i < Size.VerticalSize; i++)
                Fields.Add(new List<Field>());
        }

        public void MovePlayer(Player player, int xMove, int yMove)
        {
            Field field;

            try
            {
                field = Fields[PlayerPosition.x + xMove][PlayerPosition.y + yMove];
            }
            catch(IndexOutOfRangeException)
            {
                return;
            }   
        }

        public void SetStartingPlayerPosition(Player player)
        {
            var allFields = new List<Field>();
            Fields.ForEach(column => allFields.AddRange(column));

            var startField = allFields.Where(field => field.Type == FieldType.Start).First();

            PlayerPosition = (startField.XPosition, startField.YPosition);
        }
    }
}
