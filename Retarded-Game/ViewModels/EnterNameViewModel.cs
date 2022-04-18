using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Retarded_Game.Commands;

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

        public EnterNameViewModel()
        {
            ConfirmNameCommand = new ConfirmNameCommand(this);
        }
    }
}
