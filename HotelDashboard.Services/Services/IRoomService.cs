﻿using HotelDashboard.Data.Models;
using System;
using System.Threading.Tasks;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Сервис комнат
    /// </summary>
    public interface IRoomService : ICRUDService<Room, int>
    {
        /// <summary>
        /// Зарезервировать комнату
        /// </summary>
        /// <param name="roomId">ID комнаты</param>
        /// <param name="reserveStart">Дата резервирования</param>
        /// <param name="reserveEnd">Дата окончания резервирования</param>
        Task ReserveRoomAsync(int roomId, DateTime reserveStart, DateTime reserveEnd);
        /// <summary>
        /// Заселить клиентов в комнату
        /// </summary>
        /// <typeparam name="TDtoEntity">Тип DTO сущности клиента</typeparam>
        /// <param name="roomId">ID комнаты</param>
        /// <param name="populationDto">Информация для заселения</param>
        Task PopulateRoomAsync<TDtoEntity>(int roomId, TDtoEntity populationDto);
        /// <summary>
        /// Освободить комнату
        /// </summary>
        /// <param name="roomId">ID комнаты</param>
        Task FreeRoom(int roomId);
        /// <summary>
        /// Получить детальную информацию о комнате
        /// </summary>
        /// <typeparam name="TDtoEntity">Тип DTO комнаты</typeparam>
        /// <param name="roomId">ID комнаты</param>
        Task<TDtoEntity> GetRoomInfoAsync<TDtoEntity>(int roomId);
    }
}
