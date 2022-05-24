using Retarded_Game.Models.Items;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public sealed class UpgradeMaterialViewModel : ItemViewModel
    {
        public int MaterialLevel { get; }
        public UpgradeMaterialViewModel(UpgradeMaterial item) : base(item)
            => MaterialLevel = item.MaterialLevel;
    }
}
