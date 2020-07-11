using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelDashboard.Data
{
    /// <summary>
    /// Интерфейс модуля для внедрения через DI
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Конфигуратор сервисов
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        /// <param name="configuration">Конфигурация приложения</param>
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}
