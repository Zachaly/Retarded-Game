namespace Retarded_Game.Models.Fighters.Players
{
    /// <summary>
    /// Player character
    /// </summary>
    public class Player : Fighter
    {
        private int _experience = 0;
        private int _experienceForNextLevel = 0;
        public int Experience 
        {
            get => _experience;
            set
            {
                if (value > _experienceForNextLevel)
                {
                    _experience = value - ((value % _experienceForNextLevel) * _experienceForNextLevel);
                    for (int i = 0; i < value % _experienceForNextLevel; i++)
                        LevelUp();
                }
                else
                    _experience = value;
            } 
        }
        public int ExperienceForNextLevel => _experienceForNextLevel;
        public int Money { get; set; } = 0;
        public Equipment Equipment { get; }
        public Spellbook Spellbook { get; }

        public Player(string name, PlayerStartingClass startingClass) : base(name, startingClass.StartingLevel)
        {
            Statistics = startingClass.Statistics;
            Equipment = startingClass.Equipment;
            Equipment.SetPlayer(this);
            Spellbook = startingClass.Spells;
            Spellbook.SetStartingSpells(this, Spellbook.EquippedSpells, startingClass.BaseNumberOfSpells);
            _experienceForNextLevel = 1000 + (Level * 150);
        }

        private void LevelUp()
        {
            _level++;
            _experienceForNextLevel += Level * 150;
        }
    }
}
