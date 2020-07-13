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
            //найдем комнату
            Room room = await repository.GetByIdAsync(roomId);
            if (room == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                RoomStatus status = room.Status;
                //если комната не свободна
                if (status != null)
                {
                    //если номер заселен
                    if (status.Clients != null)
                    {
                        //выписываем клиентов
                        foreach (var client in status.Clients)
                        {
                            _clientRepository.Delete(client);
                        }
                    }
                    //удаляем статус
                    _roomStatusRepository.Delete(status);
                    //сохраняем контекст
                    await unitOfWork.SaveAsync();
                }
            }
        }

        public async Task PopulateRoomAsync<TDtoEntity>(int roomId, IEnumerable<TDtoEntity> clients)
        {
            //получаем комнату
            Room room = await repository.GetByIdAsync(roomId);
            //проверим, существует ли комната
            if (room == null)
            {
                //не существует
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                //маппинг в доменные модели клиентов
                IEnumerable<Client> domainClients = mapper.Map<IEnumerable<Client>>(clients);

                //заселяем клиентов
                //полагаем, что status != null
                foreach (var client in domainClients)
                {
                    client.RoomStatusId = room.Status.Id;
                    _clientRepository.Insert(client);
                }
                //сохраняем контекст
                await unitOfWork.SaveAsync();
            }

        }

        public async Task ReserveRoomAsync(int roomId, DateTime reserveStart, DateTime reserveEnd)
        {
            //убедимся, что комната существует
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
                //сохраняем
                await unitOfWork.SaveAsync();
            }
        }

        private ICRUDRepository<RoomStatus> _roomStatusRepository;
        private ICRUDRepository<Client> _clientRepository;
    }
}
