using Retarded_Game.Models.Items;
using Retarded_Game.ViewModels.StatisticsViewModels;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public class EquipmentPartViewModel : ItemViewModel
    {
        public StatisticsViewModel Statistics { get; }
        
        public EquipmentPartViewModel(EquipmentPart equipmentPart) : base(equipmentPart) 
        { 
            Statistics = new StatisticsViewModel(equipmentPart.StatsChange);
        }
    }
}
