using System.Threading.Tasks;

namespace HotelDashboard.Data.Repositories
{
    /// <summary>
    /// Базовый интерфейс unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Получить инстанс репозитория
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности репозитория</typeparam>
        ICRUDRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        /// <summary>
        /// Сохранить контекст данных
        /// </summary>
        void Save();
        /// <summary>
        /// Сохранить контекст данных асинхронно
        /// </summary>
        Task SaveAsync();
    }
}
