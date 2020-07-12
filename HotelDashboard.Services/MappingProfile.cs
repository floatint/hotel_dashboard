using AutoMapper;
using HotelDashboard.Data.Models;
using HotelDashboard.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

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
        }

        //Маппинги
        private void RoomMap()
        {
            //если у комнаты нет записи о статусе, то она свободна
            Func<Room, bool> isFree = (Room r) =>
            {
                return r.Status == null;
            };

            CreateMap<Room, RoomView>()
                .ForMember(rv => rv.IsFree, m => m.MapFrom(r => isFree(r)));
        }

    }
}
