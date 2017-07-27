using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using JO.Data;
using JO.Core;
using JO.Core.Services.Interfaces;
using JO.Core.Services;

namespace JO.VirtualPet
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VirtualPetContext>();
            // Add framework services.
            services.AddMvc();

            services.AddLogging();
            // Add our repository type
            services.AddTransient<IRepository<Animal>,EfRepository<Animal>>();
            services.AddTransient<IRepository<AnimalStats>, EfRepository<AnimalStats>>();
            services.AddTransient<IRepository<AnimalType>, EfRepository<AnimalType>>();
            services.AddTransient<IRepository<User>, EfRepository<User>>();
            services.AddTransient<IAnimalService, AnimalService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICalculateAnimalStateService, CalculateAnimalStateService>();
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Virtual Pet Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Visrtual Pet API V1");
            });

        }
    }
}
