using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelDashboard.Data.Repositories
{
    /// <summary>
    /// Базовая реализация репозитория
    /// </summary>
    public class Repository<TEntity> : ICRUDRepository<TEntity> where TEntity : class
    {
        public Repository(DbContext context)
        {
            this.context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Delete(TEntity entity)
        {
            //если сущность пришла из другого контекста
            if (context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }


        public virtual Task<TEntity> GetByIdAsync(object id)
        {
            return _dbSet.FindAsync(id).AsTask();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        //данные
        protected internal DbContext context;
        private DbSet<TEntity> _dbSet;
    }
}
