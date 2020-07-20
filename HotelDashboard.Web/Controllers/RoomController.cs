using HotelDashboard.Services.DtoModels;
using HotelDashboard.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task ReserveRoomAsync(int roomId, [FromBody] ReserveDataDto data)
        {
            await _service.ReserveRoomAsync(roomId, data.ReserveStart, data.ReserveEnd);
        }

        /// <summary>
        /// Заселить клиентов в комнату
        /// </summary>
        /// <param name="roomId">ID комнаты</param>
        /// <param name="populationDto">Информация для заселения</param>
        [HttpPut("{roomId}/populate")]
        public async Task PopulateRoomAsync(int roomId, [FromBody] PopulationDto populationDto)
        {
            if (ModelState.IsValid)
            {
                await _service.PopulateRoomAsync(roomId, populationDto);
            }
            else
            {
                throw new Exception("Invalid DTO model");
            }
            //await _service.PopulateRoomAsync(roomId, populationDto);
        }

        /// <summary>
        /// Получить информацию о комнате
        /// </summary>
        /// <param name="roomId">ID комнаты</param>
        [HttpGet("{roomId}/info")]
        public async Task<RoomInfoDto> GetRoomInfoAsync(int roomId)
        {
            return await _service.GetRoomInfoAsync<RoomInfoDto>(roomId);
        }

        private IRoomService _service;
    }
}
