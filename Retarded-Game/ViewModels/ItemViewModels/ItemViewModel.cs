using Retarded_Game.Models.Items;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        protected readonly Item _item;

        public string Name => _item.Name;
        public string Description => _item.Description;
        public int Price => _item.Price;
        public Item Item => _item;
        public ItemViewModel(Item item) => _item = item;
    }
}
