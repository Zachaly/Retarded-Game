using Retarded_Game.ViewModels.HubViewModels;

namespace Retarded_Game.Commands
{
    /// <summary>
    /// Command used to equip a spell
    /// </summary>
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
