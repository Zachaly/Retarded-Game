using System.Collections.Generic;
using Retarded_Game.BasicStructures;
using Retarded_Game.BasicStructures.Statistics;

namespace Retarded_Game
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

        }
    }
}
