using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retarded_Game.BasicStructures.Statistics;
using Retarded_Game.BasicStructures;
using Retarded_Game.BasicStructures.Enums;
using Retarded_Game.Items;

namespace Retarded_Game.Fighters.Players
{
    public sealed class Spellbook
    {
        int _baseNumberOfSpells = 1;

        public List<Spell> AllSpells { get; }
        public List<Spell> EquippedSpells { get; }

        public int PossibleSpells 
        { 
            get => _baseNumberOfSpells + (Player.Statistics.BaseStats.Faith/5 + Player.Statistics.BaseStats.Intelligence/5); 
        }

        Player Player;

        public Spellbook(Player player)
        {
            AllSpells = new List<Spell>();
            EquippedSpells = new List<Spell>();
            Player = player;

            Spell basicHeal = new Spell("Minor Magic Heal", 0.5, new StatRequirements(1, 1), Damage.None,
                WeaponScaling.E, WeaponScaling.E, new List<ActionTag> { ActionTag.Healing, ActionTag.Spell },
                (player, target) => player.Statistics.BaseStats.CurrentHP += player.Statistics.BaseStats.MaxHP * 0.05);

            bool compatibilityBool;
            LearnSpell(basicHeal, out compatibilityBool);
            EquipSpell(basicHeal, out compatibilityBool);
        }

        public void LearnSpell(Spell spell, out bool canLearn)
        {
            canLearn = !AllSpells.Contains(spell) || spell.StatRequirements.AreFulliled(Player.Statistics.BaseStats);
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
    }
}
