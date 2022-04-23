using Retarded_Game.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.ViewModels.ItemViewModels
{
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
