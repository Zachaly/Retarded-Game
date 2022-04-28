using Retarded_Game.Models.BasicStructures.Statistics;
using Retarded_Game.Models.BasicStructures;
using Retarded_Game.Models.BasicStructures.Enums;
using System.Collections.Generic;

namespace Retarded_Game.Models.Fighters.Players
{
    public class Spell
    {
        public delegate void Usage(Player player, Fighter target);
        event Usage _onUsage;
        public double ManaCost { get; }
        public Damage Damage { get; }

        public StatRequirements StatRequirements { get; }
        public string Name { get; }
        public string Description { get; }

        public double FaithScaling { get; }
        public double IntelligenceScaling { get; }
        public List<ActionTag> ActionTags { get; }

        private Player _player;
        

        public Spell(string name, string description, double manaCost, StatRequirements statRequirements, Damage damage,
            double faithScaling, double intelligenceScaling,List<ActionTag> actionTags, Usage specialUsage)
        {
            Name = name;
            Description = description;
            ManaCost = manaCost;
            Damage = damage;
            StatRequirements = statRequirements;
            _onUsage += specialUsage;
            FaithScaling = faithScaling;
            IntelligenceScaling = intelligenceScaling;
            ActionTags = actionTags;

            _onUsage += (player, enemy) =>
            {
                Damage damage = Damage*(1+(player.Statistics.BaseStats.Faith * FaithScaling));
                damage *= 1+(player.Statistics.BaseStats.Intelligence * IntelligenceScaling);
                
                enemy.TakeDamage(damage);
            };
        }

        public void Use(Fighter fighter, out bool used)
        {
            used = false;

            if (_player.Statistics.BaseStats.CurrentMana < ManaCost)
                return;

            _player.Statistics.BaseStats.CurrentMana -= ManaCost;
            used = true;
            _onUsage(_player, fighter);
        }

        public void Learn(Player player)
            => _player = player;
    }
}
