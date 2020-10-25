using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeBussinessLayer.Interface;
using EmployeeBussinessLayer.Service;
using EmployeeRepositoryLayer;
using EmployeeRepositoryLayer.Interface;
using EmployeeRepositoryLayer.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EmployeeManagementApi
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
            services.Configure<EmployeeDataBaseSetting>(
              Configuration.GetSection(nameof(EmployeeDataBaseSetting)));

            services.AddSingleton<IEmployeeDataBaseSetting>(sp =>
            sp.GetRequiredService<IOptions<EmployeeDataBaseSetting>>().Value);


            services.AddSingleton<IEmployeeBL, EmployeeBL>();

            services.AddSingleton<IEmployeeRL, EmployeeRL>();

            //code for swagger 
            services.AddSwaggerGen(Options =>
            {
                Options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Swagger Fundoo Api",
                        Description = "Fundoo Api for Showing swagger",
                        Version = "v1"

                    });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //code for swagger
            app.UseSwagger();
            app.UseSwaggerUI(Options =>
            {
                Options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Fundoo Api");
            });
        }
    }
}
