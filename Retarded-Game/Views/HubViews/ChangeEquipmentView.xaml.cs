using Retarded_Game.Services;
using Retarded_Game.ViewModels.HubViewModels;
using System;
using System.Windows.Controls;

namespace Retarded_Game.Views.HubViews
{
    /// <summary>
    /// View where player can manage his equipped items
    /// </summary>
    public partial class ChangeEquipmentView : UserControl
    {
        private ItemDataColumnsSetter columnsSetter;
        public ChangeEquipmentView()
        {
            InitializeComponent();
            columnsSetter = new ItemDataColumnsSetter(ItemColumns, Resources);
            ChangeEquipmentViewModel.View = this;
        }

        public void SetColumnsToType(Type type) => columnsSetter.SetColumnsToType(type);
    }
}
