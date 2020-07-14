using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelDashboard.Data.Models;
using HotelDashboard.Services.DtoModels;
using HotelDashboard.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelDashboard.Web.Controllers
{
    /// <summary>
    /// Контроллер комнат
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        public RoomController(IRoomService service)
        {
            _service = service;
        }

        /// <summary>
        /// Освободить комнату
        /// </summary>
        /// <param name="roomId">ID комнаты</param>
        [HttpPut("{roomId}/free")]
        public async Task FreeRoomAsync(int roomId)
        {
            await _service.FreeRoom(roomId);
        }

        /// <summary>
        /// Резервирование комнаты
        /// </summary>
        /// <param name="roomId">ID комнаты</param>
        /// <param name="data">Данные для резервирования</param>
        [HttpPut("{roomId}/reserve")]
        public async Task ReserveRoomAsync(int roomId,  [FromBody] ReserveData data)
        {
            await _service.ReserveRoomAsync(roomId, data.ReserveStart, data.ReserveEnd);
        }

        /// <summary>
        /// Заселить клиентов в комнату
        /// </summary>
        /// <param name="roomId">ID комнаты</param>
        /// <param name="clients">Клиенты</param>
        [HttpPut("{roomId}/populate")]
        public async Task PopulateRoomAsync(int roomId, [FromBody] IEnumerable<NewClient> clients)
        {
            await _service.PopulateRoomAsync(roomId, clients);
        }

        private IRoomService _service;
    }
}
