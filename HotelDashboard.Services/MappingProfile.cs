using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Services.DtoModels;
using HotelDashboard.Services.DtoModels.Enums;
using System;

namespace HotelDashboard.Services
{
    /// <summary>
    /// Конфигурация маппинга между dto и доменными моделями
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            RoomMap();
            FloorMap();
            CorpsMap();
            ClientMap();
        }

        // Маппинги
        private void RoomMap()
        {
            // определим состояние комнаты
            Func<Room, RoomState> roomState = (Room r) =>
            {
                // если нет статуса вообще - свободна
                if (r.Status == null)
                {
                    return RoomState.Free;
                }
                else
                {
                    // если есть клиенты
                    if (r.Status.Clients != null && r.Status.Clients.Count != 0)
                    {
                        return RoomState.Populated;
                    }
                    else
                    {
                        // просто зарезервирована
                        return RoomState.Reserved;
                    }
                }
            };

            CreateMap<Room, RoomDto>()
                .ForMember(rv => rv.State, m => m.MapFrom(r => roomState(r)));
            CreateMap<NewRoomDto, Room>();
            CreateMap<Room, NewRoomDto>();
        }

        private void FloorMap()
        {
            CreateMap<Floor, FloorDto>();
        }

        private void CorpsMap()
        {
            CreateMap<Corps, CorpsDto>();
        }

        private void ClientMap()
        {
            CreateMap<NewClientDto, Client>();
        }

    }
}
