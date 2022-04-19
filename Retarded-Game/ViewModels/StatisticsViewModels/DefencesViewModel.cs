using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retarded_Game.Models.BasicStructures.Statistics;

namespace Retarded_Game.ViewModels.StatisticsViewModels
{
    public class DefencesViewModel : BaseViewModel
    {
        private readonly Defences _defences;

        public double BaseDefence => _defences.Defence;
        public double FireResistance => _defences.FireResistance;
        public double MagicResistance => _defences.MagicResistance;
        public double FrostResistance => _defences.FrostResistance;
        public double LightingResistance => _defences.LightningResistance;

        public DefencesViewModel(Defences defences)
        {
            _defences = defences;
        }
    }
}
