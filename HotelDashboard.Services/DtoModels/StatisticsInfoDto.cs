using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Services.DtoModels
{
    public class StatisticsInfoDto
    {
        public int FreeRoomCount { set; get; }
        public int ReservedRoomCount { set; get; }
        public int PopulatedRoomCount { set; get; }
    }
}
