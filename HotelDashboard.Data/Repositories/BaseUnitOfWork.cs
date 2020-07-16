using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelDashboard.Data.Repositories
{
    /// <summary>
    /// Базовая реализация unit of work
    /// </summary>
    /// <typeparam name="TContext">Тип контекста данных</typeparam>
    public class BaseUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        public BaseUnitOfWork(TContext context)
        {
            this.context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public virtual ICRUDRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            object result;
            var type = typeof(TEntity);

            // попытка вытащить уже созданный репозиторий из кэша
            // если в кэше нет - создаем новый инстанс
            if (!_repositories.TryGetValue(type, out result))
            {
                result = GetRepositoryInstance<TEntity>();
                _repositories[type] = result;
            }

            return (ICRUDRepository<TEntity>)result;
        }

        /// <summary>
        /// Создание инстанса репозитория. Переопределяется в более частных реализациях.
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности репозитория</typeparam>
        protected virtual ICRUDRepository<TEntity> GetRepositoryInstance<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return context.SaveChangesAsync();
        }

        protected readonly TContext context;
        private Dictionary<Type, object> _repositories;
    }
}
