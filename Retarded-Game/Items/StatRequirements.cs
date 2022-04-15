using Retarded_Game.BasicStructures.Statistics;

namespace Retarded_Game.Items
{
    internal class StatRequirements
    {
        public static StatRequirements None { get; } = new StatRequirements(0, 0, 0, 0);

        public int MinimalStrenght { get; }
        public int MinimalDexterity { get; }
        public int MinimalFaith { get; }
        public int MinimalIntelligence { get; }

        public StatRequirements(int strenght, int dexterity, int faith, int intelligence)
        {
            MinimalStrenght = strenght;
            MinimalDexterity = dexterity;
            MinimalFaith = faith;
            MinimalIntelligence = intelligence;
        }

        public bool AreFulliled(BaseStats stats)
            => MinimalStrenght <= stats.Strenght 
                && MinimalDexterity <= stats.Dexterity
                && MinimalFaith <= stats.Faith
                && MinimalIntelligence <= stats.Intelligence;
    }
}
