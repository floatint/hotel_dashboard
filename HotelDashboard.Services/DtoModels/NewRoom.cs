using HotelDashboard.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Информация для создания новой комнаты
    /// </summary>
    public class NewRoom
    {
        public RoomType Type { set; get; }
    }
}
