using System.Windows.Input;
using Retarded_Game.Commands;
using Retarded_Game.Services;
using Retarded_Game.Stores;

namespace Retarded_Game.ViewModels
{
    public class StartingViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; }
        public ICommand CreateCharacterCommand { get; }

        public StartingViewModel(NavigationStore navigationStore)
        {
            CloseCommand = new CloseCommand();
            CreateCharacterCommand = new NavigateCommand(new NavigationService(navigationStore, new EnterNameViewModel(navigationStore)));
        }
    }
}
