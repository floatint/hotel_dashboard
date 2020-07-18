using HotelDashboard.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace HotelDashboard.Web
{
    /// <summary>
    /// Модуль, который производит регистрацию всех переданных в него модулей
    /// </summary>
    public class StartupModule : IModule
    {
        public StartupModule(ICollection<IModule> modules)
        {
            _modules = modules;
        }
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            foreach (var module in _modules)
                module.ConfigureServices(services, configuration);
        }

        private ICollection<IModule> _modules;
    }
}
