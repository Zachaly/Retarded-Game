using Retarded_Game.Models.Items;
using Retarded_Game.ViewModels.StatisticsViewModels;
using Retarded_Game.Models.BasicStructures.Statistics;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public class EquipmentPartViewModel : ItemViewModel
    {
        private readonly StatRequirements _statRequirements;
        public StatisticsViewModel Statistics { get; }
        public BaseStatsViewModel BaseStats { get; }
        public DefencesViewModel Defences { get; }

        public int RequiredStrenght => _statRequirements.MinimalStrenght;
        public int RequiredDexterity => _statRequirements.MinimalDexterity;
        public int RequiredFaith => _statRequirements.MinimalFaith;
        public int RequiredIntelligence => _statRequirements.MinimalIntelligence;
        
        public EquipmentPartViewModel(EquipmentPart equipmentPart) : base(equipmentPart) 
        { 
            Statistics = new StatisticsViewModel(equipmentPart.StatsChange);
            _statRequirements = equipmentPart.StatRequirements;
            BaseStats = new BaseStatsViewModel(equipmentPart.StatsChange.BaseStats);
            Defences = new DefencesViewModel(equipmentPart.StatsChange.Defences);
        }

        public bool AreStatsFullfilled(BaseStats baseStats) => _statRequirements.AreFulliled(baseStats);
        public void Equip(Player player) => player.Equipment.Equip(_item as EquipmentPart);
        public void UnEquip(Player player) => player.Equipment.Unequip(_item as EquipmentPart);
    }
}
