using Retarded_Game.Models.BasicStructures.Statistics;

namespace Retarded_Game.ViewModels.StatisticsViewModels
{
    public class StatisticsViewModel : BaseViewModel
    {
        private readonly Statistics _statistics;

        public BaseStatsViewModel BaseStatsModel { get; }
        public DefencesViewModel DefencesModel { get; }

        public StatisticsViewModel(Statistics statistics)
        {
            _statistics = statistics;
            BaseStatsModel = new BaseStatsViewModel(statistics.BaseStats);
            DefencesModel = new DefencesViewModel(statistics.Defences);
        }
    }
}
