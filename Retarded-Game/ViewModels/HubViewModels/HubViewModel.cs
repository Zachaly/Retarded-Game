using Retarded_Game.Commands;
using Retarded_Game.Services;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class HubViewModel : BaseViewModel
    {
        private readonly Player _player;
        private readonly NavigationService _navigationService;
        public NavigateCommand GoToExploration => new NavigateCommand(_navigationService, new ExplorationViewModel());
        public NavigateCommand GoToCharacterInfo => new NavigateCommand(_navigationService, new CharacterInfoViewModel(_player));
        public NavigateCommand GoToInventoryManagement => new NavigateCommand(_navigationService, new InventoryManagementViewModel());
        public NavigateCommand GoToSpellManagement => new NavigateCommand(_navigationService, new SpellManagementViewModel());
        public NavigateCommand GoToShop => new NavigateCommand(_navigationService, new ShopViewModel());

        public HubViewModel(NavigationService navigationService, PlayerStartingClass player)
        {
            _player = new Player(App.CharacterName, player);
            _navigationService = navigationService;
        }
    }
}
