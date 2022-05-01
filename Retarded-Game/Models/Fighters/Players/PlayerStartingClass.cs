using Retarded_Game.Models.BasicStructures.Statistics;

namespace Retarded_Game.Models.Fighters.Players
{
    public class PlayerStartingClass
    {
        public string ClassName { get; }
        public Statistics Statistics { get; }
        public Equipment Equipment { get; }
        public Spellbook Spells { get; }
        public int StartingLevel { get; }
        public int BaseNumberOfSpells { get; }

        public PlayerStartingClass(string name, int startingLevel, Statistics startingStats, Equipment startingEquipment,
            Spellbook startingSpells, int baseSpells)
        {
            ClassName = name;
            Statistics = startingStats;
            Equipment = startingEquipment;
            Spells = startingSpells;
            StartingLevel = startingLevel;
            BaseNumberOfSpells = baseSpells;
        }
    }
}
