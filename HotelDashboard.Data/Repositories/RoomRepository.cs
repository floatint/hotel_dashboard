using HotelDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelDashboard.Data.Repositories
{
    /// <summary>
    /// Репозиторий комнат. Просто перегрузка выборки
    /// </summary>
    class RoomRepository : Repository<Room>
    {
        public RoomRepository(DbContext context)
            : base(context)
        { }

        public override async Task<Room> GetByIdAsync(object id)
        {
            return await dbSet.Include(x => x.Status).ThenInclude(x => x.Clients).AsNoTracking().FirstOrDefaultAsync(x => x.Id == (int)id);
        }

        public override async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Status).ThenInclude(x => x.Clients).AsNoTracking().ToListAsync();
        }
    }
}
