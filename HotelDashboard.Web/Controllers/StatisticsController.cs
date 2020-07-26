using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelDashboard.Data.Models.Enums;
using HotelDashboard.Services.DtoModels;
using HotelDashboard.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelDashboard.Web.Controllers
{
    /// <summary>
    /// Контроллер статистики
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        public StatisticsController(IStatisticsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получить статистику по корпусу
        /// </summary>
        /// <param name="corpsId">ID корпуса</param>
        [HttpGet("corps/{corpsId}")]
        public async Task<StatisticsInfoDto> GetCorpsStatisticsAsync(int corpsId)
        {
            return await _service.GetCorpsStatisticsAsync(corpsId);
        }

        /// <summary>
        /// Получить статистику по этажу
        /// </summary>
        /// <param name="floorId">ID этажа</param>
        [HttpGet("floor/{floorId}")]
        public async Task<StatisticsInfoDto> GetFloorStatisticsAsync(int floorId)
        {
            return await _service.GetFloorStatisticsAsync(floorId);
        }

        /// <summary>
        /// Получить статистику по типу комнаты
        /// </summary>
        /// <param name="floorId">ID этажа</param>
        /// <param name="roomType">Тип комнаты</param>
        [HttpGet("floor/{floorId}/roomtype/{roomType}")]
        public async Task<StatisticsInfoDto> GetRoomTypeStatisticsAsync(int floorId, RoomType roomType)
        {
            return await _service.GetRoomTypeStatisticsAsync(floorId, roomType);
        }

        private IStatisticsService _service;
    }
}
