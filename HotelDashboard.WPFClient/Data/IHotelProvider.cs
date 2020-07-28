using HotelDashboard.Data.Models.Enums;
using System.Collections.Generic;

namespace HotelDashboard.WPFClient.Data
{
    /// <summary>
    /// Интерфейс для работы с источником данных гостиницы
    /// </summary>
    public interface IHotelProvider
    {
        /// <summary>
        /// Получить список всех корпусов гостиницы
        /// </summary>
        /// <typeparam name="TCorpsDto">Тип DTO корпуса</typeparam>
        IEnumerable<TCorpsDto> GetAllCorps<TCorpsDto>();
        /// <summary>
        /// Получить все этажи корпуса
        /// </summary>
        /// <typeparam name="TFloorDto">Тип DTO этажа</typeparam>
        /// <param name="corpsId">ID корпуса</param>
        IEnumerable<TFloorDto> GetCorpsFloors<TFloorDto>(int corpsId);
        /// <summary>
        /// Получить все комнаты на этаже
        /// </summary>
        /// <typeparam name="TRoomDto">Тип DTO комнаты</typeparam>
        /// <param name="floorId">ID этажа</param>
        IEnumerable<TRoomDto> GetFloorRooms<TRoomDto>(int floorId);
        /// <summary>
        /// Получить информацию о комнате
        /// </summary>
        /// <typeparam name="TRoomInfoDto">Тип DTO информации о комнате</typeparam>
        /// <param name="roomId">ID комнаты</param>
        TRoomInfoDto GetRoomInfo<TRoomInfoDto>(int roomId);
        /// <summary>
        /// Резервирование комнаты
        /// </summary>
        /// <typeparam name="TReservationData">Тип данных для резервирования</typeparam>
        /// <param name="roomId">ID комнаты</param>
        /// <param name="reservationData">Данные для резервирования</param>
        void ReserveRoom<TReservationData>(int roomId, TReservationData reservationData);
        /// <summary>
        /// Освободить комнату
        /// </summary>
        /// <param name="roomId"></param>
        void FreeRoom(int roomId);
        /// <summary>
        /// Заселить комнату
        /// </summary>
        /// <typeparam name="TPopulationData">Тип данных с информацией о клиентах</typeparam>
        /// <param name="roomId">ID комнаты</param>
        /// <param name="populationData">Данные клиентов</param>
        void PopulateRoom<TPopulationData>(int roomId, TPopulationData populationData);
        /// <summary>
        /// Получить статистику по корпусу
        /// </summary>
        /// <typeparam name="TStatisticsDto">Тип DTO статистики</typeparam>
        /// <param name="corpsId">ID корпуса</param>
        TStatisticsDto GetCorpsStatistics<TStatisticsDto>(int corpsId);
        /// <summary>
        /// Получить статистику по этажу
        /// </summary>
        /// <typeparam name="TStatisticsDto">Тип DTO статистики</typeparam>
        /// <param name="floorId">ID этажа</param>
        TStatisticsDto GetFloorStatistics<TStatisticsDto>(int floorId);
        /// <summary>
        /// Получить статистику по типу комнаты
        /// </summary>
        /// <typeparam name="TStatisticsDto">Тип DTO статистики</typeparam>
        /// <param name="floorId">ID этажа</param>
        /// <param name="roomType">Тип комнаты</param>
        TStatisticsDto GetRoomTypeStatistics<TStatisticsDto>(int floorId, RoomType roomType);
    }
}
