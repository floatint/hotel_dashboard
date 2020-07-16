﻿using HotelDashboard.Data.Models.Enums;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Информация для создания новой комнаты
    /// </summary>
    public class NewRoom
    {
        /// <summary>
        /// Тип комнаты
        /// </summary>
        public RoomType Type { set; get; }
    }
}
