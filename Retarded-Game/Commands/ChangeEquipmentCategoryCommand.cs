using Retarded_Game.Models.BasicStructures.Enums;
using Retarded_Game.ViewModels.HubViewModels;
using Retarded_Game.ViewModels.ItemViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Commands
{
    public class ChangeEquipmentCategoryCommand<T> : CommandBase
    {
        private ChangeEquipmentViewModel _viewModel;
        private ArmorType _armorType = 0;

        public ChangeEquipmentCategoryCommand(ChangeEquipmentViewModel viewModel) => _viewModel = viewModel;

        public ChangeEquipmentCategoryCommand(ChangeEquipmentViewModel viewModel, ArmorType armorType) : this(viewModel)
            => _armorType = armorType;

        public override void Execute(object? parameter)
        {
            if (typeof(T) == typeof(RingViewModel))
                _viewModel.SetRing(Int32.Parse((string)parameter));
            else
                _viewModel.SetItemsOfType(typeof(T), _armorType);
        }
    }
}
