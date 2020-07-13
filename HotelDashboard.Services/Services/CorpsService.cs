using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _floorRepository = unitOfWork.GetRepository<Floor>();
        }

        public async Task<IEnumerable<TDtoEntity>> GetAllFloorsAsync<TDtoEntity>(int corpsId)
        {
            Corps corps = await repository.GetByIdAsync(corpsId);
            if (corps == null)
            {
                throw new ArgumentOutOfRangeException();
            } else
            {
                return mapper.Map<IEnumerable<TDtoEntity>>(corps.Floors);
            }
        }

        public async Task<TDtoEntity> AddFloorAsync<TDtoEntity>(int corpsId)
        {
            Corps corps = await repository.GetByIdAsync(corpsId);
            if (corps == null)
            {
                throw new ArgumentOutOfRangeException();
            } else
            {
                Floor floor = new Floor();
                corps.Floors.Add(floor);
                repository.Update(corps);
                await unitOfWork.SaveAsync();
                return mapper.Map<TDtoEntity>(floor);

            }
        }

        public async Task DeleteFloorAsync(int corpsId, int floorId)
        {
            Corps corps = await repository.GetByIdAsync(corpsId);
            if (corps == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                Floor floor = corps.Floors.FirstOrDefault(x => x.Id == floorId);
                if (floor == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _floorRepository.Delete(floor);
                    await unitOfWork.SaveAsync();
                }
            }
        }

        private ICRUDRepository<Floor> _floorRepository;
    }
}
