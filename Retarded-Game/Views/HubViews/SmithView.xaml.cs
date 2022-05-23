using Retarded_Game.Services;
using Retarded_Game.ViewModels.ItemViewModels;
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
    /// Logika interakcji dla klasy SmithView.xaml
    /// </summary>
    public partial class SmithView : UserControl
    {
        public SmithView()
        {
            InitializeComponent();
            ItemDataColumnsSetter columnsSetter = new ItemDataColumnsSetter(WeaponColumns, Resources);
            columnsSetter.SetColumnsToType(typeof(WeaponViewModel));
            columnsSetter = new ItemDataColumnsSetter(MaterialColumns, Resources);
            columnsSetter.SetColumnsToType(typeof(UpgradeMaterialViewModel));
        }
    }
}
