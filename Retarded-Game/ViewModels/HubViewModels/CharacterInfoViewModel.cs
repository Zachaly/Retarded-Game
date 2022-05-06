using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.ViewModels.ItemViewModels;
using Retarded_Game.ViewModels.SpellViewModels;
using Retarded_Game.ViewModels.StatisticsViewModels;
using System.Collections.ObjectModel;
using Retarded_Game.Commands;
using Retarded_Game.Services;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class CharacterInfoViewModel : HubSubCategoryBase
    {
        public string CharacterName => _player.Name;
        public EquipmentViewModel Equipment => new EquipmentViewModel(_player.Equipment);
        public StatisticsViewModel Statistics => new StatisticsViewModel(_player.Statistics);
        public ObservableCollection<SpellViewModel> SpellNames { get; }
        public int Level => _player.Level;
        public string Experience => $"{_player.Experience}/{_player.ExperienceForNextLevel}";
        
        public CharacterInfoViewModel(NavigationService navigationService, Player player) : base(navigationService, player)
        {
            SpellNames = new ObservableCollection<SpellViewModel>();
            _player.Spellbook.EquippedSpells.ForEach(spell => SpellNames.Add(new SpellViewModel(spell)));
        }
    }
}
