using Retarded_Game.ViewModels.HubViewModels;
using Retarded_Game.ViewModels.SpellViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Commands
{
    public class EquipSpellCommand : CommandBase
    {
        private readonly SpellManagementViewModel _spellbook;

        public EquipSpellCommand(SpellManagementViewModel spellBookViewModel)
        {
            _spellbook = spellBookViewModel;
            _spellbook.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(_spellbook.SelectedSpell))
                {
                    OnCanExecuteChanged();
                }
            };
        }

        public override bool CanExecute(object? parameter)
            => base.CanExecute(parameter) && _spellbook.CanEquip();

        public override void Execute(object? parameter)
            => _spellbook.EquipSpell();
    }
}
