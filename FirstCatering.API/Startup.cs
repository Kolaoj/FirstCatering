using System;
using AutoMapper;
using FirstCatering.API.Contexts;
using FirstCatering.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstCatering.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }
      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDataProtection();
            services.AddScoped<IEmployeeDataRepository, EmployeeDataRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var connectionString = _configuration["connectionStrings:cardDataDBConnectionString"];

            services.AddDbContext<EmployeeDataContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
