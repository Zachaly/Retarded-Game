using Retarded_Game.Models.BasicStructures.Enums;
using Retarded_Game.ViewModels.HubViewModels;
using Retarded_Game.ViewModels.ItemViewModels;
using System;

namespace Retarded_Game.Commands
{
    /// <summary>
    /// Change item category in equipment view
    /// </summary>
    /// <typeparam name="T">ViewModel of desired item type</typeparam>
    public class ChangeEquipmentCategoryCommand<T> : CommandBase
    {
        private readonly ChangeEquipmentViewModel _viewModel;
        private readonly ArmorType _armorType = 0;

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
