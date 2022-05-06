using Retarded_Game.Services;
using Retarded_Game.ViewModels.HubViewModels;
using Retarded_Game.ViewModels.ClassSelectionViewModels;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.Commands
{
    public class CreateCharacterCommand : CommandBase
    {
        private readonly ClassSelectionViewModel _classSelection;
        private readonly NavigationService _navigationService;
        /// <summary>
        /// Creates character based on picked class and goes to the hub
        /// </summary>
        public CreateCharacterCommand(NavigationService navigationService, ClassSelectionViewModel classSelection)
        { 
            _classSelection = classSelection;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
            => _navigationService.Navigate(new HubViewModel(_navigationService,
            new Player(App.CharacterName, _classSelection.SelectedClass.PlayerClass)));
    }
}
