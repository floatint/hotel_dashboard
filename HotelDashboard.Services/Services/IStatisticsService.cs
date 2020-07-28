using HotelDashboard.Data.Models.Enums;
using HotelDashboard.Services.DtoModels;
using System.Threading.Tasks;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Сервис статистики
    /// </summary>
    public interface IStatisticsService
    {
        /// <summary>
        /// Получить статистику по корпусу
        /// </summary>
        /// <param name="corpsId">ID корпуса</param>
        Task<StatisticsInfoDto> GetCorpsStatisticsAsync(int corpsId);
        /// <summary>
        /// Получить статистику по этажу
        /// </summary>
        /// <param name="floorId">ID этажа</param>
        Task<StatisticsInfoDto> GetFloorStatisticsAsync(int floorId);
        /// <summary>
        /// Получить статистику по этажу по типу комнаты
        /// </summary>
        /// <param name="roomType">Тип комнаты</param>
        /// <param name="floorId">ID этажа</param>
        Task<StatisticsInfoDto> GetRoomTypeStatisticsAsync(int floorId, RoomType roomType);
    }
}
