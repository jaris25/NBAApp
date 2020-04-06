using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NbaApi.Models;
using NbaApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace NbaApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PlayersContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
            });
            services.AddControllers();

            services.Configure<ApiHelper>(
Configuration.GetSection(nameof(ApiHelper)));

            services.AddSingleton<IApiHelper>(sp =>
                sp.GetRequiredService<IOptions<ApiHelper>>().Value);

            services.Configure<PlayersDatabaseSettings>(
    Configuration.GetSection(nameof(PlayersDatabaseSettings)));

            services.AddSingleton<IPlayersDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PlayersDatabaseSettings>>().Value);

            services.Configure<ApiHelperSettings>(
Configuration.GetSection(nameof(ApiHelperSettings)));

            services.AddSingleton<IApiHelperSettings>(sp =>
                sp.GetRequiredService<IOptions<ApiHelperSettings>>().Value);

            services.AddMvc();

            services.AddSingleton<PlayersData>();
            services.AddSingleton<PlayersContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
