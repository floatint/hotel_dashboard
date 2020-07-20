using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Data.Repositories;
using HotelDashboard.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Реализация сервиса комнат
    /// </summary>
    public class RoomService : BaseService<Room>, IRoomService
    {
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
            _roomStatusRepository = unitOfWork.GetRepository<RoomStatus>();
            _clientRepository = unitOfWork.GetRepository<Client>();
        }

        public async Task FreeRoom(int roomId)
        {
            // найдем комнату
            Room room = await repository.GetByIdAsync(roomId);
            if (room == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                RoomStatus status = room.Status;
                // если комната не свободна
                if (status != null)
                {
                    // если номер заселен
                    if (status.Clients != null)
                    {
                        // выписываем клиентов
                        foreach (var client in status.Clients)
                        {
                            _clientRepository.Delete(client);
                        }
                    }
                    // удаляем статус
                    _roomStatusRepository.Delete(status);
                    // сохраняем контекст
                    await unitOfWork.SaveAsync();
                }
            }
        }

        public async Task PopulateRoomAsync<TDtoEntity>(int roomId, TDtoEntity populationDto)
        {
            // получаем комнату
            Room room = await repository.GetByIdAsync(roomId);
            // проверим, существует ли комната
            if (room == null)
            {
                // не существует
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                ReserveDataDto reserveDataDto = mapper.Map<ReserveDataDto>(populationDto);
                RoomStatus roomStatus = null;
                // проверим, была ли комната зарезервирована
                if (room.Status != null)
                {
                    // запись уже есть, значит обновим ее под период проживания
                    roomStatus = room.Status;
                    roomStatus.ReserveStart = reserveDataDto.ReserveStart;
                    roomStatus.ReserveEnd = reserveDataDto.ReserveEnd;
                    //обновляем
                    _roomStatusRepository.Update(roomStatus);
                }
                else
                {
                    // добавим новую запись
                    roomStatus = new RoomStatus
                    {
                        RoomId = roomId,
                        ReserveStart = reserveDataDto.ReserveStart,
                        ReserveEnd = reserveDataDto.ReserveEnd
                    };
                    //добавляем
                    _roomStatusRepository.Insert(roomStatus);
                }
                // сохраним запись о проживании
                await unitOfWork.SaveAsync();

                // теперь идем по клиентам
                // маппинг в доменные модели клиентов
                IEnumerable<Client> domainClients = mapper.Map<IEnumerable<Client>>(
                    mapper.Map<ClientsEnumerableDto>(populationDto).ClientsEnumerable);

                // заселяем клиентов
                foreach (var client in domainClients)
                {
                    client.RoomStatusId = roomStatus.Id;
                    _clientRepository.Insert(client);
                }
                // сохраняем контекст
                await unitOfWork.SaveAsync();
            }

        }

        public async Task ReserveRoomAsync(int roomId, DateTime reserveStart, DateTime reserveEnd)
        {
            // убедимся, что комната существует
            if (await repository.GetByIdAsync(roomId) == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                RoomStatus status = new RoomStatus
                {
                    RoomId = roomId,
                    ReserveStart = reserveStart,
                    ReserveEnd = reserveEnd
                };
                _roomStatusRepository.Insert(status);
                // сохраняем
                await unitOfWork.SaveAsync();
            }
        }

        public async Task<TDtoEntity> GetRoomInfoAsync<TDtoEntity>(int roomId)
        {
            Room room = await repository.GetByIdAsync(roomId);
            if (room == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return mapper.Map<TDtoEntity>(room);
            }
        }

        private ICRUDRepository<RoomStatus> _roomStatusRepository;
        private ICRUDRepository<Client> _clientRepository;
    }
}
