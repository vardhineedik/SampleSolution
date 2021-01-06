using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.Domain.Abstract;
using Sample.Infrastructure.Repositories;
using SimpleInjector;

namespace SampleSolution
{
    public class Startup
    {
        private Container container = new SimpleInjector.Container();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("*");
            //        });

            //});
            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore();
                options.Services.AddCors(setttings => {
                    setttings.AddDefaultPolicy(
                      builder =>
                      {
                          builder.WithOrigins("*");
                      });
                });
                options.AddLogging();
                // options.AddLocalization();
            });
            services.AddTransient<IHelloWorldMessageRepository, HelloWorldMessageRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseSimpleInjector(container);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
