using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DauaPharm.Data;
using Syncfusion.Blazor;   // добавил
using BlazorDapperCRUD.Data;

namespace DauaPharm
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        //    services.AddServerSideBlazor();
            services.AddSyncfusionBlazor();  // добавил

            services.AddScoped<IPharmService, PharmService>();
            // SQL database connection (name defined in appsettings.json).
            var SqlConnectionConfiguration = new SqlConnectionConfiguration(Configuration.GetConnectionString("SqlDBcontext"));
            services.AddSingleton(SqlConnectionConfiguration);

            // Optional for debugging
            services.AddServerSideBlazor(o => o.DetailedErrors = true);

            services.AddSingleton<WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // добавил ключ 
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQyNDQzQDMxMzgyZTMxMmUzMEZIMGdyNU91RTF0T1IwQnp3RDMyMlZUcVlPWmdyOUlUa2lncVBWWWlEbzA9");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
