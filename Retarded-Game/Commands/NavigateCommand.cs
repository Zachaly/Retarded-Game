using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Retarded_Game.ViewModels;
using Retarded_Game.Services;

namespace Retarded_Game.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
            => _navigationService = navigationService;

        public override void Execute(object? parameter) => _navigationService.Navigate();
    }
}
