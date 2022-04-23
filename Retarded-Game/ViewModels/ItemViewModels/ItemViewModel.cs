using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retarded_Game.Models.Items;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        protected Item _item;

        public string Name => _item.Name;
        public string Description => _item.Description;
        public int Price => _item.Price;

        public ItemViewModel(Item item) => _item = item;
    }
}
