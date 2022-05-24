using Retarded_Game.Commands;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.Items;
using Retarded_Game.Services;
using Retarded_Game.ViewModels.ItemViewModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class SmithViewModel : HubSubCategoryBase
    {
        private WeaponViewModel _selectedWeapon;
        public WeaponViewModel SelectedWeapon 
        { 
            get => _selectedWeapon;
            set
            {
                _selectedWeapon = value;
                OnPropertyChanged(nameof(SelectedWeapon));
                UpgradeInfoChanged();
            }
        }

        public int UpgradeLevel => _selectedWeapon.Weapon.UpgradeLevel;
        public int MaterialsForNextLevel => _selectedWeapon.Weapon.MaterialForNextUpgrade;
        public int MaterialLevel => _selectedWeapon.Weapon.RequiredMaterialLevel;
        public double UpgradeCost => _selectedWeapon.Weapon.UpgradeCost;
        public double PlayerMoney => _player.Money;

        public ObservableCollection<WeaponViewModel> Weapons { get; private set; }
        public ObservableCollection<UpgradeMaterialViewModel> UpgradeMaterials { get; private set; }
        public UpgradeWeaponCommand UpgradeWeaponCommand => new UpgradeWeaponCommand(this);

        public SmithViewModel(NavigationService navigationService, Player player) : base(navigationService, player)
        {
            SetItems();
            SelectedWeapon = Weapons.First();
        }

        public void Upgrade()
        {
            SelectedWeapon.Upgrade(_player);
            UpgradeInfoChanged();
            OnPropertyChanged(nameof(PlayerMoney));
            OnPropertyChanged(nameof(SelectedWeapon));
            SetItems();
        }

        /// <summary>
        /// Updates values of properties containing informations specific to upgrade
        /// </summary>
        private void UpgradeInfoChanged()
        {
            OnPropertyChanged(nameof(UpgradeLevel));
            OnPropertyChanged(nameof(MaterialsForNextLevel));
            OnPropertyChanged(nameof(MaterialLevel));
            OnPropertyChanged(nameof(UpgradeCost));
        }

        /// <summary>
        /// Updates info about player's weapons and upgrade materials
        /// </summary>
        private void SetItems()
        {
            Weapons = new ObservableCollection<WeaponViewModel>();
            var weapons =
                _player.Equipment.AllItems
                .Where(item => item is Weapon)
                .Select(item => item as Weapon)
                .ToList();

            weapons.ForEach(weapon => Weapons.Add(new WeaponViewModel(weapon)));

            UpgradeMaterials = new ObservableCollection<UpgradeMaterialViewModel>();
            var upgradeMaterials =
                _player.Equipment.AllItems
                .Where(item => item is UpgradeMaterial)
                .Select(item => item as UpgradeMaterial)
                .ToList();

            upgradeMaterials.ForEach(material => UpgradeMaterials.Add(new UpgradeMaterialViewModel(material)));
        }

        /// <summary>
        /// Checks if the player meets requirements to upgrade weapon
        /// </summary>
        public bool CanUpgrade()
        {
            bool canupgrade = true;

            int numberOfFittingMaterials = 
                _player.Equipment.AllItems.
                Where(item => item is UpgradeMaterial).
                Select(item => item as UpgradeMaterial).
                Where(material => material.MaterialLevel == MaterialLevel).
                Count();

            canupgrade = numberOfFittingMaterials >= MaterialsForNextLevel;
            canupgrade = _player.Money >= UpgradeCost;
            return canupgrade;
        }
    }
}
