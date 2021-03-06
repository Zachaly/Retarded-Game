using System.Collections.Generic;
using Retarded_Game.Models.BasicStructures.Enums;
using System.Linq;

namespace Retarded_Game.Models.Fighters.Players
{
    /// <summary>
    /// Class containing informations about learned spells, maximal number of them etc.
    /// </summary>
    public sealed class Spellbook
    {
        private int _baseNumberOfSpells = 0;
        private Player? _player;

        public List<Spell> AllSpells { get; }
        public List<Spell> EquippedSpells { get; }

        public int PossibleSpells 
        { 
            get => _baseNumberOfSpells + (_player.Statistics.BaseStats.Faith/5 + _player.Statistics.BaseStats.Intelligence/5); 
        }

        public Spellbook()
        {
            AllSpells = new List<Spell>();
            EquippedSpells = new List<Spell>();
        }

        public void LearnSpell(Spell spell)
        {
            bool canLearn = !AllSpells.Contains(spell) || spell.StatRequirements.AreFulliled(_player.Statistics.BaseStats);
            if (!canLearn)
                return;
            
            AllSpells.Add(spell);
        }

        public void EquipSpell(Spell spell)
        {
            bool canEquip = !EquippedSpells.Contains(spell) && EquippedSpells.Count < PossibleSpells;
            if (!canEquip)
                return;

            EquippedSpells.Add(spell);
        }

        public void UnEquipSpell(Spell spell)
        {
            EquippedSpells.Remove(spell);
        }

        public void SetStartingSpells(Player player, List<Spell> spells, int possibleNumberOfSpells)
        {
            _player = player;

            if(spells.Count < possibleNumberOfSpells)
                _baseNumberOfSpells = possibleNumberOfSpells;
            else
                _baseNumberOfSpells = spells.Count;

            foreach(Spell spell in spells)
            {
                LearnSpell(spell);
                EquipSpell(spell);
            }
        }

        public IEnumerable<Spell> GetSpellsByTag(ActionTag tag)
            => AllSpells.Where(x => x.ActionTags.Contains(tag));
    }
}
