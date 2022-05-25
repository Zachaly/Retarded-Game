using Retarded_Game.ViewModels.HubViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Commands
{
    public class UnequipCommand : CommandBase
    {
        private ChangeEquipmentViewModel _viewModel;

        public UnequipCommand(ChangeEquipmentViewModel viewModel) => _viewModel = viewModel;

        public override void Execute(object? parameter) => _viewModel.UnEquip();
        
    }
}
