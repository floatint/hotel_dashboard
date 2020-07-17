using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Services.DtoModels.Enums
{
    /// <summary>
    /// Состояние комнаты
    /// </summary>
    public enum RoomState
    {
        /// <summary>
        /// Свободна
        /// </summary>
        Free,
        /// <summary>
        /// Зарезервирована
        /// </summary>
        Reserved,
        /// <summary>
        /// Заселена
        /// </summary>
        Populated
    }
}
