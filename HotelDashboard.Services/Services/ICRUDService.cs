using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelDashboard.Data.Models;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Базовый интерфейс CRUD операций для сервиса
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TId">Тип ID сущности</typeparam>
    public interface ICRUDService<TEntity, TId> where TEntity : BaseModel
    {
        Task<TDtoEntity> GetByIdAsync<TDtoEntity>(TId id);
        Task<IEnumerable<TDtoEntity>> GetAllAsync<TDtoEntity>();
        Task<TId> AddAsync<TDtoEntity>(TDtoEntity entity);
        Task UpdateAsync<TDtoEntity>(TDtoEntity entity);
        Task DeleteAsync(TId id);

    }
}
