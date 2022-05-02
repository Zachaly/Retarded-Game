using Retarded_Game.Services;

namespace Retarded_Game.Commands
{
    /// <summary>
    /// Simple navigation command
    /// </summary>
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
            => _navigationService = navigationService;

        public override void Execute(object? parameter) => _navigationService.Navigate();
    }
}
