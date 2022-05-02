using Retarded_Game.Models.Items;

namespace Retarded_Game.ViewModels.ItemViewModels
{
    public class WeaponViewModel : HandsItemViewModel
    {
        private Weapon _weapon => _item as Weapon;

        public string Type => _weapon.WeaponType.ToString();

        public double BaseDamage => _weapon.BaseDamage.BaseDamage;
        public double MagicDamage => _weapon.BaseDamage.MagicDamage;
        public double FireDamage => _weapon.BaseDamage.FireDamage;
        public double FrostDamage => _weapon.BaseDamage.FrostDamage;
        public double LightningDamage => _weapon.BaseDamage.LightningDamage;

        public string StrengthScaling => WeaponScaling.ScalingToString(_weapon.StrenghtScaling);
        public string DexterityScaling => WeaponScaling.ScalingToString(_weapon.DexterityScaling);
        public string FaithScaling => WeaponScaling.ScalingToString(_weapon.FaithScaling);
        public string IntelligenceScaling => WeaponScaling.ScalingToString(_weapon.IntelligenceScaling);
        
        public WeaponViewModel(Weapon weapon) : base(weapon) { }
    }
}
