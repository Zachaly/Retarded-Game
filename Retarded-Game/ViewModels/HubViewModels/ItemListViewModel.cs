using System.Collections.ObjectModel;
using Retarded_Game.ViewModels.ItemViewModels;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.Items;
using Retarded_Game.Services;
using System.Collections.Generic;
using Retarded_Game.Commands;
using System;
using System.Linq;

namespace Retarded_Game.ViewModels.HubViewModels
{
    /// <summary>
    /// ViewModel that contains a list of items and they can be changed
    /// </summary>
    public abstract class ItemListViewModel : HubSubCategoryBase
    {
        private ItemViewModel? _selectedItem;

        public ObservableCollection<ItemViewModel> AllItems { get; }
        public ObservableCollection<ItemViewModel> Items { get; set; }

        public ItemViewModel? SelectedItem
        {
            get 
            { 
                if(_selectedItem is null)
                    return new ItemViewModel(Item.None);
                return _selectedItem; 
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ChangeInventoryCategoryCommand<WeaponViewModel> ChangeToWeapons { get; }
        public ChangeInventoryCategoryCommand<ItemViewModel> ChangeToAll { get; }
        public ChangeInventoryCategoryCommand<ArmorViewModel> ChangeToArmors { get; }
        public ChangeInventoryCategoryCommand<ShieldViewModel> ChangeToShields { get; }
        public ChangeInventoryCategoryCommand<RingViewModel> ChangeToRings { get; }
        public ChangeInventoryCategoryCommand<UpgradeMaterialViewModel> ChangeToUpgradeMaterials { get; }
        public ChangeInventoryCategoryCommand<ConsumableViewModel> ChangeToConsumables { get; }

        public ItemListViewModel(NavigationService navigationService, Player player) : base(navigationService, player)
        {
            AllItems = new ObservableCollection<ItemViewModel>();
            Items = new ObservableCollection<ItemViewModel>();

            ChangeToWeapons = new ChangeInventoryCategoryCommand<WeaponViewModel>(this);
            ChangeToAll = new ChangeInventoryCategoryCommand<ItemViewModel>(this);
            ChangeToArmors = new ChangeInventoryCategoryCommand<ArmorViewModel>(this);
            ChangeToShields = new ChangeInventoryCategoryCommand<ShieldViewModel>(this);
            ChangeToRings = new ChangeInventoryCategoryCommand<RingViewModel>(this);
            ChangeToUpgradeMaterials = new ChangeInventoryCategoryCommand<UpgradeMaterialViewModel>(this);
            ChangeToConsumables = new ChangeInventoryCategoryCommand<ConsumableViewModel>(this);
        }

        /// <summary>
        /// Changes the columns of current list depending on item type
        /// </summary>
        /// <param name="type"></param>
        public abstract void SetDataColumns(Type type);

        /// <summary>
        /// Creates viewmodels of given items
        /// </summary>
        protected void SetItemLists(List<Item> items)
        {
            var armorViewModels = items.Where(item => item is Armor)
                .Select(item => new ArmorViewModel(item as Armor)).ToList();
            armorViewModels.ForEach(item => AllItems.Add(item));

            var weaponViewModels = items.Where(item => item is Weapon).
                Select(item => new WeaponViewModel(item as Weapon)).ToList();
            weaponViewModels.ForEach(item => AllItems.Add(item));

            var ringViewModels = items.Where(item => item is Ring)
                .Select(item => new RingViewModel(item as Ring)).ToList();
            ringViewModels.ForEach(item => AllItems.Add(item));

            var shieldViewModels = items.Where(item => item is Shield)
                .Select(item => new ShieldViewModel(item as Shield)).ToList();
            shieldViewModels.ForEach(item => AllItems.Add(item));

            var upgradeViewModels = items.Where(item => item is UpgradeMaterial)
                .Select(item => new UpgradeMaterialViewModel(item as UpgradeMaterial)).ToList();
            upgradeViewModels.ForEach(item => AllItems.Add(item));

            var consumableViewModels = items.Where(item => item is Consumable)
                .Select(item => new ConsumableViewModel(item as Consumable)).ToList();
            consumableViewModels.ForEach(item => AllItems.Add(item));

            var allItems = AllItems.Select(item => item).ToList();
            allItems.ForEach(item => Items.Add(item));

            SelectedItem = Items.First();
        }
    }
}
