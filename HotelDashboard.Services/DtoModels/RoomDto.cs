using HotelDashboard.Data.Models;
using HotelDashboard.Data.Models.Enums;
using HotelDashboard.Services.DtoModels.Enums;

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
        /// Состояние комнаты
        /// </summary>
        public RoomState State { set; get; }
    }
}
