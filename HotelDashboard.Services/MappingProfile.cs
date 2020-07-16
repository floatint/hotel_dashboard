using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Services.DtoModels;
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
            // если у комнаты нет записи о статусе, то она свободна
            Func<Room, bool> isFree = (Room r) =>
            {
                return r.Status == null;
            };

            CreateMap<Room, RoomDto>()
                .ForMember(rv => rv.IsFree, m => m.MapFrom(r => isFree(r)));
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
