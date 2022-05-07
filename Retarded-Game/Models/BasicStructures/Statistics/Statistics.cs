using System.Collections.Generic;

namespace Retarded_Game.Models.BasicStructures.Statistics
{
    /// <summary>
    /// Class containing Defences and BaseStats of the character
    /// </summary>
    public sealed class Statistics
    {
        public Defences Defences { get; set; }
        public BaseStats BaseStats { get; set; }

        /// <summary>
        /// Sets statistics as part of equipment part
        /// </summary>
        public bool IsEquipment 
        { 
            set => BaseStats.IsEquipment = value;
        }

        List<Statistics> _statChanges = new List<Statistics>();
        
        public Statistics(double maxHP, double maxMana, double defence, double magicResistance,
            double fireResistance, double frostResistance, double lightningResistance,
            int vitality, int focus, int strenght, int dexterity, int intelligence, int faith, int critical, int dodge)
        {
            BaseStats = new BaseStats(maxHP, maxMana, vitality, focus, strenght, dexterity, intelligence, faith, critical, dodge);
            Defences = new Defences(defence, magicResistance, fireResistance, frostResistance, lightningResistance);
        }

        public Statistics() 
        {
            BaseStats = new BaseStats();
            Defences = new Defences();
        }

        public Statistics(BaseStats baseStats, Defences defences)
        {
            BaseStats = baseStats;
            Defences = defences;
        }

        public Statistics(BaseStats baseStats) : this(baseStats, new Defences()) { }

        public Statistics(Defences defences) : this(new BaseStats(), defences) { }

        public Statistics Copy() => new Statistics(BaseStats, Defences);
        

        /// <summary>
        /// Modifies statistics by given parameter
        /// </summary>
        public void ChangeBy(Statistics change)
        {
            BaseStats.ApplyChange(change.BaseStats);
            Defences.ApplyChange(change.Defences);

            _statChanges.Add(change);
        }

        /// <summary>
        /// Reverses changes done by given parameter
        /// </summary>
        public void ReverseChange(Statistics change)
        {
            if (!_statChanges.Contains(change))
                return;

            BaseStats.ReverseChange(change.BaseStats);
            Defences.ReverseChange(change.Defences);

            _statChanges.Remove(change);
        }
    }
}
