using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Security;
using Security.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JNJPBackEnd.Hubs;

namespace JNJPBackEnd
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
            services.AddDbContext<JNJPContext>(opt =>
                                               opt.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase")));
            services.AddDbContext<SecurityContext>(opt =>
                                               opt.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase"), b => b.MigrationsAssembly("JNJPBackEnd")
                                               ));

            services.AddControllers().AddNewtonsoftJson();
            services.AddSignalR();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "节能减排大赛", Description = "节能减排大赛的后端API列表", Version = "v1" });
            });
            services.AddHttpContextAccessor();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider service)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "JNJPBackEnd v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<RecycleHub>("/hub");
            });
        }
    }
}
