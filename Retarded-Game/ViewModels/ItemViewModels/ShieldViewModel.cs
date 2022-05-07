using Retarded_Game.Models.Items;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public sealed class ShieldViewModel : HandsItemViewModel
    {
        private Shield _shield => _item as Shield;

        public string BlockChance => $"{_shield.BlockChance}%";
        public string BlockBaseDamage => $"{_shield.BlockBaseDamage * 100}%";
        public string BlockFireDamage => $"{_shield.BlockFireDamage * 100}%";
        public string BlockFrostDamage => $"{_shield.BlockFrostDamage * 100}%";
        public string BlockLightningDamage => $"{_shield.BlockLightningDamage * 100}%";
        public string BlockMagicDamage => $"{_shield.BlockMagicDamage * 100}%";

        public ShieldViewModel(Shield shield) : base(shield) { }
    }
}
