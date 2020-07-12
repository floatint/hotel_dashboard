using HotelDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
        Task<IEnumerable<TDtoEntity>> GetAllRooms<TDtoEntity>(int floorId);
    }
}
