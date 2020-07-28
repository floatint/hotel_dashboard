using HotelDashboard.Data.Models.Enums;
using HotelDashboard.Services.DtoModels;
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

        /// <summary>
        /// Получить статистику по корпусу
        /// </summary>
        /// <param name="corpsDto">DTO корпуса</param>
        public StatisticsInfoDto GetCorpsStatistics(CorpsDto corpsDto)
        {
            return _hotelProvider.GetCorpsStatistics<StatisticsInfoDto>(corpsDto.Id);
        }

        /// <summary>
        /// Получить статистику по этажу
        /// </summary>
        /// <param name="floorDto">DTO этажа</param>
        public StatisticsInfoDto GetFloorStatistics(FloorDto floorDto)
        {
            return _hotelProvider.GetFloorStatistics<StatisticsInfoDto>(floorDto.Id);
        }

        /// <summary>
        /// Получуть статистику по этажу по типу комнаты
        /// </summary>
        /// <param name="floorDto">DTO этажа</param>
        /// <param name="roomType">Тип комнаты</param>
        public StatisticsInfoDto GetRoomTypeStatistics(FloorDto floorDto, RoomType roomType)
        {
            return _hotelProvider.GetRoomTypeStatistics<StatisticsInfoDto>(floorDto.Id, roomType);
        }

        private IHotelProvider _hotelProvider;
    }
}
