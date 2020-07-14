using HotelDashboard.Data.Models;
using HotelDashboard.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Общая информация о комнате
    /// </summary>
    public class RoomView : BaseModel
    {
        /// <summary>
        /// Тип комнаты
        /// </summary>
        public RoomType Type { set; get; }
        /// <summary>
        /// Комната свободна для резервирования или заселения
        /// </summary>
        public bool IsFree { set; get; }
    }
}
