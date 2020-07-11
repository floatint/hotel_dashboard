using HotelDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Data.Repositories
{
    class FloorRepository : Repository<Floor>
    {
        public FloorRepository(DbContext context)
            : base(context)
        { }
    }
}
