using Retarded_Game.Commands;
using Retarded_Game.Services;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class HubViewModel : BaseViewModel
    {
        public NavigateCommand GoToExploration { get; }
        public NavigateCommand GoToCharacterInfo { get; }
        public NavigateCommand GoToInventoryManagement { get; }
        public NavigateCommand GoToSpellManagement { get; }
        public NavigateCommand GoToShop { get; }

        public HubViewModel(NavigationService navigationService)
        {
            GoToExploration = new NavigateCommand(navigationService, new ExplorationViewModel());
            GoToCharacterInfo = new NavigateCommand(navigationService, new CharacterInfoViewModel());
            GoToInventoryManagement = new NavigateCommand(navigationService, new InventoryManagementViewModel());
            GoToSpellManagement = new NavigateCommand(navigationService, new SpellManagementViewModel());
            GoToShop = new NavigateCommand(navigationService, new ShopViewModel());
        }
    }
}
