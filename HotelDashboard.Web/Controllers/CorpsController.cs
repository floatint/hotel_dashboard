using HotelDashboard.Services.DtoModels;
using HotelDashboard.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<CorpsDto>> GetAllCorpsAsync()
        {
            return await _service.GetAllAsync<CorpsDto>();
        }

        /// <summary>
        /// Создать новый корпус
        /// </summary>
        /// <returns>ID созданного корпуса</returns>
        [HttpPost]
        public async Task<CorpsDto> AddCorpsAsync()
        {
            CorpsDto corpsView = new CorpsDto();
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
        public async Task<IEnumerable<FloorDto>> GetAllFloorsAsync(int corpsId)
        {
            return await _service.GetAllFloorsAsync<FloorDto>(corpsId);
        }

        /// <summary>
        /// Добавить этаж в корпус
        /// </summary>'
        /// <param name="corpsId">ID корпуса</param>
        [HttpPost("{corpsId}/floors")]
        public async Task<FloorDto> AddFloorAsync(int corpsId)
        {
            return await _service.AddFloorAsync<FloorDto>(corpsId);
        }

        /// <summary>
        /// Удалить этаж корпуса
        /// </summary>
        /// <param name="floorId">ID этажа</param>
        [HttpDelete("floors/{floorId}")]
        public async Task DeleteFloor(int floorId)
        {
            await _service.DeleteFloorAsync(floorId);
        }

        private ICorpsService _service;
    }
}
