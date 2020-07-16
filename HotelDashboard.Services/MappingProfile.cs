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

            CreateMap<Room, RoomView>()
                .ForMember(rv => rv.IsFree, m => m.MapFrom(r => isFree(r)));
            CreateMap<NewRoom, Room>();
            CreateMap<Room, NewRoom>();
        }

        private void FloorMap()
        {
            CreateMap<Floor, FloorView>();
        }

        private void CorpsMap()
        {
            CreateMap<Corps, CorpsView>();
        }

        private void ClientMap()
        {
            CreateMap<NewClient, Client>();
        }

    }
}
