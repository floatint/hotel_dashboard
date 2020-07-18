using System;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Данные для резервирования комнаты
    /// </summary>
    public class ReserveDataDto
    {
        /// <summary>
        /// Дата резервирования
        /// </summary>
        public DateTime ReserveStart { set; get; }
        /// <summary>
        /// Дата окончания резервирования
        /// </summary>
        public DateTime ReserveEnd { set; get; }
    }
}
