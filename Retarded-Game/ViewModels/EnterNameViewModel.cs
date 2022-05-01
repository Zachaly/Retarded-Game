using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Retarded_Game.Commands;
using Retarded_Game.Services;
using Retarded_Game.Stores;
using Retarded_Game.ViewModels.ClassSelectionViewModels;

namespace Retarded_Game.ViewModels
{
    public class EnterNameViewModel : BaseViewModel
    {
        string _name = "";
        public string CharacterName 
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(CharacterName));
            } 
        }

        public ICommand ConfirmNameCommand { get; }

        public EnterNameViewModel(NavigationStore navigationStore)
        {
            ConfirmNameCommand = new ConfirmNameCommand(this, new NavigationService(navigationStore, new ClassSelectionViewModel()));
        }
    }
}
