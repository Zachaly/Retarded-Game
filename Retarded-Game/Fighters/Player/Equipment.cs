using System.Collections.Generic;
using System.Linq;
using Retarded_Game.Items;
using Retarded_Game.BasicStructures.Statistics;
using Retarded_Game.BasicStructures;
using Retarded_Game.BasicStructures.Enums;

namespace Retarded_Game
{
    internal sealed class Equipment
    {
        public Armor Helmet { get; set; }
        public Armor Chestplate { get; set; }
        public Armor Pants { get; set; }
        public Armor Boots { get; set; }

        public Weapon RightHand { get; set; }
        public EquipmentPart LeftHand { get; set; }

        public List<Item> AllItems { get;}

        public IEnumerable<Armor> AllHelmets;
        public IEnumerable<Armor> AllChestplates;
        public IEnumerable<Armor> AllTrousers;
        public IEnumerable<Armor> AllBoots;

        public IEnumerable<Weapon> AllWeapons;
        public IEnumerable<Shield> AllShields;

        public IEnumerable<Consumable> AllConsumables;

        Player player;

        // used when left hand is empty, used to avoid null reference
        Weapon EmptyHand = new Weapon("Empty Hand", "", 0, StatRequirements.None, new Statistics(), Damage.None, 0, 0, 0, 0, WeaponType.OneHanded);

        public Equipment(Player player)
        {
            AllItems = new List<Item>();

            AllHelmets = from Armor el in AllItems where el.ArmorType == ArmorType.Helmet select el;
            AllChestplates = from Armor el in AllItems where el.ArmorType == ArmorType.Chestplate select el;
            AllTrousers = from Armor el in AllItems where el.ArmorType == ArmorType.Pants select el;
            AllBoots = from Armor el in AllItems where el.ArmorType == ArmorType.Boots select el;

            AllWeapons = from Weapon el in AllItems where el != null select el;
            AllShields = from Shield el in AllItems where el != null select el;
            AllConsumables = from Consumable el in AllItems where el != null select el;

            this.player = player;
        }

        public void SetStartingEquipment()
        {
            Helmet = new Armor("Leather Helmet", "", 1,
                new Statistics(0, 0, 1, 0, -0.1, 0, 0, 0, 0, 0, 0, 0, 0),
                ArmorType.Helmet);
            Chestplate = new Armor("Leather Chestplate", "", 1,
                new Statistics(0, 0, 2.5, 0, -0.2, 0, 0, 0, 0, 0, 0, 0, 0),
                ArmorType.Chestplate);
            Pants = new Armor("Leather Pants", "", 1,
                new Statistics(0, 0, 1.5, 0, -0.1, 0, 0, 0, 0, 0, 0, 0, 0),
                ArmorType.Pants);
            Boots = new Armor("Leather Boots", "", 1,
                new Statistics(0, 0, 1, 0, -0.1, 0, 0, 0, 0, 0, 0, 0, 0),
                ArmorType.Boots);

            RightHand = new Weapon("Iron Shortsword", "", 1, StatRequirements.None, new Statistics(), new Damage(5, 0, 0, 0, 0),
                WeaponScaling.D, WeaponScaling.D, WeaponScaling.None, WeaponScaling.None, WeaponType.OneHanded);

            LeftHand = new Shield("Wooden Shield", "", 1, StatRequirements.None, new Statistics(),
                0.6, 0, 0, 0, 0, 50);

            AllItems.Add(Helmet);
            AllItems.Add(Chestplate);
            AllItems.Add(Pants);
            AllItems.Add(Boots);
            AllItems.Add(RightHand);
            AllItems.Add(LeftHand);

            AllItems.Add(new Consumable("Minor healing potion", "Heals 5 hp", 2, (player, _) =>
             {
                 player.Statistics.BaseStats.CurrentHP += 5;
             }));

            bool checkIfEquipped;

            Equip(Helmet);
            Equip(Chestplate);
            Equip(Pants);
            Equip(Boots);
            EquipRightHand(RightHand, out checkIfEquipped);
            EquipLeftHand(LeftHand, out checkIfEquipped);
        }

        public void Equip(Armor armor)
        {
            bool dummyBool; // used only for compatibility because armor does not care about stats(or at least shouldn't ;P)
            if(armor.ArmorType == ArmorType.Helmet)
            {
                Helmet.UnEquip(player);
                Helmet = armor;
                Helmet.Equip(player, out dummyBool);
            }
            else if(armor.ArmorType == ArmorType.Chestplate)
            {
                Chestplate.UnEquip(player);
                Chestplate = armor;
                Chestplate.Equip(player, out dummyBool);
            }
            else if(armor.ArmorType == ArmorType.Pants)
            {
                Pants.UnEquip(player);
                Pants = armor;
                Pants.Equip(player, out dummyBool);
            }
            else if (armor.ArmorType == ArmorType.Boots)
            {
                Boots.UnEquip(player);
                Boots = armor;
                Boots.Equip(player, out dummyBool);
            }
        }

        public void EquipRightHand(Weapon weapon, out bool statsCorrect)
        {
            weapon.Equip(player, out statsCorrect);

            if (!statsCorrect)
                return;

            if(weapon.WeaponType == WeaponType.OneHanded)
            {
                if(LeftHand is Weapon)
                {
                    if((LeftHand as Weapon).WeaponType == WeaponType.TwoHanded)
                    {
                        LeftHand = EmptyHand;
                    }
                }
            }
            if(weapon.WeaponType == WeaponType.TwoHanded)
            {
                LeftHand.UnEquip(player);
                LeftHand = weapon;
            }

            RightHand.UnEquip(player);
            RightHand = weapon;
        }

        public void EquipLeftHand(EquipmentPart item, out bool done)
        {
            done = false;
            if (item is Weapon == false && item is Shield == false)
                return;

            item.Equip(player, out done);

            if (!done)
                return;

            if(item is Weapon)
            {
                var weapon = item as Weapon;
                if(weapon.WeaponType == WeaponType.TwoHanded)
                    return;
            }

            if(LeftHand is Weapon)
            {
                if ((LeftHand as Weapon).WeaponType == WeaponType.TwoHanded)
                    return;
            }
            
            LeftHand.UnEquip(player);
            LeftHand = item;
        }
    }
}
