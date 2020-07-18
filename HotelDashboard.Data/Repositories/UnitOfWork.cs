using HotelDashboard.Data.Models;

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
                return (ICRUDRepository<TEntity>)new CorpsRepository(context);
            if (typeof(TEntity) == typeof(Floor))
                return (ICRUDRepository<TEntity>)new FloorRepository(context);
            if (typeof(TEntity) == typeof(Room))
                return (ICRUDRepository<TEntity>)new RoomRepository(context);
            if (typeof(TEntity) == typeof(Client))
                return (ICRUDRepository<TEntity>)new ClientRepository(context);
            if (typeof(TEntity) == typeof(RoomStatus))
                return (ICRUDRepository<TEntity>)new RoomStatusRepository(context);
            return base.GetRepositoryInstance<TEntity>();
        }
    }
}
