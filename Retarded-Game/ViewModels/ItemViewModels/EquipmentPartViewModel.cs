using Retarded_Game.Models.Items;
using Retarded_Game.ViewModels.StatisticsViewModels;
using Retarded_Game.Models.BasicStructures.Statistics;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public class EquipmentPartViewModel : ItemViewModel
    {
        private readonly StatRequirements _statRequirements;
        public StatisticsViewModel Statistics { get; }

        public int RequiredStrenght => _statRequirements.MinimalStrenght;
        public int RequiredDexterity => _statRequirements.MinimalDexterity;
        public int RequiredFaith => _statRequirements.MinimalFaith;
        public int RequiredIntelligence => _statRequirements.MinimalIntelligence;
        
        public EquipmentPartViewModel(EquipmentPart equipmentPart) : base(equipmentPart) 
        { 
            Statistics = new StatisticsViewModel(equipmentPart.StatsChange);
            _statRequirements = equipmentPart.StatRequirements;
        }
    }
}
