using HotelDashboard.Data.Models;

namespace HotelDashboard.Services.Services
{
    interface IBaseCRUDService<TEntity> : ICRUDService<TEntity, int> where TEntity : BaseModel
    {
    }
}
