using HotelDashboard.WPFClient.Data;

namespace HotelDashboard.WPFClient.Models
{
    /// <summary>
    /// Модель для работы со статистикой гостинницы
    /// </summary>
    class StatisticsModel
    {
        public StatisticsModel()
        {
            _hotelProvider = new HotelWebApiProvider();
        }

        private IHotelProvider _hotelProvider;
    }
}
