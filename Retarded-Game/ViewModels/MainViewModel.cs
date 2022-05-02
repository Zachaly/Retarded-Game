using Retarded_Game.Stores;

namespace Retarded_Game.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        private readonly NavigationStore _navigationStore;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += 
                () => OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}
