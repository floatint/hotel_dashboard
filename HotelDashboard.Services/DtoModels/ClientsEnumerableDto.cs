using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelDashboard.Services.DtoModels
{
    /// <summary>
    /// Класс-хелпер для маппинга PopulationDto -> IEnumerable
    /// </summary>
    public class ClientsEnumerableDto
    {
        [MinLength(1)]
        public IEnumerable<NewClientDto> ClientsEnumerable { set; get; }
    }
}
