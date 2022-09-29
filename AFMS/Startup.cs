using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AFMS.Models;
using AFMS.Models.GraphQL;
using AFMS.Repositories;
using GraphQL.Server;
using GraphQL;
using AFMS.Models.GraphQL.Types;

namespace AFMS
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
            services.AddDbContext<afmsDataBaseContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DbConnString")));

            services.AddScoped<IServiceProvider>(s => new FuncServiceProvider(s.GetRequiredService));
            services.AddScoped<afmsDataBaseSchema>();
            services.AddScoped<ClientType>();
            services.AddScoped<AdminType>();
            services.AddScoped<FuelType>();
            services.AddScoped<FlightType>();
            services.AddScoped<OrderType>();
            services.AddScoped<afmsDataBaseQuery>();


            services.AddGraphQL().AddSystemTextJson().AddGraphTypes(ServiceLifetime.Scoped);

            services.AddScoped<ClientRepository>();
            services.AddScoped<AdminRepository>();
            services.AddScoped<FuelRepository>();
            services.AddScoped<FlightRepository>();
            services.AddScoped<OrderRepository>();

            services.AddCors();

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

            app.UseCors(builder =>
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseGraphQL<afmsDataBaseSchema>();

            app.UseGraphQLPlayground();
        }
    }
}
