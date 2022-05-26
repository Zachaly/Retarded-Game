using Retarded_Game.ViewModels.HubViewModels;

namespace Retarded_Game.Commands
{
    /// <summary>
    /// Command used to unequip currently equipped item in equipment change view
    /// </summary>
    public class UnequipCommand : CommandBase
    {
        private readonly ChangeEquipmentViewModel _viewModel;

        public UnequipCommand(ChangeEquipmentViewModel viewModel) => _viewModel = viewModel;

        public override void Execute(object? parameter) => _viewModel.UnEquip();
    }
}
