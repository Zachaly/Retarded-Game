using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retarded_Game.Items
{
    enum WeaponType
    {
        OneArmed,
        TwoArmed,
    }

    internal class Weapon : EquipmentPart
    {
        public double BaseDamage { get; set; }
        public double FireDamage { get; set; }
        public double FrostDamage { get; set; }
        public double LightningDamage { get; set; }

        public double StrenghtScaling { get; set; }
        public double DexterityScaling { get; set; }
        public double IntelligenceScaling { get; set; }
        public double FaithScaling { get; set; } 
        public WeaponType WeaponType { get;}

        public Weapon(string name, string description, int price,
            int minimalStrenght, int minimalDexterity, int minimalIntelligence, int minimalFaith,
            Statistics statsChange, double baseDamage, double fireDamage, double frostDamage, double lightningDamage,
            double strengthScaling, double dexterityScaling,
            double intelligenceScaling, double faithScaling, WeaponType type)
            : base(name, description, price, minimalStrenght, minimalDexterity, minimalIntelligence, minimalFaith, statsChange)
        {
            BaseDamage = baseDamage;
            FireDamage = fireDamage;
            FrostDamage = frostDamage;
            LightningDamage = lightningDamage;

            StrenghtScaling = strengthScaling;
            DexterityScaling = dexterityScaling;
            IntelligenceScaling = intelligenceScaling;
            FaithScaling = faithScaling;

            WeaponType = type;
        }

        public Damage CalculateDamage(Statistics playerStats)
        {
            Damage damage = new Damage();

            damage.BaseDamage = BaseDamage + (StrenghtScaling * playerStats.Strenght * BaseDamage) 
                + (DexterityScaling * playerStats.Dexterity * BaseDamage);

            damage.FireDamage = FireDamage + (FaithScaling * playerStats.Faith * FireDamage);
            damage.FrostDamage = FrostDamage + (IntelligenceScaling * playerStats.Intelligence * FrostDamage);
            damage.LighningDamage = LightningDamage + ((IntelligenceScaling * playerStats.Intelligence * LightningDamage)/2 +
                (FaithScaling * playerStats.Faith * LightningDamage)/2);

            return damage;
        }
    }
}
