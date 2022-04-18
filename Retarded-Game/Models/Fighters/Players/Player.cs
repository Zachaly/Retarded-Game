using Retarded_Game.Models.BasicStructures.Statistics;

namespace Retarded_Game.Models.Fighters.Players
{
    public class Player : Fighter
    {
        int _experience = 0;
        public int Experience 
        {
            get => _experience;
            set
            {
                if (value > 1000)
                {
                    _experience = value - ((value % 1000) * 1000);
                    for (int i = 0; i < value % 1000; i++)
                        LevelUp();
                }
                else
                    _experience = value;
            } 
        }

        public Equipment Equipment { get; }
        public Spellbook Spellbook { get; }

        public Player(string name, PlayerStartingClass startingClass) : base(name, 1)
        {
            Statistics = startingClass.Statistics;
            Equipment = startingClass.Equipment;
            Spellbook = startingClass.Spells;
        }

        void LevelUp()
        {
            _level++;
        }
    }
}
