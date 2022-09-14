using Microsoft.AspNetCore.Builder;
using PowerPlant.Application.Interface;
using PowerPlant.Application.Service;

namespace PlantPower.WepApi
{
    public class Startup
    {
        public Startup()
        {

        }

        public static void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddSwaggerGen();
        
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
           
            services.AddSingleton<IPowerPlantService, PowerPlantService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env,
                      ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            //...Other code removed for brevity
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PowerPlant");
                    });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllers();

            });

        }
    }
}


