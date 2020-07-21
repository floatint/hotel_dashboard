using LiveCharts;
using System;

namespace HotelDashboard.WPFClient.ViewModels
{
    /// <summary>
    /// ViewModel статистики гостинницы
    /// </summary>
    class StatisticsViewModel : BaseViewModel
    {
        public Func<ChartPoint, string> PointLabel { get; set; }

        public StatisticsViewModel()
        {
            PointLabel = chartPoint =>
               string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
        }

    }
}
