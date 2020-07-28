using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Data.Models.Enums;
using HotelDashboard.Data.Repositories;
using HotelDashboard.Services.DtoModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelDashboard.Services.Services
{
    /// <summary>
    /// Реализация сервиса статистики
    /// </summary>
    class StatisticsService : IStatisticsService
    {
        public StatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            corpsRepository = unitOfWork.GetRepository<Corps>();
            floorRepository = unitOfWork.GetRepository<Floor>();
            roomRepository = unitOfWork.GetRepository<Room>();
        }
        public async Task<StatisticsInfoDto> GetCorpsStatisticsAsync(int corpsId)
        {
            if (await corpsRepository.GetByIdAsync(corpsId) == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                StatisticsInfoDto statisticsInfoDto = new StatisticsInfoDto();
                // получаем все этажи
                var floors = (await floorRepository.GetAllAsync()).Where(x => x.CorpsId == corpsId);
                // идем по этажам
                foreach (var f in floors)
                {
                    // получаем комнаты этажа
                    var rooms = (await roomRepository.GetAllAsync()).Where(x => x.FloorId == f.Id);
                    foreach (var r in rooms)
                    {
                        if (r.Status != null)
                        {
                            if (r.Status.Clients != null && r.Status.Clients.Count != 0)
                            {
                                statisticsInfoDto.PopulatedRoomCount++;
                            }
                            else
                            {
                                statisticsInfoDto.ReservedRoomCount++;
                            }
                        }
                        else
                        {
                            statisticsInfoDto.FreeRoomCount++;
                        }
                    }
                }
                return statisticsInfoDto;
            }
        }

        public async Task<StatisticsInfoDto> GetFloorStatisticsAsync(int floorId)
        {
            Floor floor = await floorRepository.GetByIdAsync(floorId);
            if (floor == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                StatisticsInfoDto statisticsInfoDto = new StatisticsInfoDto();
                foreach (var r in floor.Rooms)
                {
                    if (r.Status != null)
                    {
                        if (r.Status.Clients != null && r.Status.Clients.Count != 0)
                        {
                            statisticsInfoDto.PopulatedRoomCount++;
                        }
                        else
                        {
                            statisticsInfoDto.ReservedRoomCount++;
                        }
                    }
                    else
                    {
                        statisticsInfoDto.FreeRoomCount++;
                    }
                }
                return statisticsInfoDto;
            }
        }

        public async Task<StatisticsInfoDto> GetRoomTypeStatisticsAsync(int floorId, RoomType roomType)
        {
            Floor floor = await floorRepository.GetByIdAsync(floorId);
            if (floor == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                var rooms = floor.Rooms.Where(x => x.Type == roomType).AsEnumerable();
                if (rooms.Count() == 0)
                {
                    throw new Exception();
                }
                else
                {
                    StatisticsInfoDto statisticsInfoDto = new StatisticsInfoDto();
                    foreach (var r in rooms)
                    {
                        if (r.Status != null)
                        {
                            if (r.Status.Clients != null && r.Status.Clients.Count != 0)
                            {
                                statisticsInfoDto.PopulatedRoomCount++;
                            }
                            else
                            {
                                statisticsInfoDto.ReservedRoomCount++;
                            }
                        }
                        else
                        {
                            statisticsInfoDto.FreeRoomCount++;
                        }
                    }
                    return statisticsInfoDto;
                }
            }
            //var rooms = (await roomRepository.GetAllAsync()).Where(x => x.Type == roomType);
            //if (rooms.Count() == 0)
            //{
            //    throw new Exception();
            //}
            //else
            //{
            //    StatisticsInfoDto statisticsInfoDto = new StatisticsInfoDto();
            //    foreach(var r in rooms)
            //    {
            //        if (r.Status != null)
            //        {
            //            if (r.Status.Clients != null && r.Status.Clients.Count != 0)
            //            {
            //                statisticsInfoDto.PopulatedRoomCount++;
            //            }
            //            else
            //            {
            //                statisticsInfoDto.ReservedRoomCount++;
            //            }
            //        }
            //        else
            //        {
            //            statisticsInfoDto.FreeRoomCount++;
            //        }
            //    }
            //    return statisticsInfoDto;
            //}
        }

        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private ICRUDRepository<Corps> corpsRepository;
        private ICRUDRepository<Floor> floorRepository;
        private ICRUDRepository<Room> roomRepository;
    }
}
