using System.ComponentModel.DataAnnotations;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Информация для заселения
    /// </summary>
    public class PopulationDto
    {
        /// <summary>
        /// Заселяющиеся клиенты
        /// </summary>
        [Required]
        public ClientsEnumerableDto Clients { set; get; }
        /// <summary>
        /// Время проживания
        /// </summary>
        [Required]
        public ReserveDataDto ReserveData { set; get; }
    }
}
