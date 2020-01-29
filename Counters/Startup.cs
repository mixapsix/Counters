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

namespace Counters
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
            services.AddRazorPages();
            services.AddTransient<IDataBase, DataBaseService>();
            services.AddDbContext<CountersContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("Connection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDataBase dataBase, CountersContext countersContext)
        {          
            dataBase.DropTable();
            dataBase.WriteData();
            var db = dataBase.GetCounters().ToList<Counter>();
            var sel = dataBase.GetIDs();

            app.Run(async (context) =>
            {
                foreach (var item in db)
                {
                    await context.Response.WriteAsync(item.ID + " " + item.Value +"\n");
                }

                foreach(var line in sel)
                {
                    foreach (var item in line)
                    {
                        await context.Response.WriteAsync(item.Number + " " + item.ID + " " + item.Value + "\n");
                    }
                }
            });             
        }
    }
}
