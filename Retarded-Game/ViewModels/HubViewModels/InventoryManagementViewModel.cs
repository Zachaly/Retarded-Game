using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Services;
using Retarded_Game.ViewModels.ItemViewModels;
using Retarded_Game.Models.Items;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System;
using Retarded_Game.Commands;
using Retarded_Game.Views.HubViews;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class InventoryManagementViewModel : HubSubCategoryBase, IItemListViewModel
    {
        private readonly Equipment _inventory;
        private readonly List<ItemViewModel> _allItems;
        private ItemViewModel? _selectedItem;
        private ObservableCollection<ItemViewModel>? _items;
        private static InventoryManagementView? _inventoryManagementView = null;

        public static InventoryManagementView InventoryManagementView
        {
            set => _inventoryManagementView = value;
        }
        public List<ItemViewModel> AllItems => _allItems;
        public ItemViewModel? SelectedItem 
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            } 
        }
        public ObservableCollection<ItemViewModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                SelectedItem = _items.FirstOrDefault();    
                OnPropertyChanged(nameof(Items));
            }
        }

        public ChangeInventoryCategoryCommand<WeaponViewModel> ChangeToWeapons { get; }
        public ChangeInventoryCategoryCommand<ItemViewModel> ChangeToAll { get; }
        public ChangeInventoryCategoryCommand<ArmorViewModel> ChangeToArmors { get; }
        public ChangeInventoryCategoryCommand<ShieldViewModel> ChangeToShields { get; }
        public ChangeInventoryCategoryCommand<RingViewModel> ChangeToRings { get; }
        public ChangeInventoryCategoryCommand<UpgradeMaterialViewModel> ChangeToUpgradeMaterials { get; }
        public ChangeInventoryCategoryCommand<ConsumableViewModel> ChangeToConsumables { get; }

        public InventoryManagementViewModel(NavigationService navigationService, Player player) : base(navigationService, player)
        {
            _inventory = player.Equipment;
            _allItems = new List<ItemViewModel>();

            var armorViewModels = _inventory.AllItems.Where(item => item is Armor)
                .Select(item => new ArmorViewModel(item as Armor)).ToList();
            _allItems.AddRange(armorViewModels);

            var weaponViewModels = _inventory.AllItems.Where(item => item is Weapon).
                Select(item => new WeaponViewModel(item as Weapon)).ToList();
            _allItems.AddRange(weaponViewModels);

            var ringViewModels = _inventory.AllItems.Where(item => item is Ring)
                .Select(item => new RingViewModel(item as Ring)).ToList();
            _allItems.AddRange(ringViewModels);

            var shieldViewModels = _inventory.AllItems.Where(item => item is Shield)
                .Select(item => new ShieldViewModel(item as Shield)).ToList();
            _allItems.AddRange(shieldViewModels);

            var upgradeViewModels = _inventory.AllItems.Where(item => item is UpgradeMaterial)
                .Select(item => new UpgradeMaterialViewModel(item as UpgradeMaterial)).ToList();
            _allItems.AddRange(upgradeViewModels);

            var consumableViewModels = _inventory.AllItems.Where(item => item is Consumable)
                .Select(item => new ConsumableViewModel(item as Consumable)).ToList();
            _allItems.AddRange(consumableViewModels);

            _selectedItem = _allItems.FirstOrDefault();
            Items = new ObservableCollection<ItemViewModel>();
            _allItems.ForEach(item => Items.Add(item));

            ChangeToWeapons = new ChangeInventoryCategoryCommand<WeaponViewModel>(this);
            ChangeToAll = new ChangeInventoryCategoryCommand<ItemViewModel>(this);
            ChangeToArmors = new ChangeInventoryCategoryCommand<ArmorViewModel>(this);
            ChangeToShields = new ChangeInventoryCategoryCommand<ShieldViewModel>(this);
            ChangeToRings = new ChangeInventoryCategoryCommand<RingViewModel>(this);
            ChangeToUpgradeMaterials = new ChangeInventoryCategoryCommand<UpgradeMaterialViewModel>(this);
            ChangeToConsumables = new ChangeInventoryCategoryCommand<ConsumableViewModel>(this);
        }

        public void SetDataColumns(Type type) => _inventoryManagementView?.SetColumnsToType(type);
    }
}
