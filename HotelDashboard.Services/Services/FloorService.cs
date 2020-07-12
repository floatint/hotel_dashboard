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
    /// Реализация сервиса этажей
    /// </summary>
    public class FloorService : BaseService<Floor>, IFloorService
    {
        public FloorService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            _floorRepository = unitOfWork.GetRepository<Floor>();
        }

        public async Task<IEnumerable<TDtoEntity>> GetAllRooms<TDtoEntity>(int floorId)
        {
            //пытаемся получить объект этажа
            Floor floor = await _floorRepository.GetByIdAsync(floorId);
            if (floor == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return mapper.Map<IEnumerable<TDtoEntity>>(floor.Rooms);
            }
        }

        private ICRUDRepository<Floor> _floorRepository;
    }
}
