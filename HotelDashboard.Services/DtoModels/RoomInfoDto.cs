using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Информация о комнате
    /// </summary>
    public class RoomInfoDto
    {
        [Range(typeof(DateTime), "01/01/1900", "01/01/2100", ErrorMessage = "Дата резервирования(заселения)")]
        public DateTime ReserveStart { set; get; }
        [Range(typeof(DateTime), "01/01/1900", "01/01/2100", ErrorMessage = "Дата окончания резервирования(проживания)")]
        public DateTime ReserveEnd { set; get; }
        [MinLength(1)]
        public IEnumerable<ClientDto> Clients { set; get; }
    }
}
