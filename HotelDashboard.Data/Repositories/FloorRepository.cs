using HotelDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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
            return await dbSet.Include(x => x.Rooms).AsNoTracking().FirstOrDefaultAsync(x => Equals(x.Id, id));
        }

        public override async Task<IEnumerable<Floor>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Rooms).AsNoTracking().ToListAsync();
        }
    }
}
