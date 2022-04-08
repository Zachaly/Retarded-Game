using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retarded_Game.Items;

namespace Retarded_Game
{
    internal class Equipment
    {
        public Armor Helmet { get; set; }
        public Armor Chestplate { get; set; }
        public Armor Trousers { get; set; }
        public Armor Boots { get; set; }

        public Weapon RightWeapon { get; set; }
        public EquipmentPart LeftWeapon { get; set; }

        public List<Item> AllItems { get; }

        public IEnumerable<Armor> AllHelmets;
        public IEnumerable<Armor> AllChestplates;
        public IEnumerable<Armor> AllTrousers;
        public IEnumerable<Armor> AllBoots;

        public IEnumerable<Weapon> AllWeapons;

        public Equipment()
        {
            AllItems = new List<Item>();
            AllHelmets = from Armor el in AllItems where el.ArmorType == ArmorType.Helmet select el as Armor;
            AllChestplates = from Armor el in AllItems where el.ArmorType == ArmorType.Chestplate select el as Armor;
            AllTrousers = from Armor el in AllItems where el.ArmorType == ArmorType.Pants select el as Armor;
            AllBoots = from Armor el in AllItems where el.ArmorType == ArmorType.Boots select el as Armor;

            AllWeapons = from Weapon el in AllItems where el != null select el as Weapon;

        }
    }
}
