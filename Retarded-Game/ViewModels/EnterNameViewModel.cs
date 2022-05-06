using System.Windows.Input;
using Retarded_Game.Commands;
using Retarded_Game.Services;
using Retarded_Game.Stores;

namespace Retarded_Game.ViewModels
{
    public class EnterNameViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        string _name = "";
        
        public string CharacterName 
        {
            get => _name;
            set
            {
                _name = value.TrimStart();
                OnPropertyChanged(nameof(CharacterName));
            } 
        }

        public ICommand ConfirmNameCommand => new ConfirmNameCommand(this, new NavigationService(_navigationStore));

        public EnterNameViewModel(NavigationStore navigationStore)
            => _navigationStore = navigationStore;
        
    }
}
