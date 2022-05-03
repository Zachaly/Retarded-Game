using Retarded_Game.Services;
using Retarded_Game.ViewModels.HubViewModels;
using Retarded_Game.ViewModels.ClassSelectionViewModels;

namespace Retarded_Game.Commands
{
    public class CreateCharacterCommand : NavigateCommand
    {
        private readonly ClassSelectionViewModel _classSelectionViewModel;

        /// <summary>
        /// Creates character based on picked class and goes to the hub
        /// </summary>
        public CreateCharacterCommand(NavigationService navigationService, ClassSelectionViewModel classSelection) 
            : base(navigationService, new HubViewModel(navigationService))
                => _classSelectionViewModel = classSelection;

        public override void Execute(object? parameter)
        {
            App.CreatePlayer(_classSelectionViewModel.SelectedClass.PlayerClass);
            base.Execute(parameter);
        }
    }
}
