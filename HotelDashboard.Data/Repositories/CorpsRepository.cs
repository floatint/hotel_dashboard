using HotelDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelDashboard.Data.Repositories
{
    /// <summary>
    /// Репозиторий корпусов. Просто перегрузка выборки
    /// </summary>
    public class CorpsRepository : Repository<Corps>
    {
        public CorpsRepository(DbContext context)
            : base(context)
        { }

        public override async Task<Corps> GetByIdAsync(object id)
        {
            return await dbSet.Include(x => x.Floors).AsNoTracking().FirstOrDefaultAsync(x => x.Id == (int)id);
        }

        public override async Task<IEnumerable<Corps>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Floors).AsNoTracking().ToListAsync();
        }
    }
}
