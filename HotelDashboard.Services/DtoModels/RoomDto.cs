using HotelDashboard.Data.Models;
using HotelDashboard.Data.Models.Enums;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Общая информация о комнате
    /// </summary>
    public class RoomDto : BaseModel
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
