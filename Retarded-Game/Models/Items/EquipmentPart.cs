using Retarded_Game.Models.BasicStructures.Statistics;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.Models.Items
{
    /// <summary>
    /// Part of equipment
    /// </summary>
    public abstract class EquipmentPart : Item
    {
        public StatRequirements StatRequirements { get; }
        public Statistics StatsChange { get; }

        public EquipmentPart(string name, string description, int price, StatRequirements statRequirements, Statistics statsChange) : base(name, description, price)
        {
           StatRequirements = statRequirements;
           StatsChange = statsChange;
           StatsChange.IsEquipment = true;
        }

        public virtual void Equip(Player player, out bool areStatsCorrect)
        {
            BaseStats playerBaseStats = player.Statistics.BaseStats;

            areStatsCorrect = StatRequirements.AreFulliled(playerBaseStats);
            if (!areStatsCorrect)
                return;

            player.Statistics.ChangeBy(StatsChange);
            areStatsCorrect = true;
        }

        public virtual void UnEquip(Player player) 
        {
            player.Statistics.ReverseChange(StatsChange);
        }
    }
}
