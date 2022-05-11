using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Services;
using Retarded_Game.ViewModels.ItemViewModels;
using Retarded_Game.Models.Items;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Retarded_Game.Commands;
using Retarded_Game.Views.HubViews;
using System;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class ShopViewModel : HubSubCategoryBase, IItemListViewModel
    {
        private readonly Shop _shop;
        private ItemViewModel _selectedItem;
        private List<ItemViewModel> _offer;
        private static ShopView _shopView;

        public static ShopView ShopView 
        { 
            set => _shopView = value;
        }

        public List<ItemViewModel> AllItems => _offer;
        public ItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ObservableCollection<ItemViewModel> Items { get; set; }

        public int PlayerMoney => _player.Money;

        public ChangeInventoryCategoryCommand<WeaponViewModel> ChangeToWeapons { get; }
        public ChangeInventoryCategoryCommand<ItemViewModel> ChangeToAll { get; }
        public ChangeInventoryCategoryCommand<ArmorViewModel> ChangeToArmors { get; }
        public ChangeInventoryCategoryCommand<ShieldViewModel> ChangeToShields { get; }
        public ChangeInventoryCategoryCommand<RingViewModel> ChangeToRings { get; }
        public ChangeInventoryCategoryCommand<UpgradeMaterialViewModel> ChangeToUpgradeMaterials { get; }
        public ChangeInventoryCategoryCommand<ConsumableViewModel> ChangeToConsumables { get; }
        public BuyItemCommand BuyItemCommand => new BuyItemCommand(this);

        public ShopViewModel(NavigationService navigationService, Player player, Shop shop) : base(navigationService, player)
        {
            _shop = shop;
            _offer = new List<ItemViewModel>();

            var armorViewModels = _shop.Offer.Where(item => item is Armor)
                .Select(item => new ArmorViewModel(item as Armor)).ToList();
            _offer.AddRange(armorViewModels);

            var weaponViewModels = _shop.Offer.Where(item => item is Weapon).
                Select(item => new WeaponViewModel(item as Weapon)).ToList();
            _offer.AddRange(weaponViewModels);

            var ringViewModels = _shop.Offer.Where(item => item is Ring)
                .Select(item => new RingViewModel(item as Ring)).ToList();
            _offer.AddRange(ringViewModels);

            var shieldViewModels = _shop.Offer.Where(item => item is Shield)
                .Select(item => new ShieldViewModel(item as Shield)).ToList();
            _offer.AddRange(shieldViewModels);

            var upgradeViewModels = _shop.Offer.Where(item => item is UpgradeMaterial)
                .Select(item => new UpgradeMaterialViewModel(item as UpgradeMaterial)).ToList();
            _offer.AddRange(upgradeViewModels);

            var consumableViewModels = _shop.Offer.Where(item => item is Consumable)
                .Select(item => new ConsumableViewModel(item as Consumable)).ToList();
            _offer.AddRange(consumableViewModels);

            Items = new ObservableCollection<ItemViewModel>();
            _offer.ForEach(item => Items.Add(item));
            _selectedItem = Items.FirstOrDefault();

            ChangeToWeapons = new ChangeInventoryCategoryCommand<WeaponViewModel>(this);
            ChangeToAll = new ChangeInventoryCategoryCommand<ItemViewModel>(this);
            ChangeToArmors = new ChangeInventoryCategoryCommand<ArmorViewModel>(this);
            ChangeToShields = new ChangeInventoryCategoryCommand<ShieldViewModel>(this);
            ChangeToRings = new ChangeInventoryCategoryCommand<RingViewModel>(this);
            ChangeToUpgradeMaterials = new ChangeInventoryCategoryCommand<UpgradeMaterialViewModel>(this);
            ChangeToConsumables = new ChangeInventoryCategoryCommand<ConsumableViewModel>(this);
        }

        public bool EnoughMoney() => _player.Money >= _selectedItem.Price;

        public void Buy() 
        { 
            _shop.BuyItem(SelectedItem.Item, _player);
            Items.Remove(SelectedItem);
            AllItems.Remove(SelectedItem);
            SelectedItem = Items.FirstOrDefault();
            OnPropertyChanged(nameof(PlayerMoney));
            OnPropertyChanged(nameof(AllItems));
        }

        public void SetDataColumns(Type type) => _shopView.SetDataColumns(type);
    }
}
