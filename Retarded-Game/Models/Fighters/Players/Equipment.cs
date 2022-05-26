using System.Collections.Generic;
using System.Linq;
using Retarded_Game.Models.Items;
using Retarded_Game.Models.BasicStructures.Enums;

namespace Retarded_Game.Models.Fighters.Players
{
    /// <summary>
    /// Class containing player equipment
    /// </summary>
    public sealed class Equipment
    {
        Player? _player;
        public Armor Helmet { get; set; } = Armor.None(ArmorType.Helmet);
        public Armor Chestplate { get; set; } = Armor.None(ArmorType.Chestplate);
        public Armor Pants { get; set; } = Armor.None(ArmorType.Pants);
        public Armor Boots { get; set; } = Armor.None(ArmorType.Boots);

        // checks if you are trying to equip item on left hand in
        public bool LeftHandEquip = false;

        public Weapon RightHand { get; set; } = Weapon.EmptyHand;
        // marked as equipment part because it can be either shield or weapon
        public EquipmentPart LeftHand { get; set; } = Weapon.EmptyHand;
        public List<Ring> EquippedRings { get; set; }

        public List<Item> AllItems { get; }

        public List<EquipmentPart> EquippedItems 
            => new List<EquipmentPart> { LeftHand, RightHand, Helmet, Chestplate, Pants, Boots};

        public Equipment()
        {
            AllItems = new List<Item>();
            EquippedRings = new List<Ring>() { Ring.None, Ring.None, Ring.None, Ring.None };
        }

        /// <summary>
        /// Sets items that equipment constains on start
        /// </summary>
        public void SetStartingEquipment(Armor helmet, Armor chestplate, Armor pants, Armor boots,
            Weapon weapon, EquipmentPart leftHand, List<Ring> rings, List<Consumable> consumables)
        {
            Helmet = helmet;
            Chestplate = chestplate;
            Pants = pants;
            Boots = boots;
            RightHand = weapon;
            if (RightHand.WeaponType != WeaponType.TwoHanded)
                LeftHand = leftHand;
            else
                LeftHand = RightHand;

            for (int i = 0; i < rings.Count; i++)
                EquippedRings[i] = rings[i];
            consumables.ForEach(item => AllItems.Add(item));
            EquippedRings.Where(item => item != Ring.None).ToList().ForEach(item => AllItems.Add(item));
            
            AllItems.Add(LeftHand);
            if(!AllItems.Contains(RightHand))
                AllItems.Add(RightHand);
            AllItems.Add(Boots);
            AllItems.Add(Chestplate);
            AllItems.Add(Pants);
            AllItems.Add(Helmet);
            AllItems.Where(item => item.Name == "None" || item.Name == "Empty Hand").ToList()
                .ForEach(item => AllItems.Remove(item));
            // removes placeholders for no item equipped from list of items
        }

        /// <summary>
        /// Sets the player holding the equipment and equips starting items
        /// </summary>
        public void SetPlayer(Player player)
        {
            _player = player;

            Equip(Helmet);
            Equip(Chestplate);
            Equip(Pants);
            Equip(Boots);
            Equip(RightHand);
            Equip(LeftHand);
            EquippedRings.ForEach(x => Equip(x));
        }

        /// <summary>
        /// Equips given item
        /// </summary>
        public void Equip(EquipmentPart equipmentPart)
        {
            if(equipmentPart is Armor)
                Equip(equipmentPart as Armor);
            else if(LeftHandEquip)
                EquipLeftHand(equipmentPart);
            else if(equipmentPart is Ring)
                Equip(equipmentPart as Ring);
            else if(equipmentPart is Weapon)
                Equip(equipmentPart as Weapon);
        }

        private void Equip(Armor armor)
        {
            if(armor.ArmorType == ArmorType.Helmet)
            {
                Helmet.UnEquip(_player);
                Helmet = armor;
                Helmet.Equip(_player);
            }
            else if(armor.ArmorType == ArmorType.Chestplate)
            {
                Chestplate.UnEquip(_player);
                Chestplate = armor;
                Chestplate.Equip(_player);
            }
            else if(armor.ArmorType == ArmorType.Pants)
            {
                Pants.UnEquip(_player);
                Pants = armor;
                Pants.Equip(_player);
            }
            else if (armor.ArmorType == ArmorType.Boots)
            {
                Boots.UnEquip(_player);
                Boots = armor;
                Boots.Equip(_player);
            }
        }

        private void Equip(Ring ring)
        {
            bool enoughtSpace = false;
            // player can have only 4 rings equipped at a time
            if(EquippedRings.Count < 4 && EquippedRings.Contains(Ring.None))
                enoughtSpace = true;

            if (enoughtSpace)
            {
                EquippedRings.Remove(Ring.None);
                EquippedRings.Add(ring);
                ring.Equip(_player);
            }
        }

        private void Equip(Weapon weapon)
        {
            bool statsCorrect = weapon.StatRequirements.AreFulliled(_player.Statistics.BaseStats);

            if (!statsCorrect)
                return;

            weapon.Equip(_player);

            if (weapon.WeaponType == WeaponType.OneHanded)
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

        private void EquipLeftHand(EquipmentPart item)
        {
            if (item is Weapon == false && item is Shield == false)
                return;

            // cannot equip a two handed weapon to left hand
            if(item is Weapon)
                if((item as Weapon).WeaponType == WeaponType.TwoHanded)
                    return;

            // cannot equip anything to left hand when you have currently equipped two handed weapon
            if(LeftHand is Weapon)
                if ((LeftHand as Weapon).WeaponType == WeaponType.TwoHanded)
                    return;

            if (!item.StatRequirements.AreFulliled(_player.Statistics.BaseStats))
                return;
            
            item.Equip(_player);

            LeftHand.UnEquip(_player);
            LeftHand = item;
        }

        public void Unequip(EquipmentPart item)
        {
            if(item == RightHand)
            {
                RightHand.UnEquip(_player);
                RightHand = Weapon.EmptyHand;
            }
            else if(item == LeftHand)
            {
                LeftHand.UnEquip(_player);
                LeftHand = Weapon.EmptyHand;
            }
            else if(item == Helmet)
            {
                Helmet.UnEquip(_player);
                Helmet = Armor.None(ArmorType.Helmet);
            }
            else if(item == Chestplate)
            {
                Chestplate.UnEquip(_player);
                Chestplate = Armor.None(ArmorType.Chestplate);
            }
            else if(item == Pants)
            {
                Pants.UnEquip(_player);
                Pants = Armor.None(ArmorType.Pants);
            }
            else if(item == Boots)
            {
                Boots.UnEquip(_player);
                Boots = Armor.None(ArmorType.Boots);
            }
            else if (EquippedRings.Contains(item))
            {
                (item as Ring).UnEquip(_player);
                EquippedRings.Remove(item as Ring);
                EquippedRings.Add(Ring.None);
            }
        }
    }
}
