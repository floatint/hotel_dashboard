using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelDashboard.Data.Models;
using HotelDashboard.Services.Services;
using HotelDashboard.Services.DtoModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelDashboard.Web.Controllers
{
    /// <summary>
    /// Контроллер корпусов
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CorpsController : ControllerBase
    {
        public CorpsController(ICorpsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получить список всех корпусов
        /// </summary>
        [HttpGet]
        public async Task<IEnumerable<CorpsView>> GetAllCorpsAsync()
        {
            return await _service.GetAllAsync<CorpsView>();
        }

        /// <summary>
        /// Создать новый корпус
        /// </summary>
        /// <returns>ID созданного корпуса</returns>
        [HttpPost]
        public async Task<CorpsView> AddCorpsAsync()
        {
            CorpsView corpsView = new CorpsView();
            corpsView.Id = await _service.AddAsync(corpsView);
            return corpsView;
        }

        /// <summary>
        /// Удалить корпус
        /// </summary>
        /// <param name="corpsId">ID корпуса</param>
        [HttpDelete("{corpsId}")]
        public async Task DeleteCorpsAsync(int corpsId)
        {
            await _service.DeleteAsync(corpsId);
        }

        /// <summary>
        /// Получить список этажей корпуса
        /// </summary>
        /// <param name="corpsId">ID корпуса</param>
        [HttpGet("{corpsId}/floors")]
        public async Task<IEnumerable<FloorView>> GetAllFloorsAsync(int corpsId)
        {
            return await _service.GetAllFloorsAsync<FloorView>(corpsId);
        }

        /// <summary>
        /// Добавить этаж в корпус
        /// </summary>'
        /// <param name="corpsId">ID корпуса</param>
        [HttpPost("{corpsId}/floors")]
        public async Task<FloorView> AddFloorAsync(int corpsId)
        {
            return await _service.AddFloorAsync<FloorView>(corpsId);
        }

        //TODO: пересмотреть, возможно id корпуса не нужен
        /// <summary>
        /// Удалить этаж корпуса
        /// </summary>
        /// <param name="corpsId">ID корпуса</param>
        /// <param name="floorId">ID этажа</param>
        [HttpDelete("{corpsId}/floors/{floorId}")]
        public async Task DeleteFloor(int corpsId, int floorId)
        {
            await _service.DeleteFloorAsync(corpsId, floorId);
        }

        private ICorpsService _service;
    }
}
