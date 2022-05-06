﻿using System;
using System.Linq;
using Retarded_Game.ViewModels.HubViewModels;

namespace Retarded_Game.Commands
{
    public class ChangeInventoryCategoryCommand<T> : CommandBase
    {
        private readonly InventoryManagementViewModel _inventory;
        public ChangeInventoryCategoryCommand(InventoryManagementViewModel inventory)
        {
            _inventory = inventory;
        }

        public override void Execute(object? parameter)
        {
            _inventory.Items.Clear();
            var desiredItems = _inventory.AllItems.Where(item => item is T).ToList();
            desiredItems.ForEach(item => _inventory.Items.Add(item));
            _inventory.SetDataColumns(typeof(T));
        }
    }
}