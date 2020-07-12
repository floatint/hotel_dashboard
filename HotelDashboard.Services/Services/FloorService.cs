using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Реализация сервиса этажей
    /// </summary>
    public class FloorService : BaseService<Floor>, IFloorService
    {
        public FloorService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }
    }
}
