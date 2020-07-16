using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Data.Repositories;
using System;
using System.Collections.Generic;
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
            _roomRepository = unitOfWork.GetRepository<Room>();
        }

        public async Task<TOutDtoEntity> AddRoomAsync<TOutDtoEntity, TInDtoEntity>(int floorId, TInDtoEntity dtoRoom)
        {
            Floor floor = await repository.GetByIdAsync(floorId);
            if (floor == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                Room room = mapper.Map<Room>(dtoRoom);
                room.FloorId = floorId;
                _roomRepository.Insert(room);
                await unitOfWork.SaveAsync();
                return mapper.Map<TOutDtoEntity>(room);
            }
        }

        public async Task<IEnumerable<TDtoEntity>> GetAllRoomsAsync<TDtoEntity>(int floorId)
        {
            //пытаемся получить объект этажа
            Floor floor = await repository.GetByIdAsync(floorId);
            if (floor == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return mapper.Map<IEnumerable<TDtoEntity>>(floor.Rooms);
            }
        }

        public async Task DeleteRoomAsync(int roomId)
        {
            Room room = await _roomRepository.GetByIdAsync(roomId);
            if (room == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                _roomRepository.Delete(room);
                await unitOfWork.SaveAsync();
            }
        }

        private ICRUDRepository<Room> _roomRepository;
    }
}
