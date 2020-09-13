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
using Microsoft.EntityFrameworkCore;
using EmployeeRegister.DAL;
using EmployeeRegister.DAL.Repositories;
using EmployeeRegister.Services;
using Newtonsoft.Json;

namespace EmployeeRegister
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
                
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(opts => opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddSpaStaticFiles(conf => conf.RootPath = "webapp");
            
            services.AddDbContext<CoreContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddTransient<GenderRepository>();
            services.AddTransient<SkillRepository>();
            services.AddTransient<EmployeeRepository>();

            services.AddTransient<EmployeeService>();
        }
                
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
