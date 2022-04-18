using System.Collections.Generic;
using Retarded_Game.Models.BasicStructures;
using Retarded_Game.Models.BasicStructures.Statistics;

namespace Retarded_Game.Models
{
    public abstract class Fighter
    {
        protected int _level;
        public Statistics Statistics { get; set; }
        public int Level 
        { 
            get => _level;
        }
        public string Name { get; }

        public List<StatusEffect> StatusEffects { get; }

        public Fighter(string name, int level)
        {
            Name = name;
            _level = level;
            StatusEffects = new List<StatusEffect>();
        }

        public void TakeDamage(Damage damage)
        {
            Statistics.BaseStats.CurrentHP -= damage.BaseDamage * (1 - Statistics.Defences.Defence);
            Statistics.BaseStats.CurrentHP -= damage.FireDamage * (1 - Statistics.Defences.FireResistance);
            Statistics.BaseStats.CurrentHP -= damage.FrostDamage * (1 - Statistics.Defences.FrostResistance);
            Statistics.BaseStats.CurrentHP -= damage.LightningDamage * (1 - Statistics.Defences.LightningResistance);
            Statistics.BaseStats.CurrentHP -= damage.MagicDamage * (1 - Statistics.Defences.MagicResistance);
        }
    }
}
