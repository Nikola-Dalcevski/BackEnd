using BusinessLayer.Contracts;
using BusinessLayer.Services;
using DataAccess;
using DataAccess.Contracts;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Helpers
{
    public static class DiModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BicycleDbContex>(opt =>
             opt.UseSqlServer(connectionString));

            services.AddScoped<IBicycleRepository, BicycleRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICutomerRepository,  CustomerRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IBiclycleServices, BicycleServices>();

            return services; 
        }
    }
}
