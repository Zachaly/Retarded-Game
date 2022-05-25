using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.ViewModels.SpellViewModels
{
    public class SpellBookViewModel : BaseViewModel
    {
        private readonly Spellbook _spellbook;
        private readonly ObservableCollection<SpellViewModel> _equippedSpells;
        private readonly ObservableCollection<SpellViewModel> _allSpells;
        private SpellViewModel _selectedSpell;

        public ObservableCollection<SpellViewModel> EquippedSpells => _equippedSpells;
        public ObservableCollection<SpellViewModel> AllSpells => _allSpells;
        public string SpellCount => $"Current number of spells: {_equippedSpells.Count}/{_spellbook.PossibleSpells}";
        public SpellViewModel SelectedSpell 
        {
            get => _selectedSpell;
            set
            {
                _selectedSpell = value;
                OnPropertyChanged(nameof(SelectedSpell));
            }
        }

        public SpellBookViewModel(Spellbook spellbook)
        {
            _spellbook = spellbook;
            _equippedSpells = new ObservableCollection<SpellViewModel>();

            _allSpells = new ObservableCollection<SpellViewModel>();
            _spellbook.AllSpells.ForEach(spell => {
                var viewModel = new SpellViewModel(spell);
                _allSpells.Add(viewModel);
                if (_spellbook.EquippedSpells.Contains(spell))
                    _equippedSpells.Add(viewModel);
            });
            SelectedSpell = _allSpells.Count > 0 ? _allSpells.First() : new SpellViewModel(new Spell());
        }

        public void EquipSpell()
        {
            _spellbook.EquipSpell(SelectedSpell.Spell);
            EquippedSpells.Add(SelectedSpell);
            OnPropertyChanged(nameof(SpellCount));
        }

        public bool CanEquip(Player player)
            => SelectedSpell.Spell.StatRequirements.AreFulliled(player.Statistics.BaseStats)
               && EquippedSpells.Count() < _spellbook.PossibleSpells
               && !EquippedSpells.Contains(SelectedSpell);

        public void UnequipSpell()
        {
            _spellbook.UnEquipSpell(SelectedSpell.Spell);
            EquippedSpells.Remove(SelectedSpell);
            OnPropertyChanged(nameof(SpellCount));
        }
    }
}
