using System.Collections.Generic;
using System.Linq;
using Retarded_Game.Models.Items;
using Retarded_Game.Models.BasicStructures.Enums;

namespace Retarded_Game.Models.Fighters.Players
{
    public sealed class Equipment
    {
        Player _player;
        public Armor Helmet { get; set; }
        public Armor Chestplate { get; set; }
        public Armor Pants { get; set; }
        public Armor Boots { get; set; }

        public Weapon RightHand { get; set; }
        public EquipmentPart LeftHand { get; set; }
        public List<Ring> EquippedRings { get; set; }

        public List<Item> AllItems { get;}

        public IEnumerable<Armor> AllHelmets;
        public IEnumerable<Armor> AllChestplates;
        public IEnumerable<Armor> AllTrousers;
        public IEnumerable<Armor> AllBoots;

        public IEnumerable<Weapon> AllWeapons;
        public IEnumerable<Shield> AllShields;

        public IEnumerable<Consumable> AllConsumables;
        public IEnumerable<Ring> AllRings;

        public Equipment()
        {
            AllItems = new List<Item>();

            AllHelmets = from Armor el in AllItems where el.ArmorType == ArmorType.Helmet select el;
            AllChestplates = from Armor el in AllItems where el.ArmorType == ArmorType.Chestplate select el;
            AllTrousers = from Armor el in AllItems where el.ArmorType == ArmorType.Pants select el;
            AllBoots = from Armor el in AllItems where el.ArmorType == ArmorType.Boots select el;

            AllWeapons = from Weapon el in AllItems where el != null select el;
            AllShields = from Shield el in AllItems where el != null select el;
            AllConsumables = from Consumable el in AllItems where el != null select el;
            AllRings = from Ring el in AllItems where el != null select el;

            EquippedRings = new List<Ring>() { Ring.None, Ring.None, Ring.None, Ring.None };
        }

        public void SetStartingEquipment(Player player)
        {
            _player = player;

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
            foreach(var ring in EquippedRings)
                ring.Equip(player, out checkIfEquipped);
            
        }

        public void Equip(Armor armor)
        {
            bool dummyBool; // used only for compatibility because armor does not care about stats(or at least shouldn't ;P)
            if(armor.ArmorType == ArmorType.Helmet)
            {
                Helmet.UnEquip(_player);
                Helmet = armor;
                Helmet.Equip(_player, out dummyBool);
            }
            else if(armor.ArmorType == ArmorType.Chestplate)
            {
                Chestplate.UnEquip(_player);
                Chestplate = armor;
                Chestplate.Equip(_player, out dummyBool);
            }
            else if(armor.ArmorType == ArmorType.Pants)
            {
                Pants.UnEquip(_player);
                Pants = armor;
                Pants.Equip(_player, out dummyBool);
            }
            else if (armor.ArmorType == ArmorType.Boots)
            {
                Boots.UnEquip(_player);
                Boots = armor;
                Boots.Equip(_player, out dummyBool);
            }
        }

        public void Equip(Ring ring, out bool enoughtSpace)
        {
            enoughtSpace = false;
            if(EquippedRings.Count < 4 && EquippedRings.Contains(Ring.None))
                enoughtSpace = true;

            if (enoughtSpace)
            {
                EquippedRings.Remove(Ring.None);
                EquippedRings.Add(ring);
                ring.Equip(_player, out enoughtSpace);
            }
        }

        public void EquipRightHand(Weapon weapon, out bool statsCorrect)
        {
            weapon.Equip(_player, out statsCorrect);

            if (!statsCorrect)
                return;

            if(weapon.WeaponType == WeaponType.OneHanded)
            {
                if(LeftHand is Weapon)
                {
                    if((LeftHand as Weapon).WeaponType == WeaponType.TwoHanded)
                    {
                        LeftHand = Weapon.EmptyHand;
                    }
                }
            }
            if(weapon.WeaponType == WeaponType.TwoHanded)
            {
                LeftHand.UnEquip(_player);
                LeftHand = weapon;
            }

            RightHand.UnEquip(_player);
            RightHand = weapon;
        }

        public void EquipLeftHand(EquipmentPart item, out bool done)
        {
            done = false;
            if (item is Weapon == false && item is Shield == false)
                return;

            item.Equip(_player, out done);

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
            
            LeftHand.UnEquip(_player);
            LeftHand = item;
        }
    }
}
