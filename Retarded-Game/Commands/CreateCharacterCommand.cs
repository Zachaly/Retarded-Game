using Retarded_Game.Services;
using Retarded_Game.ViewModels.HubViewModels;
using Retarded_Game.ViewModels.ClassSelectionViewModels;

namespace Retarded_Game.Commands
{
    public class CreateCharacterCommand : NavigateCommand
    {
        private readonly ClassSelectionViewModel _classSelection;
        /// <summary>
        /// Creates character based on picked class and goes to the hub
        /// </summary>
        public CreateCharacterCommand(NavigationService navigationService, ClassSelectionViewModel classSelection)
            : base(navigationService, new HubViewModel(navigationService, classSelection.SelectedClass.PlayerClass)) 
            => _classSelection = classSelection;

        public override void Execute(object? parameter)
        {
            _target = new HubViewModel(_navigationService, _classSelection.SelectedClass.PlayerClass);
            base.Execute(parameter);
        }
    }
}
