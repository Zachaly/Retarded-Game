using System;
using System.Linq;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.Models.Items
{
    /// <summary>
    /// Used in upgrading the weapons
    /// </summary>
    internal sealed class WeaponUpgrade
    {
        private readonly Weapon _weapon;
        private int _upgradeLevel = 0;
        private int _materialForNextLevel = 1;
        private int _cost = 100;
        private int _materialLevel = 1;

        public int UpgradeLevel => _upgradeLevel;
        public int MaterialForNextLevel => _materialForNextLevel;
        public int RequiredMaterialLevel => _materialLevel;
        public int Cost => _cost;

        public WeaponUpgrade(Weapon weapon) => _weapon = weapon;

        public void Upgrade(Player player, out bool canUpgrade)
        {
            canUpgrade = false;

            var upgradeMaterials = 
                player.Equipment.AllItems.
                Where(item => item is UpgradeMaterial).
                Select(item => item as UpgradeMaterial);

            if (upgradeMaterials.Where(item => item.MaterialLevel == _materialLevel).
                Count() >= MaterialForNextLevel 
                && player.Money >= Cost)
                canUpgrade = true;

            if (canUpgrade)
            {
                var usedMaterials = 
                    upgradeMaterials.
                    Where(item => item.MaterialLevel == _materialLevel).
                    Take(_materialForNextLevel).
                    ToArray();

                player.Equipment.AllItems.RemoveAll(item => usedMaterials.Contains(item));
                player.Money -= _cost;

                _weapon.BaseDamage *= 1.1;
                _upgradeLevel++;
                _cost += 100;
                _materialForNextLevel++;

                // every 3 upgrades you need material of higher level
                if (UpgradeLevel % 3 == 0)
                {
                    _materialLevel++;
                    _materialForNextLevel = 1;
                }
            }
        }
    }
}
