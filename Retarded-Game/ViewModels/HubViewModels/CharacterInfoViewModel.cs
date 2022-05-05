using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.ViewModels.ItemViewModels;
using Retarded_Game.ViewModels.SpellViewModels;
using Retarded_Game.ViewModels.StatisticsViewModels;
using System.Collections.ObjectModel;

namespace Retarded_Game.ViewModels.HubViewModels
{
    public class CharacterInfoViewModel : BaseViewModel
    {
        private readonly Player _player;

        public string CharacterName => _player.Name;
        public EquipmentViewModel Equipment => new EquipmentViewModel(_player.Equipment);
        public StatisticsViewModel Statistics => new StatisticsViewModel(_player.Statistics);
        public ObservableCollection<SpellViewModel> SpellNames { get; }
        public int Level => _player.Level;
        public string Experience => $"{_player.Experience}/{_player.ExperienceForNextLevel}";
        
        public CharacterInfoViewModel(Player player)
        {
            _player = player;
            SpellNames = new ObservableCollection<SpellViewModel>();
            
            _player.Spellbook.EquippedSpells.ForEach(spell => SpellNames.Add(new SpellViewModel(spell)));
        }
    }
}
