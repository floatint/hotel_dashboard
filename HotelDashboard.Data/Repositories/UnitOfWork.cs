using HotelDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDashboard.Data.Repositories
{
    public class UnitOfWork : BaseUnitOfWork<HotelContext>
    {
        public UnitOfWork(HotelContext context)
            : base(context)
        {

        }

        // переопределяем создание инстансов репозиориев
        protected override ICRUDRepository<TEntity> GetRepositoryInstance<TEntity>()
        {
            if (typeof(TEntity) == typeof(Corps))
                return ((ICRUDRepository<TEntity>)new CorpsRepository(context));
            //if (typeof(TEntity) == typeof(Floor))
            //    return ((IRepository<TEntity>)new FloorRepository(_context));
            //if (typeof(TEntity) == typeof(Room))
            //    return ((IRepository<TEntity>)new RoomRepository(_context));
            return base.GetRepositoryInstance<TEntity>();
        }
    }
}
