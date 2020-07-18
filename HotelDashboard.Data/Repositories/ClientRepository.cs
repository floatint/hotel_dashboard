using HotelDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;

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
