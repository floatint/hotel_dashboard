using AutoMapper;
using HotelDashboard.Data;
using HotelDashboard.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelDashboard.Services
{
    /// <summary>
    /// Модуль, определяющий используемые сервисы
    /// </summary>
    public class ServicesModule : IModule
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // регистрируем сервисы
            services.AddScoped<ICorpsService, CorpsService>();
            services.AddScoped<IFloorService, FloorService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped(typeof(IBaseCRUDService<>), typeof(BaseService<>));
            // регистрируем маппинг
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
