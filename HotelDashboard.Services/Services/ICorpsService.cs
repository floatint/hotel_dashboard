using HotelDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Интерфейс сервиса корпусов
    /// </summary>
    public interface ICorpsService : ICRUDService<Corps, int>
    {
        /// <summary>
        /// Получить список этажей корпуса
        /// </summary>
        /// <typeparam name="TDtoEntity">Тип выходной сущности</typeparam>
        /// <param name="corpsId">ID корпуса</param>
        Task<IEnumerable<TDtoEntity>> GetAllFloorsAsync<TDtoEntity>(int corpsId);
        /// <summary>
        /// Добавить этаж в корпус
        /// </summary>
        /// <typeparam name="TDtoEntity">Тип выходной сущности</typeparam>
        /// <param name="corpsId">ID корпуса</param>
        Task<TDtoEntity> AddFloorAsync<TDtoEntity>(int corpsId);
        /// <summary>
        /// Удалить этаж из корпуса
        /// </summary>
        /// <param name="corpsId">ID корпуса</param>
        /// <param name="floorId">ID этажа</param>
        Task DeleteFloorAsync(int corpsId, int floorId);
    }
}
