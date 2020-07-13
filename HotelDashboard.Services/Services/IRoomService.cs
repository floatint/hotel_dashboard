using HotelDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
        /// Заселить клиентов к комнату
        /// </summary>
        /// <typeparam name="TDtoEntity">Тип DTO сущности клиента</typeparam>
        /// <param name="clients">Заселяющиеся клиенты</param>
        Task PopulateRoomAsync<TDtoEntity>(int roomId, IEnumerable<TDtoEntity> clients);
        /// <summary>
        /// Освободить комнату
        /// </summary>
        /// <param name="roomId">ID комнаты</param>
        Task FreeRoom(int roomId);
    }
}
