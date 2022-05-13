using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Services;
using System;
using Retarded_Game.Views.HubViews;

namespace Retarded_Game.ViewModels.HubViewModels
{
    /// <summary>
    /// Hub subcathegory containing info about current inventory of the player
    /// </summary>
    public class InventoryManagementViewModel :  ItemListViewModel
    {
        private readonly Equipment _inventory;
        private static InventoryManagementView? _inventoryManagementView = null;

        public static InventoryManagementView InventoryManagementView
        {
            set => _inventoryManagementView = value;
        }

        public InventoryManagementViewModel(NavigationService navigationService, Player player) : base(navigationService, player)
        {
            _inventory = player.Equipment;
            SetItemLists(_inventory.AllItems);
        }

        public override void SetDataColumns(Type type) => _inventoryManagementView?.SetColumnsToType(type);
    }
}
