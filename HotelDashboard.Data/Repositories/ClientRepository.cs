using HotelDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelDashboard.Data.Repositories
{
    /// <summary>
    /// Репозиторий клиентов.
    /// </summary>
    class ClientRepository : Repository<Client>
    {
        public ClientRepository(DbContext context)
            : base(context)
        { }
    }
}
