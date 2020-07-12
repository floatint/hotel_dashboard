using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Реализация сервиса корпусов
    /// </summary>
    public class CorpsService : BaseService<Corps>, ICorpsService
    {
        public CorpsService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }
    }
}
