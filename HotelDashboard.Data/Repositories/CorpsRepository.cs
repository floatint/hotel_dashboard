using HotelDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

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
            return await dbSet.Include(x => x.Floors).AsNoTracking().FirstOrDefaultAsync(x => Equals(x.Id, id));
        }

        public override async Task<IEnumerable<Corps>> GetAllAsync()
        {
            return await dbSet.Include(x => x.Floors).AsNoTracking().ToListAsync();
        }
    }
}
