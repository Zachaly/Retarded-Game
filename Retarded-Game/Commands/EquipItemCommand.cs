using Retarded_Game.ViewModels.HubViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Commands
{
    public class EquipItemCommand : CommandBase
    {
        private ChangeEquipmentViewModel _viewModel;

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
