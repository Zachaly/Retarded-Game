using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.ViewModels.SpellViewModels
{
    public class SpellBookViewModel : BaseViewModel
    {
        private readonly Spellbook _spellbook;
        private readonly ObservableCollection<SpellViewModel> _equippedSpells;
        private readonly ObservableCollection<SpellViewModel> _allSpells;
        private SpellViewModel _selectedSpell;

        public IEnumerable<SpellViewModel> EquippedSpells => _equippedSpells;
        public IEnumerable<SpellViewModel> AllSpells => _allSpells;
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
            _spellbook.EquippedSpells.ForEach(x => _equippedSpells.Add(new SpellViewModel(x)));

            _allSpells = new ObservableCollection<SpellViewModel>();
            _spellbook.AllSpells.ForEach(x => _allSpells.Add(new SpellViewModel(x)));
            SelectedSpell = _allSpells.First();
        }
    }
}
