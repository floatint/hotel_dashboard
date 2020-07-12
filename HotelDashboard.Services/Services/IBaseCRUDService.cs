using HotelDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Services.Services
{
    interface IBaseCRUDService<TEntity> : ICRUDService<TEntity, int> where TEntity : BaseModel
    {
    }
}
