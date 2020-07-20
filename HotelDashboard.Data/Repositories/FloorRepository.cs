using HotelDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelDashboard.Data.Repositories
{
    /// <summary>
    /// Репозиторий этажей. Просто перегрузка выборки
    /// </summary>
    class FloorRepository : Repository<Floor>
    {
        public FloorRepository(DbContext context)
            : base(context)
        { }

        public override async Task<Floor> GetByIdAsync(object id)
        {
            return await dbSet.Include(x => x.Rooms).ThenInclude(x => x.Status).ThenInclude(x => x.Clients).AsNoTracking().FirstOrDefaultAsync(x => x.Id == (int)id);
        }

        public override async Task<IEnumerable<Floor>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Rooms).ThenInclude(x => x.Status).ThenInclude(x => x.Clients).AsNoTracking().ToListAsync();
        }
    }
}
