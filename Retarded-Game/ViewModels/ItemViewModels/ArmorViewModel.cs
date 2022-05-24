using Retarded_Game.Models.Items;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public sealed class ArmorViewModel : EquipmentPartViewModel
    {
        private  Armor _armor => _item as Armor;
        public string Type => _armor.ArmorType.ToString();

        public string BaseDefence => Statistics.DefencesModel.BaseDefence;
        public string FireResistance => Statistics.DefencesModel.FireResistance;
        public string FrostResistance => Statistics.DefencesModel.FrostResistance;
        public string MagicResistance => Statistics.DefencesModel.MagicResistance;
        public string LightningResistance => Statistics.DefencesModel.LightningResistance;

        public ArmorViewModel(Armor armor) : base(armor) { }
    }
}
