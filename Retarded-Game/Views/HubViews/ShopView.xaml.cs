using System;
using System.Windows.Controls;
using Retarded_Game.Services;
using Retarded_Game.ViewModels.HubViewModels;

namespace Retarded_Game.Views.HubViews
{
    /// <summary>
    /// View containing shop
    /// </summary>
    public partial class ShopView : UserControl
    {
        private readonly ItemDataColumnsSetter _itemDataColumnsSetter;
        public ShopView()
        {
            InitializeComponent();
            ShopViewModel.ShopView = this;
            _itemDataColumnsSetter = new ItemDataColumnsSetter(ItemColumns, Resources);
            _itemDataColumnsSetter.SetStandardColumns();
        }

        public void SetDataColumns(Type type) => _itemDataColumnsSetter.SetColumnsToType(type);
    }
}
