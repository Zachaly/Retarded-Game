using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Services;
using Retarded_Game.Models.Items;
using System.Linq;
using Retarded_Game.Commands;
using Retarded_Game.Views.HubViews;
using System;

namespace Retarded_Game.ViewModels.HubViewModels
{
    /// <summary>
    /// Hub subcathegory allowing player to buy items
    /// </summary>
    public class ShopViewModel : ItemListViewModel
    {
        private readonly Shop _shop;
        private static ShopView _shopView;

        public static ShopView ShopView 
        { 
            set => _shopView = value;
        }

        public int PlayerMoney => _player.Money;

        public BuyItemCommand BuyItemCommand => new BuyItemCommand(this);

        public ShopViewModel(NavigationService navigationService, Player player, Shop shop) : base(navigationService, player)
        {
            _shop = shop;
            SetItemLists(_shop.Offer);
        }

        public bool EnoughMoney() => _player.Money >= SelectedItem.Price;

        public void Buy() 
        { 
            _shop.BuyItem(SelectedItem.Item, _player);
            AllItems.Remove(SelectedItem);
            Items.Remove(SelectedItem);
            SelectedItem = Items.FirstOrDefault();
            OnPropertyChanged(nameof(PlayerMoney));
        }

        public override void SetDataColumns(Type type) => _shopView.SetDataColumns(type);
    }
}
