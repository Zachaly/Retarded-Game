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
        private BaseViewModel _target;

        public NavigationService(NavigationStore navigationStore, BaseViewModel target)
        { 
            _navigationStore = navigationStore; 
            _target = target;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _target;
        }
    }
}
