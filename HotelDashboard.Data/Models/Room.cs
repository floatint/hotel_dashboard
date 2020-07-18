using HotelDashboard.Data.Models.Enums;

namespace HotelDashboard.Data.Models
{
    /// <summary>
    /// Модель комнаты отеля
    /// </summary>
    public class Room : BaseModel
    {
        /// <summary>
        /// ID этажа
        /// </summary>
        public int FloorId { set; get; }
        /// <summary>
        /// Этаж, на котором расположена комната
        /// </summary>
        public virtual Floor Floor { set; get; }
        /// <summary>
        /// Тип комнаты (размерность)
        /// </summary>
        public RoomType Type { set; get; }
        /// <summary>
        /// Статус номера
        /// </summary>
        public virtual RoomStatus Status { set; get; }
    }
}
