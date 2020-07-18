using System.Collections.Generic;

namespace HotelDashboard.Data.Models
{
    /// <summary>
    /// Модель этажа корпуса
    /// </summary>
    public class Floor : BaseModel
    {
        /// <summary>
        /// ID корпуса
        /// </summary>
        public int CorpsId { set; get; }
        /// <summary>
        /// Корпус, в котором расположен этаж
        /// </summary>
        public virtual Corps Corps { set; get; }
        /// <summary>
        /// Комнаты на этаже
        /// </summary>
        public virtual ICollection<Room> Rooms { set; get; }
    }
}
