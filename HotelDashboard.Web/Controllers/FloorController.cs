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
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        public FloorController(IFloorService service)
        {
            _service = service;
        }

        [HttpGet("{floorId}/rooms")]
        public async Task<IEnumerable<RoomView>> GetRoomsAsync(int floorId)
        {
            return await _service.GetAllRoomsAsync<RoomView>(floorId);
        }

        [HttpPost("{floorId}/rooms")]
        public async Task<RoomView> AddRoomAsync(int floorId, [FromBody] NewRoom dtoRoom)
        {
            return await _service.AddRoomAsync<RoomView, NewRoom>(floorId, dtoRoom);
        }

        [HttpDelete("rooms/{roomId}")]
        public async Task DeleteRoomAsync(int roomId)
        {
            await _service.DeleteRoomAsync(roomId);
        }

        private IFloorService _service;
    }
}
