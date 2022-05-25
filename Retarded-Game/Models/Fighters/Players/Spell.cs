using Retarded_Game.Models.BasicStructures.Statistics;
using Retarded_Game.Models.BasicStructures;
using Retarded_Game.Models.BasicStructures.Enums;
using System.Collections.Generic;

namespace Retarded_Game.Models.Fighters.Players
{
    /// <summary>
    /// Class describing a spell
    /// </summary>
    public class Spell
    {
        public delegate void Usage(Player player, Fighter target);
        event Usage _onUsage; // special effects that spell has, e.g. status effects 
        public double ManaCost { get; } = 0;
        public Damage Damage { get; } = new Damage();

        public StatRequirements StatRequirements { get; } = new StatRequirements(0,0);
        public string Name { get; } = "";
        public string Description { get; } = "";

        public double FaithScaling { get; } = 0;
        public double IntelligenceScaling { get; } = 0;
        public List<ActionTag> ActionTags { get; } = new List<ActionTag>();

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

        public Spell() { }

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
