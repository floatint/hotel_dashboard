namespace HotelDashboard.Data.Models.Enums
{
    /// <summary>
    /// Тип комнаты
    /// </summary>
    public enum RoomType : byte
    {
        /// <summary>
        /// Одноместная
        /// </summary>
        Single = 1,
        /// <summary>
        /// Двухместная
        /// </summary>
        Double = 2,
        /// <summary>
        /// Семейная (4 человека максимум)
        /// </summary>
        Family = 4
    }
}
