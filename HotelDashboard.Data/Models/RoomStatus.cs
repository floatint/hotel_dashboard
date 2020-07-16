using System;
using System.Collections.Generic;

namespace HotelDashboard.Data.Models
{
    /// <summary>
    /// Информация о состоянии комнаты
    /// </summary>
    public class RoomStatus : BaseModel
    {
        /// <summary>
        /// ID комнаты
        /// </summary>
        public int RoomId { set; get; }
        /// <summary>
        /// Комната
        /// </summary>
        public virtual Room Room { set; get; }
        /// <summary>
        /// Дата, когда номер был заселен или зарезервирован
        /// </summary>
        public DateTime ReserveStart { set; get; }
        /// <summary>
        /// Дата, когда номер будет освобожден
        /// </summary>
        public DateTime ReserveEnd { set; get; }
        /// <summary>
        /// Клиенты которые проживают в номере
        /// </summary>
        public virtual ICollection<Client> Clients { set; get; }
    }
}
