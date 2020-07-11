using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelDashboard.Data.Repositories
{
    /// <summary>
    /// Базовый интерфейс для репозиториев
    /// </summary>
    public interface ICRUDRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Получить асинхронно сущность по ID
        /// </summary>
        /// <param name="id">ID сущности</param>
        Task<TEntity> GetByIdAsync(object id);
        /// <summary>
        /// Вернуть все сущности из хранилища
        /// </summary>
        Task<IEnumerable<TEntity>> GetAllAsync();
        /// <summary>
        /// Добавить сущность в источник данных
        /// </summary>
        /// <param name="entity">Сущность для добавления</param>
        void Insert(TEntity entity);
        /// <summary>
        /// Обновить сущность в источнике данных
        /// </summary>
        /// <param name="entity">Обновленная сущность</param>
        void Update(TEntity entity);
        /// <summary>
        /// Удалить сущность из источника данных
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        void Delete(TEntity entity);
    }
}
