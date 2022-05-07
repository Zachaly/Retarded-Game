using Retarded_Game.Commands;
using Retarded_Game.Services;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class HubViewModel : BaseViewModel
    {
        private readonly Player _player;
        private readonly NavigationService _navigationService;

        public NavigateCommand GoToExploration => new NavigateCommand(_navigationService,
            new ExplorationViewModel(_navigationService, _player));
        public NavigateCommand GoToCharacterInfo => new NavigateCommand(_navigationService,
            new CharacterInfoViewModel(_navigationService, _player));
        public NavigateCommand GoToInventoryManagement => new NavigateCommand(_navigationService,
            new InventoryManagementViewModel(_navigationService, _player));
        public NavigateCommand GoToSpellManagement => new NavigateCommand(_navigationService,
            new SpellManagementViewModel(_navigationService, _player));
        public NavigateCommand GoToShop => new NavigateCommand(_navigationService,
            new ShopViewModel(_navigationService, _player));
        public NavigateCommand GoToSmith => new NavigateCommand(_navigationService,
            new SmithViewModel(_navigationService, _player));

        public HubViewModel(NavigationService navigationService, Player player)
        {
            _player = player;
            _navigationService = navigationService;
        }
    }
}
