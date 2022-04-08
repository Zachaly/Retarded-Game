using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game
{
    internal abstract class Fighter
    {
        protected int _level;
        public Statistics Statistics { get; set; }
        public int Level 
        { 
            get => _level;
        }
        public string Name { get; }

        public Fighter(string name, int level)
        {
            Name = name;
            _level = level;
        }
    }
}
