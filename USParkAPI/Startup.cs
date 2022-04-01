using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using USParkAPI.Models;

namespace USParkAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<USParkAPIContext>(opt =>
                opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
            services.AddControllers();
            // services.AddEndpointsApiExplorer();
            // services.AddSwaggerGen();
            services.AddSwaggerGen(options =>{
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "US Park API",
                    Description = "An ASP.NET Core Web API for US parks",
                    License = new OpenApiLicense
                    {
                        Name = "Copyright (c) | Mar 2022 | Jessi B"
                    }
                });
            });
            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            // app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}