using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Services;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class ShopViewModel : HubSubCategoryBase
    {
        public ShopViewModel(NavigationService navigationService, Player player) : base(navigationService, player)
        {
        }
    }
}
