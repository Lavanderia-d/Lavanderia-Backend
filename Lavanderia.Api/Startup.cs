using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lavanderia.Api.Mappers;
using Lavanderia.Domain.Repositories;
using Lavanderia.Domain.Services;
using Lavanderia.Infra.Contexts;
using Lavanderia.Infra.Repositories;
using Lavanderia.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Lavanderia.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            SetupDbContext(services);
            SetupControllers(services);
            SetupServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void SetupDbContext(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(
                opt => opt.UseMySql(Configuration.GetConnectionString("MySQL"))
            );
        }

        private void SetupControllers(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson(opt => {
                        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    });
        }

        private void SetupServices(IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(CustomerProfile),
                typeof(OrderProfile),
                typeof(OrderItemProfile)
            );
            
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        }

        public IConfiguration Configuration { get; }
    }
}
