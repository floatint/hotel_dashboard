using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Данные для резервирования комнаты
    /// </summary>
    public class ReserveData
    {
        public DateTime ReserveStart { set; get; }
        public DateTime ReserveEnd { set; get; }
    }
}
