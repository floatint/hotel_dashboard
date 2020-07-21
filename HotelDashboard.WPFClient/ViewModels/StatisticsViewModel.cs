using LiveCharts;
using System;

namespace HotelDashboard.WPFClient.ViewModels
{
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
