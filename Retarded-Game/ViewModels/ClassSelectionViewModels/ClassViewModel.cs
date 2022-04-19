using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retarded_Game.Models.Fighters.Players;
using Retarded_Game.ViewModels.ItemViewModels;
using Retarded_Game.ViewModels.StatisticsViewModels;

namespace Retarded_Game.ViewModels.ClassSelectionViewModels
{
    internal class ClassViewModel : BaseViewModel
    {
        private readonly PlayerStartingClass _playerClass;

        public string ClassName => _playerClass.ClassName;
        public EquipmentViewModel Equipment { get; }
        public StatisticsViewModel Statistics { get; }

        public ClassViewModel(PlayerStartingClass playerClass)
        { 
            _playerClass = playerClass;
            Equipment = new EquipmentViewModel(playerClass.Equipment);
            Statistics = new StatisticsViewModel(playerClass.Statistics);
        }
    }
}
