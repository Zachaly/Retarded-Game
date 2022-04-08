namespace Retarded_Game
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

        public Player(string name) : base(name, 1)
        {
            Statistics = new Statistics(30, 5, 0, 0, 0, 0, 0, 7, 7, 5, 5, 0, 25);
        }

        void LevelUp()
        {
            _level++;
        }
    }
}
