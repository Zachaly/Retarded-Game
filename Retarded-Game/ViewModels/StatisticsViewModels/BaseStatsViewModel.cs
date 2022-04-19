﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retarded_Game.Models.BasicStructures.Statistics;

namespace Retarded_Game.ViewModels.StatisticsViewModels
{
    public class BaseStatsViewModel : BaseViewModel
    {
        private readonly BaseStats _baseStats;

        public string CurrentHPStatus => $"{_baseStats.CurrentHP}/{_baseStats.MaxHP}";
        public string CurrentManaStatus => $"{_baseStats.CurrentMana}/{_baseStats.MaxMana}";
        public int Vitality => _baseStats.Vitality;
        public int Focus => _baseStats.Focus;
        public int Strength => _baseStats.Strenght;
        public int Dexterity => _baseStats.Dexterity;
        public int Faith => _baseStats.Faith;
        public int Intelligence => _baseStats.Intelligence;

        public BaseStatsViewModel(BaseStats baseStats)
        {
            _baseStats = baseStats;
        }
    }
}
