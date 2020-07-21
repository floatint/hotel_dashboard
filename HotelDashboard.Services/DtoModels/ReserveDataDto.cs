using System;
using System.ComponentModel.DataAnnotations;

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
        [Range(typeof(DateTime), "01/01/1900", "01/01/2100", ErrorMessage = "Дата резервирования(заселения)")]
        public DateTime ReserveStart { set; get; }
        /// <summary>
        /// Дата окончания резервирования
        /// </summary>
        [Range(typeof(DateTime), "01/01/1900", "01/01/2100", ErrorMessage = "Дата окончания резервирования(проживания)")]
        public DateTime ReserveEnd { set; get; }
    }
}
