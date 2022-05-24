using Retarded_Game.ViewModels.HubViewModels;

namespace Retarded_Game.Commands
{
    /// <summary>
    /// Command used to unequip spell
    /// </summary>
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
