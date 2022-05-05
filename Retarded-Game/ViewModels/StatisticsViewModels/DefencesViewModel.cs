using Retarded_Game.Models.BasicStructures.Statistics;

namespace Retarded_Game.ViewModels.StatisticsViewModels
{
    public class DefencesViewModel : BaseViewModel
    {
        private readonly Defences _defences;

        public string BaseDefence => $"{_defences.Defence * 100}%";
        public string FireResistance => $"{_defences.FireResistance * 100}%";
        public string MagicResistance => $"{_defences.MagicResistance * 100}%";
        public string FrostResistance => $"{_defences.FrostResistance * 100}%";
        public string LightningResistance => $"{_defences.LightningResistance * 100}%";

        public DefencesViewModel(Defences defences)
        {
            _defences = defences;
        }
    }
}
