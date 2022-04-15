using Retarded_Game.BasicStructures.Statistics;

namespace Retarded_Game.Fighters.Players
{
    public class Player : Fighter
    {
        int _experience = 0;
        int Experience 
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

        public Player(string name) : base(name, 1)
        {
            Statistics = new Statistics(new BaseStats(30, 5, 1, 1, 1, 1, 0, 10));
            Equipment = new Equipment(this);
            Equipment.SetStartingEquipment();
            Spellbook = new Spellbook(this);
        }

        void LevelUp()
        {
            _level++;
        }
    }
}
