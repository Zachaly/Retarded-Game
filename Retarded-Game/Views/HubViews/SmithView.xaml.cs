using Retarded_Game.Services;
using Retarded_Game.ViewModels.ItemViewModels;
using System.Windows.Controls;

namespace Retarded_Game.Views.HubViews
{
    /// <summary>
    /// View containing smith
    /// </summary>
    public partial class SmithView : UserControl
    {
        public SmithView()
        {
            InitializeComponent();
            // View contains two list, one with weapons, second with upgrade materials,
            // columns in them are made with with already existing commands
            ItemDataColumnsSetter columnsSetter = new ItemDataColumnsSetter(WeaponColumns, Resources);
            columnsSetter.SetColumnsToType(typeof(WeaponViewModel));
            columnsSetter = new ItemDataColumnsSetter(MaterialColumns, Resources);
            columnsSetter.SetColumnsToType(typeof(UpgradeMaterialViewModel));
        }
    }
}
