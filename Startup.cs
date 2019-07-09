using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreangular.api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace coreangular.api
{
    public class Startup
    {
        private string _connectionString = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _connectionString = Configuration["secretConnectionString"];
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddEntityFrameworkNpgsql()
            .AddDbContext<ApiContext>(
                opt => opt.UseNpgsql(_connectionString)
                );
            // 데이터를봐야하기때문에
            services.AddTransient<DataSeed>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataSeed seed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // 데이터를봐야하기때문에
            seed.SeedData(20, 1000);
            app.UseMvc(routes => routes.MapRoute(
                "default", "api/{controller}/{action}/{id?}"
            ));

        }
    }
    //12 강부터시작
    //$ dotnet user-secrets set secretConnectionString "User ID=pdev;Password=1234;Server=localhost;Port=5432;Database=coreangular;Integrated Security=true;Pooling=true;"

    //$ dotnet ef migrations add InitialMigration
    //$ dotnet ef database update

    //dotnet build
    //dotnet run
}
