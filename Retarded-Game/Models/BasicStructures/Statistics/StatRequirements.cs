namespace Retarded_Game.Models.BasicStructures.Statistics
{
    /// <summary>
    /// Class describing minimal statistics to use an item
    /// </summary>
    public sealed class StatRequirements
    {
        public static StatRequirements None { get; } = new StatRequirements(0, 0, 0, 0);

        public int MinimalStrenght { get; } = 0;
        public int MinimalDexterity { get; } = 0;
        public int MinimalFaith { get; } = 0;
        public int MinimalIntelligence { get; } = 0;

        public StatRequirements(int strenght, int dexterity, int faith, int intelligence)
        {
            MinimalStrenght = strenght;
            MinimalDexterity = dexterity;
            MinimalFaith = faith;
            MinimalIntelligence = intelligence;
        }

        public StatRequirements(int faith, int intelligence)
        {
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
