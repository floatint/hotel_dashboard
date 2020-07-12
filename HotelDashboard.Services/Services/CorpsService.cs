using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Реализация сервиса корпусов
    /// </summary>
    public class CorpsService : BaseService<Corps>, ICorpsService
    {
        public CorpsService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            _corpsRepository = unitOfWork.GetRepository<Corps>();
        }

        public async Task<IEnumerable<TDtoEntity>> GetAllFloors<TDtoEntity>(int corpsId)
        {
            Corps corps = await _corpsRepository.GetByIdAsync(corpsId);
            if (corps == null)
            {
                throw new ArgumentOutOfRangeException();
            } else
            {
                return mapper.Map<IEnumerable<TDtoEntity>>(corps.Floors);
            }
        }

        private ICRUDRepository<Corps> _corpsRepository;
    }
}
