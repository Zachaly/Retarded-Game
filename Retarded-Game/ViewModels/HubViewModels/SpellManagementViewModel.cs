using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Services;
using Retarded_Game.ViewModels.SpellViewModels;
using Retarded_Game.Commands;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class SpellManagementViewModel : HubSubCategoryBase
    {
        public SpellBookViewModel SpellBook { get; }
        public SpellViewModel SelectedSpell => SpellBook.SelectedSpell;
        public EquipSpellCommand EquipSpellCommand => new EquipSpellCommand(this);
        public UnequipSpellCommand UnequipSpellCommand => new UnequipSpellCommand(this);

        public SpellManagementViewModel(NavigationService navigationService, Player player) : base(navigationService, player)
        {
            SpellBook = new SpellBookViewModel(player.Spellbook);
        }

        public void EquipSpell() => SpellBook.EquipSpell();
        public bool CanEquip()
            => SpellBook.CanEquip(_player);

        public void UnequipSpell() => SpellBook.UnequipSpell();
    }
}
