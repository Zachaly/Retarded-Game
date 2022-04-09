using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Items
{
    internal abstract class EquipmentPart : Item
    {
        public int MinimalStrenght { get; }
        public int MinimalDexterity { get; }
        public int MinimalIntelligence { get; }
        public int MinimalFaith { get; }
        public Statistics StatsChange { get; }

        public EquipmentPart(string name, string description, int price, int minimalStrenght, int minimalDexterity,
            int minimalIntelligence, int minimalFaith, Statistics statsChange) : base(name, description, price)
        {
            MinimalStrenght = minimalStrenght;
            MinimalDexterity = minimalDexterity;
            MinimalIntelligence = minimalIntelligence;
            MinimalFaith = minimalFaith;
            StatsChange = statsChange;
        }

        public virtual void Equip(Player player, out bool areStatsCorrect)
        {
            if (player.Statistics.Strenght < MinimalStrenght
                || player.Statistics.Dexterity < MinimalDexterity
                || player.Statistics.Intelligence < MinimalIntelligence
                || player.Statistics.Faith < MinimalFaith)
            {
                areStatsCorrect = false;
                return;
            }

            player.Statistics.ChangeBy(StatsChange);
            areStatsCorrect = true;
        }

        public virtual void UnEquip(Player player) 
        {
            player.Statistics.ReverseChange(StatsChange);
        }
    }
}
