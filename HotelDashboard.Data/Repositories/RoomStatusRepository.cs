using HotelDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelDashboard.Data.Repositories
{
    /// <summary>
    /// Репозиторий статусов комнат. Просто перегрузка выборки
    /// </summary>
    class RoomStatusRepository : Repository<RoomStatus>
    {
        public RoomStatusRepository(DbContext context)
            : base(context)
        { }

        public override async Task<RoomStatus> GetByIdAsync(object id)
        {
            return await dbSet
                .Include(x => x.Clients)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == (int)id);
        }

        public override async Task<IEnumerable<RoomStatus>> GetAllAsync()
        {
            return await dbSet
                .Include(x => x.Clients)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
