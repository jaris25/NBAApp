using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NbaApp.Data.Models.Settings;
using NbaApp.Data.Services;
using NbaApp.Data.Services.FilteringServices;
using System.IO;

namespace NbaApp
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
            services.Configure<ApiService>(
Configuration.GetSection(nameof(ApiService)));

            //services.AddSingleton<IApiService>(sp =>
            //    sp.GetRequiredService<IOptions<ApiService>>().Value);

            services.Configure<PlayersDatabaseSettings>(
    Configuration.GetSection(nameof(PlayersDatabaseSettings)));

            services.AddSingleton<IPlayersDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PlayersDatabaseSettings>>().Value);

            services.Configure<ApiHelperSettings>(
Configuration.GetSection(nameof(ApiHelperSettings)));

            services.AddSingleton<IApiHelperSettings>(sp =>
                sp.GetRequiredService<IOptions<ApiHelperSettings>>().Value);
            services.AddHttpClient<IApiService, ApiService>();

            services.AddSingleton<IPlayersDataService, PlayersDataService>();
            services.AddSingleton<PlayersContext>();
            services.AddDbContext<PlayersContext>(options =>
            {
                options.UseSqlServer(Configuration.GetSection("PlayersDatabaseSettings").GetSection("ConnectionString").Value);
            });
            services.AddSingleton<FilterEngine>();

            services.AddMvc();
            services.AddControllers();

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
