using Retarded_Game.ViewModels;
using Retarded_Game.Services;
using Retarded_Game.ViewModels.ClassSelectionViewModels;

namespace Retarded_Game.Commands
{
    /// <summary>
    /// Used to confirm name in character creation
    /// </summary>
    public class ConfirmNameCommand : NavigateCommand
    {
        EnterNameViewModel _nameViewModel;

        public ConfirmNameCommand(EnterNameViewModel nameViewModel, NavigationService navigationService) 
            : base(navigationService, new ClassSelectionViewModel(navigationService))
        { 
            _nameViewModel = nameViewModel;
            _nameViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(_nameViewModel.CharacterName))
                    OnCanExecuteChanged();
            };
        }

        /// <summary>
        /// Character name has to be between 5 and 20 characters
        /// </summary>
        public override bool CanExecute(object? parameter)
        {
            return _nameViewModel.CharacterName.Length >= 5  
                && _nameViewModel.CharacterName.Length <= 20 
                && base.CanExecute(parameter);
        }

        /// <summary>
        /// Confirms name and navigates to class selection
        /// </summary>
        public override void Execute(object? parameter)
        {
            App.CharacterName = _nameViewModel.CharacterName;
            base.Execute(parameter);
        }
    }
}
