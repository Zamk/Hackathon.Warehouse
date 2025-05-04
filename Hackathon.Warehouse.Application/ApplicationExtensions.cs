using Hackathon.Warehouse.Application.Services;
using Hackathon.Warehouse.Core.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Warehouse.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IWarehouseService, WarehouseService>();
            services.AddSingleton<IReceivingService, ReceivingService>();

            return services;
        }
    }
}
