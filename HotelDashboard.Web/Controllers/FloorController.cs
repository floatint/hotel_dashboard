using HotelDashboard.Services.DtoModels;
using HotelDashboard.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelDashboard.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        public FloorController(IFloorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получить все комнаты на этаже
        /// </summary>
        /// <param name="floorId"></param>
        [HttpGet("{floorId}/rooms")]
        public async Task<IEnumerable<RoomView>> GetRoomsAsync(int floorId)
        {
            return await _service.GetAllRoomsAsync<RoomView>(floorId);
        }

        /// <summary>
        /// Добавить комнату на этаж
        /// </summary>
        /// <param name="floorId">"ID этажа</param>
        /// <param name="dtoRoom">DTO комнаты</param>
        [HttpPost("{floorId}/rooms")]
        public async Task<RoomView> AddRoomAsync(int floorId, [FromBody] NewRoom dtoRoom)
        {
            return await _service.AddRoomAsync<RoomView, NewRoom>(floorId, dtoRoom);
        }

        /// <summary>
        /// Удалить комнату с этажа
        /// </summary>
        /// <param name="roomId">ID комнаты</param>
        [HttpDelete("rooms/{roomId}")]
        public async Task DeleteRoomAsync(int roomId)
        {
            await _service.DeleteRoomAsync(roomId);
        }

        private IFloorService _service;
    }
}
