using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HotelDashboard.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

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
            //Копипаста с МСДН
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "HotelDashboard Web API",
                    Description = "HotelDashboard.Web documentation"
                });

                // Подключаем XML документацию
                //для Web API модуля
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                //для сервисов
                xmlFile = $"{nameof(HotelDashboard)}.{nameof(Services)}.xml";
                xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                //для данных
                xmlFile = $"{nameof(HotelDashboard)}.{nameof(Data)}.xml";
                xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
