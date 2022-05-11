﻿using System;
using System.Windows;
using System.Windows.Controls;
using Retarded_Game.ViewModels.HubViewModels;
using Retarded_Game.ViewModels.ItemViewModels;
using Retarded_Game.Services;

namespace Retarded_Game.Views.HubViews
{
    /// <summary>
    /// Logika interakcji dla klasy InventoryManagementView.xaml
    /// </summary>
    public partial class InventoryManagementView : UserControl
    {
        private readonly ItemDataColumnsSetter _columnsSetter;
        public InventoryManagementView()
        {
            InitializeComponent();
            InventoryManagementViewModel.InventoryManagementView = this;
            _columnsSetter = new ItemDataColumnsSetter(ItemColumns, Resources);
            _columnsSetter.SetStandardColumns();
        }
        public void SetColumnsToType(Type type) => _columnsSetter.SetColumnsToType(type);    
    }
}
