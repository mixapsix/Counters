using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Counters.Services;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Counters
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
            services.AddMvc();
            services.AddTransient<IDataBase, DataBaseService>();
            services.AddDbContext<CountersContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("Connection")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataBase dataBase, CountersContext countersContext)
        {
            countersContext.Database.Migrate();

            app.UseStaticFiles();
            app.UseDefaultFiles();
            var loggerFactory = LoggerFactory.Create(builder => 
            {
                builder.AddDebug();
            });
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
