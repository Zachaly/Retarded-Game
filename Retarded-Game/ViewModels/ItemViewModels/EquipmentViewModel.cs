using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public class EquipmentViewModel : BaseViewModel
    {
        private readonly Equipment _equipment;
        public EquipmentViewModel(Equipment equipment)
        {
            _equipment = equipment;
        }
    }
}
