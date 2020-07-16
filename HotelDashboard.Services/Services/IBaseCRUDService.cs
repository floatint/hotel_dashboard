using HotelDashboard.Data.Models;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Базовый интерфейс для CRUD сервиса, использующий int как ключ сущности
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, с которой работает сервис</typeparam>
    interface IBaseCRUDService<TEntity> : ICRUDService<TEntity, int> where TEntity : BaseModel
    {
    }
}
