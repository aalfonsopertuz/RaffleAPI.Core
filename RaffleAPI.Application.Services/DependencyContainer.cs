using Microsoft.Extensions.DependencyInjection;
using RaffleAPI.Application.Interfaces.Services;
using RaffleAPI.Application.Services.Services;

namespace RaffleAPI.Application.Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRaffleService, RaffleService>();
            return services;
        }
    }
}
