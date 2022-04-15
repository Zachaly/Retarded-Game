using Retarded_Game.BasicStructures.Statistics;
using Retarded_Game.BasicStructures;
using Retarded_Game.BasicStructures.Enums;
using System.Collections.Generic;

namespace Retarded_Game.Fighters.Players
{
    public class Spell
    {
        public delegate void Usage(Player player, Fighter target);
        event Usage OnUsage;
        public double ManaCost { get; }
        public Damage Damage { get; }

        public StatRequirements StatRequirements { get; }
        public string Name { get; }

        public double FaithScaling { get; }
        public double IntelligenceScaling { get; }
        public List<ActionTag> ActionTags { get; }

        private Player Player;
        

        public Spell(string name, double manaCost, StatRequirements statRequirements, Damage damage,
            double faithScaling, double intelligenceScaling,List<ActionTag> actionTags, Usage specialUsage)
        {
            Name = name;
            ManaCost = manaCost;
            Damage = damage;
            StatRequirements = statRequirements;
            OnUsage += specialUsage;
            FaithScaling = faithScaling;
            IntelligenceScaling = intelligenceScaling;
            ActionTags = actionTags;

            OnUsage += (player, enemy) =>
            {
                Damage damage = Damage*(1+(player.Statistics.BaseStats.Faith * FaithScaling));
                damage *= 1+(player.Statistics.BaseStats.Intelligence * IntelligenceScaling);
                
                enemy.TakeDamage(damage);
            };
        }

        public void Use(Fighter fighter, out bool used)
        {
            used = false;

            if (Player.Statistics.BaseStats.CurrentMana < ManaCost)
                return;

            Player.Statistics.BaseStats.CurrentMana -= ManaCost;
            used = true;
            OnUsage(Player, fighter);
        }

        public void Learn(Player player)
            => Player = player;
    }
}
