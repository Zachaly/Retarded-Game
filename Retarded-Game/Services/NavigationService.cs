using Retarded_Game.Stores;
using Retarded_Game.ViewModels;

namespace Retarded_Game.Services
{
    /// <summary>
    /// Navigates between viewmodel containing service to target viewmodel
    /// </summary>
    public class NavigationService
    {
        private NavigationStore _navigationStore;

        public NavigationService(NavigationStore navigationStore)
        { 
            _navigationStore = navigationStore; 
        }

        public void Navigate(BaseViewModel target)
        {
            _navigationStore.CurrentViewModel = target;
        }
    }
}
