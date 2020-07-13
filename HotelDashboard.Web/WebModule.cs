using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelDashboard.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelDashboard.Web
{
    /// <summary>
    /// Подуль, настраивающий web часть
    /// </summary>
    public class WebModule : IModule
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //ригистрируем конфигурацию как статическую
            services.AddSingleton<IConfiguration>(configuration);
            //сваггер
            services.AddSwaggerGen();
        }
    }
}
