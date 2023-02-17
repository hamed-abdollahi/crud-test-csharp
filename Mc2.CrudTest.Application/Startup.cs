using Mc2.CrudTest.Repository.Command;
using Mc2.CrudTest.Repository.Contract.Command;
using Mc2.CrudTest.Repository.DAO;
using Mc2.CrudTest.Repository.Query;
using Mc2.CrudTest.Service.Command;
using Mc2.CrudTest.Service.Contract.Command;
using Mc2.CrudTest.Service.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application
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
            services.AddDbContext<ApplicationContext>(ServiceLifetime.Transient);
            services.AddScoped<ICustomerCommandService, CustomerCommandService>();
            services.AddScoped<ICustomerQueryService, CustomerQueryService>();

            services.AddTransient<ICustomerCommandRepository, CustomerCommandRepository>();
            services.AddTransient<ICustomerQueryRepository, CustomerQueryRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mc2.CrudTest.Application", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mc2.CrudTest.Application v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
