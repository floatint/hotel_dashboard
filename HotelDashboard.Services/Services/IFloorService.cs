using HotelDashboard.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Сервис этажей
    /// </summary>
    public interface IFloorService : ICRUDService<Floor, int>
    {
        /// <summary>
        /// Получить коллекцию комнат на заданном этаже
        /// </summary>
        /// <typeparam name="TDtoEntity">Тип выходной сущности</typeparam>
        /// <param name="floorId">ID этажа</param>
        Task<IEnumerable<TDtoEntity>> GetAllRoomsAsync<TDtoEntity>(int floorId);
        /// <summary>
        /// Добавить комнату на этаж
        /// </summary>
        /// <typeparam name="TOutDtoEntity">Тип выходной DTO сущности</typeparam>
        /// <typeparam name="TInDtoEntity">Тип входящей DTO сущности</typeparam>
        /// <param name="floorId">ID этажа</param>
        /// <param name="dtoRoom">DTO комнаты</param>
        Task<TOutDtoEntity> AddRoomAsync<TOutDtoEntity, TInDtoEntity>(int floorId, TInDtoEntity dtoRoom);
        /// <summary>
        /// Удалить комнату с этажа
        /// </summary>
        /// <param name="roomId">ID комнаты</param>
        Task DeleteRoomAsync(int roomId);
    }
}
