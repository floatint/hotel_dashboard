using HotelDashboard.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelDashboard.Data
{
    public class DataModule : IModule
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //регистрируем сервис unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //регистрируем контекст БД.
            //connection string берется из IConfiguration
            services.AddDbContext<HotelContext>(optsBuilder => optsBuilder.UseSqlServer(configuration.GetConnectionString(typeof(HotelContext).Name)));
        }
    }
}
