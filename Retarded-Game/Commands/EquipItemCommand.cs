using Retarded_Game.ViewModels.HubViewModels;

namespace Retarded_Game.Commands
{
    /// <summary>
    /// Command used to equip selected item in equipment change view
    /// </summary>
    public class EquipItemCommand : CommandBase
    {
        private readonly ChangeEquipmentViewModel _viewModel;

        public EquipItemCommand(ChangeEquipmentViewModel viewModel) 
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(_viewModel.SelectedItem))
                    OnCanExecuteChanged();
            };
        }

        public override bool CanExecute(object? parameter) => base.CanExecute(parameter) && _viewModel.CanEquip();
        
        public override void Execute(object? parameter) => _viewModel.Equip();
    }
}
