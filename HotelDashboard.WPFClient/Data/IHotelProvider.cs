using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelDashboard.WPFClient.Data
{
    /// <summary>
    /// Интерфейс для работы с источником данных гостинницы
    /// </summary>
    public interface IHotelProvider
    {
        /// <summary>
        /// Получить список всех корпусов гостинницы
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
    }
}
