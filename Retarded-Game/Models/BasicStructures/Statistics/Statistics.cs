using System.Collections.Generic;

namespace Retarded_Game.Models.BasicStructures.Statistics
{
    public sealed class Statistics
    {
        public Defences Defences { get; set; } = new Defences();
        public BaseStats BaseStats { get; set; } = new BaseStats();

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

        public Statistics(BaseStats baseStats) 
            => BaseStats = baseStats;

        public Statistics(Defences defences) 
            => Defences = defences;

        public Statistics Copy()
        {
            return new Statistics(BaseStats, Defences);
        }

        public void ChangeBy(Statistics change)
        {
            BaseStats.ApplyChange(change.BaseStats);
            Defences.ApplyChange(change.Defences);

            _statChanges.Add(change);
        }

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
