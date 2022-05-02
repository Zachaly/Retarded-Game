using Retarded_Game.Models.Items;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    /// <summary>
    /// ViewModel describing an item held either in right or left hand
    /// </summary>
    public abstract class HandsItemViewModel : EquipmentPartViewModel
    {
        private EquipmentPart _handItem => _item as EquipmentPart;

        public int MinStrenght => _handItem.StatRequirements.MinimalStrenght;
        public int MinDexterity => _handItem.StatRequirements.MinimalDexterity;
        public int MinFaith => _handItem.StatRequirements.MinimalFaith;
        public int MinIntelligence => _handItem.StatRequirements.MinimalIntelligence;

        public HandsItemViewModel(Weapon weapon) : base(weapon) { }
        public HandsItemViewModel(Shield shield) : base(shield) { }
    }
}
