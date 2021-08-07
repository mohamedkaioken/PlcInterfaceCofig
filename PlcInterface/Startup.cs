using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PlcInterface.Context;

namespace PlcInterface
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
            services.AddCors();
            services.Configure<IISServerOptions>(o =>
            {
                o.AllowSynchronousIO = true;
            });
            services.AddDbContext<ApplicationDbContext>(p => p.UseSqlServer(Configuration.GetConnectionString("default")));
            services.AddDbContext<MesContext>(p => p.UseSqlServer(Configuration.GetConnectionString("COCAMES")));
            services.AddDbContext<EnergyContext>(p => p.UseSqlServer(Configuration.GetConnectionString("iotT")));
            services.AddDbContext<EnergyReportContext>(p => p.UseSqlServer(Configuration.GetConnectionString("enRe")));
            services.AddDbContext<SignalContext>(p => p.UseSqlServer(Configuration.GetConnectionString("signal")));
            services.AddCors();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowedToAllowWildcardSubdomains());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
