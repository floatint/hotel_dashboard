using HotelDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
