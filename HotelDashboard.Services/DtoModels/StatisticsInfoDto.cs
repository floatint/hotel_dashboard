namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// DTO статистики
    /// </summary>
    public class StatisticsInfoDto
    {
        /// <summary>
        /// Комнат свободно
        /// </summary>
        public int FreeRoomCount { set; get; }
        /// <summary>
        /// Комнат зарезервировано
        /// </summary>
        public int ReservedRoomCount { set; get; }
        /// <summary>
        /// Комнат занято
        /// </summary>
        public int PopulatedRoomCount { set; get; }
    }
}
