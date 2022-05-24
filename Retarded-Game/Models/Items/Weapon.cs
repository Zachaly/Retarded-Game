using Retarded_Game.Models.BasicStructures.Statistics;
using Retarded_Game.Models.BasicStructures;
using Retarded_Game.Models.BasicStructures.Enums;
using Retarded_Game.Models.Fighters.Players;

namespace Retarded_Game.Models.Items
{
    public sealed class Weapon : EquipmentPart
    {
        private readonly WeaponUpgrade _weaponUpgrade;

        /// <summary>
        /// Default weapon
        /// </summary>
        public static Weapon EmptyHand =>
            new Weapon("Empty Hand", "", 0, StatRequirements.None, new Statistics(),
                Damage.None, 0, 0, 0, 0, WeaponType.OneHanded);

        public Damage BaseDamage { get; set; }
        public double StrenghtScaling { get; set; }
        public double DexterityScaling { get; set; }
        public double IntelligenceScaling { get; set; }
        public double FaithScaling { get; set; } 
        public WeaponType WeaponType { get; }
        public int UpgradeLevel => _weaponUpgrade.UpgradeLevel;
        public int UpgradeCost => _weaponUpgrade.Cost;
        public int MaterialForNextUpgrade => _weaponUpgrade.MaterialForNextLevel;
        public int RequiredMaterialLevel => _weaponUpgrade.RequiredMaterialLevel;

        public Weapon(string name, string description, int price,
            StatRequirements statRequirements,
            Statistics statsChange, Damage baseDamage,
            double strengthScaling, double dexterityScaling,
            double intelligenceScaling, double faithScaling, WeaponType type)
            : base(name, description, price, statRequirements, statsChange)
        {
            _weaponUpgrade = new WeaponUpgrade(this);
            BaseDamage = baseDamage;

            StrenghtScaling = strengthScaling;
            DexterityScaling = dexterityScaling;
            IntelligenceScaling = intelligenceScaling;
            FaithScaling = faithScaling;

            WeaponType = type;
        }

        public Damage CalculateDamage(BaseStats playerStats)
        {
            Damage damage = new Damage();

            damage.BaseDamage = BaseDamage.BaseDamage + (StrenghtScaling * playerStats.Strenght * BaseDamage.BaseDamage) 
                + (DexterityScaling * playerStats.Dexterity * BaseDamage.BaseDamage);

            damage.FireDamage = BaseDamage.FireDamage + (FaithScaling * playerStats.Faith * BaseDamage.FireDamage);
            damage.FrostDamage = BaseDamage.FrostDamage + (IntelligenceScaling * playerStats.Intelligence * BaseDamage.FrostDamage);
            damage.LightningDamage = BaseDamage.LightningDamage + (FaithScaling * playerStats.Faith * BaseDamage.LightningDamage);

            return damage;
        }

        public void Upgrade(Player player) => _weaponUpgrade.Upgrade(player);

        public override Weapon Clone() 
            => new Weapon(Name, Description, Price, StatRequirements, StatsChange.Copy(),
            BaseDamage, StrenghtScaling, DexterityScaling, IntelligenceScaling, FaithScaling, WeaponType);
    }
}
