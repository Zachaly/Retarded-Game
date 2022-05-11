using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Retarded_Game.Services;
using Retarded_Game.ViewModels.HubViewModels;

namespace Retarded_Game.Views.HubViews
{
    /// <summary>
    /// Logika interakcji dla klasy ShopView.xaml
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
