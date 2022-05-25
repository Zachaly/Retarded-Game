using Retarded_Game.Commands;
using Retarded_Game.Services;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.Items;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class HubViewModel : BaseViewModel
    {
        private readonly Player _player;
        private readonly NavigationService _navigationService;
        private readonly Shop _shop;

        public NavigateCommand GoToExploration => new NavigateCommand(_navigationService,
            new ExplorationViewModel(_navigationService, _player));
        public NavigateCommand GoToCharacterInfo => new NavigateCommand(_navigationService,
            new CharacterInfoViewModel(_navigationService, _player));
        public NavigateCommand GoToInventoryManagement => new NavigateCommand(_navigationService,
            new InventoryManagementViewModel(_navigationService, _player));
        public NavigateCommand GoToSpellManagement => new NavigateCommand(_navigationService,
            new SpellManagementViewModel(_navigationService, _player));
        public NavigateCommand GoToShop => new NavigateCommand(_navigationService,
            new ShopViewModel(_navigationService, _player, _shop));
        public NavigateCommand GoToSmith => new NavigateCommand(_navigationService,
            new SmithViewModel(_navigationService, _player));
        public NavigateCommand GoToEquipmentChange => new NavigateCommand(_navigationService,
            new ChangeEquipmentViewModel(_navigationService, _player));
        public CloseCommand CloseCommand => new CloseCommand();
        
        public HubViewModel(NavigationService navigationService, Player player)
        {
            _player = player;
            _navigationService = navigationService;
            _shop = new Shop();
            _shop.SetStandardOffer();
        }
    }
}
