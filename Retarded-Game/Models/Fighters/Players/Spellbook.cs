using System.Collections.Generic;

namespace Retarded_Game.Models.Fighters.Players
{
    public sealed class Spellbook
    {
        int _baseNumberOfSpells = 0;

        public List<Spell> AllSpells { get; }
        public List<Spell> EquippedSpells { get; }

        public int PossibleSpells 
        { 
            get => _baseNumberOfSpells + (_player.Statistics.BaseStats.Faith/5 + _player.Statistics.BaseStats.Intelligence/5); 
        }

        Player _player;

        public Spellbook()
        {
            AllSpells = new List<Spell>();
            EquippedSpells = new List<Spell>();
        }

        public void LearnSpell(Spell spell, out bool canLearn)
        {
            canLearn = !AllSpells.Contains(spell) || spell.StatRequirements.AreFulliled(_player.Statistics.BaseStats);
            if (!canLearn)
                return;
            
            AllSpells.Add(spell);
        }

        public void EquipSpell(Spell spell, out bool canEquip)
        {
            canEquip = !EquippedSpells.Contains(spell) && EquippedSpells.Count < PossibleSpells;
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

            bool dummybool = true;
            foreach(Spell spell in spells)
            {
                LearnSpell(spell, out dummybool);
                EquipSpell(spell, out dummybool);
            }
        }
    }
}
