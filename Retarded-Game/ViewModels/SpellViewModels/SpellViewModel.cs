using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.Models.Items;

namespace Retarded_Game.ViewModels.SpellViewModels
{
    public class SpellViewModel : BaseViewModel
    {
        private readonly Spell _spell;

        public string Name => _spell.Name;
        public string Description => _spell.Description;

        public double BaseDamage => _spell.Damage.BaseDamage;
        public double MagicDamage => _spell.Damage.MagicDamage;
        public double FireDamage => _spell.Damage.FireDamage;
        public double FrostDamage => _spell.Damage.FrostDamage;
        public double LightningDamage => _spell.Damage.LightningDamage;

        public string ManaCost => $"Mana Cost: {_spell.ManaCost}";
        public string FaithScaling => $"Faith: {WeaponScaling.ScalingToString(_spell.FaithScaling) }";
        public string IntelligenceScaling => $"Intelligence: {WeaponScaling.ScalingToString(_spell.IntelligenceScaling)}";
        public string MinimalFaith => $"Faith: {_spell.StatRequirements.MinimalFaith}";
        public string MinimalIntelligence => $"Intelligence: {_spell.StatRequirements.MinimalIntelligence}";

        public SpellViewModel(Spell spell) => _spell = spell;
    }
}
