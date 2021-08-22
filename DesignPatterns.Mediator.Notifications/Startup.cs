using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DesignPatterns.Mediator.Notifications
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesignPatterns.Mediator.Notifications", Version = "v1" });
            });

            // ASP.NET Core Los inyectará como IEnumerable<T> donde T es INotificationHandler
            // NotificationHandler1, 2 y 3 tienen distintas responsabilidades solo que
            // implementan la misma interfaz para que se les notique de algun evento
            services.AddTransient<INotificationHandler, NotificationHandler1>();
            services.AddTransient<INotificationHandler, NotificationHandler2>();
            services.AddTransient<INotificationHandler, NotificationHandler3>();

            services.AddTransient<IMediator, Mediator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesignPatterns.Mediator.Notifications v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
