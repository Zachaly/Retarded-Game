using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Services;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class ExplorationViewModel : HubSubCategoryBase
    {
        public ExplorationViewModel(NavigationService navigationService, Player player) : base(navigationService, player)
        {
        }
    }
}
