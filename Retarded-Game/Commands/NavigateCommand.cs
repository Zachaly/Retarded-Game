using Retarded_Game.Services;
using Retarded_Game.ViewModels;

namespace Retarded_Game.Commands
{
    /// <summary>
    /// Simple navigation command
    /// </summary>
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private readonly BaseViewModel _target;

        public NavigateCommand(NavigationService navigationService, BaseViewModel target)
        { 
            _navigationService = navigationService;
            _target = target;
        }

        public override void Execute(object? parameter) => _navigationService.Navigate(_target);
    }
}
