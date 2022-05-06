using System;
using System.Collections.Generic;
using System.Linq;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.Models.Items
{
    internal class WeaponUpgrade
    {
        private readonly Weapon _weapon;
        private int _upgradeLevel = 0;
        private int _materialForNextLevel = 1;
        private int _cost = 100;
        private int _materialLevel = 1;

        public int UpgradeLevel => _upgradeLevel;
        public int MaterialForNextLevel => _materialForNextLevel;
        public int Cost => _cost;

        public WeaponUpgrade(Weapon weapon) => _weapon = weapon;

        public void Upgrade(Player player, out bool canUpgrade)
        {
            canUpgrade = false;

            if(player.Equipment.UpgradeMaterials
                .Where(item => item.MaterialLevel == _materialLevel)
                .Count() >= MaterialForNextLevel && player.Money >= Cost)
                canUpgrade = true;

            if (canUpgrade)
            {
                var usedMaterials = player.Equipment.UpgradeMaterials
                    .Where(item => item.MaterialLevel == _materialLevel)
                    .Take(_materialForNextLevel).ToArray();
                player.Equipment.AllItems.RemoveAll(item => usedMaterials.Contains(item));

                _weapon.BaseDamage *= 1.1;
                _upgradeLevel++;
                _cost += 100;
                _materialForNextLevel++;

                if (UpgradeLevel % 3 == 0)
                {
                    _materialLevel++;
                    _materialForNextLevel = 1;
                }
            }
        }

    }
}
