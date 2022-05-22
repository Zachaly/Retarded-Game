using Retarded_Game.ViewModels.HubViewModels;
using Retarded_Game.ViewModels.SpellViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Commands
{
    public class UnequipSpellCommand : CommandBase
    {
        private readonly SpellManagementViewModel _spellbook;

        public UnequipSpellCommand(SpellManagementViewModel spellBookViewModel)
        { 
            _spellbook = spellBookViewModel;
        }

        public override void Execute(object? parameter) => _spellbook.UnequipSpell();
    }
}
