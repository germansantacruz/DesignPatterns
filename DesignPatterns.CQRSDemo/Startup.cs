using DesignPatterns.CQRSDemo.Context;
using DesignPatterns.CQRSDemo.Domain.Exceptions;
using DesignPatterns.CQRSDemo.Filters;
using DesignPatterns.CQRSDemo.Filters.Handlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DesignPatterns.CQRSDemo
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

            services.AddControllers(options =>
            {
                options.Filters.Add(new ApiExceptionFilterAttribute(
                    new Dictionary<Type, IExceptionHandler>
                    {
                        { typeof(EntityNotFoundException),
                            new EntityNotFoundExceptionHandler()},
                        { typeof(GeneralException),
                            new GeneralExceptionHandler()}
                    }));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesignPatterns.CQRSDemo", Version = "v1" });
            });

            services.AddSingleton<IProductContext>(new ProductContext(Configuration.GetConnectionString("CQRSDemo")));
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesignPatterns.CQRSDemo v1"));
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
