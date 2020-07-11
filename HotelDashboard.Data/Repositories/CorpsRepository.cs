using HotelDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HotelDashboard.Data.Repositories
{
    public class CorpsRepository : Repository<Corps>
    {
        public CorpsRepository(DbContext context)
            : base(context)
        { }
    }
}
