using Microsoft.Extensions.DependencyInjection;
using PowerPlant.Application.Interface;
using PowerPlant.Application.Service;

namespace PowerPlant.Service
{
    public static class Startup
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddSingleton<IPowerPlantService, PowerPlantService>();
        }
    }
}