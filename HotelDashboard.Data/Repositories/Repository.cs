using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            dbSet = context.Set<TEntity>();
        }

        public virtual void Delete(TEntity entity)
        {
            //если сущность пришла из другого контекста
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }


        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        //данные
        protected internal DbContext context;
        protected DbSet<TEntity> dbSet;
    }
}
