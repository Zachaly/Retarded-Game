using Retarded_Game.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public class ConsumableViewModel : ItemViewModel
    {
        public ConsumableViewModel(Consumable item) : base(item)
        {
        }
    }
}
