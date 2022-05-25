using Retarded_Game.Services;
using Retarded_Game.ViewModels.HubViewModels;
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

namespace Retarded_Game.Views.HubViews
{
    /// <summary>
    /// Logika interakcji dla klasy ChangeEquipmentView.xaml
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
