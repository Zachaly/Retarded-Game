using Retarded_Game.Commands;
using Retarded_Game.Services;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public abstract class HubSubCategoryBase : BaseViewModel
    {
        private readonly NavigationService _navigationService;
        protected readonly Player _player;

        public NavigateCommand ReturnToHubCommand => new NavigateCommand(_navigationService,
            new HubViewModel(_navigationService, _player));

        public HubSubCategoryBase(NavigationService navigationService, Player player)
        {
            _navigationService = navigationService;
            _player = player;
        }
    }
}
