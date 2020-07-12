using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Реализация сервиса комнат
    /// </summary>
    public class RoomService : BaseService<Room>, IRoomService
    {
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }
    }
}
