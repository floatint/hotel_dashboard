using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Информация о комнате
    /// </summary>
    public class RoomInfoDto
    {
        public DateTime ReserveStart { set; get; }
        public DateTime ReserveEnd { set; get; }
        public IEnumerable<ClientDto> Clients { set; get; }
    }
}
