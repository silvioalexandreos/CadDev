using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Repository.Base;
using Business.Repository.Service.Developer;
using CadFuncionario;
using Database.Domain.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebUI
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

            services.AddDbContext<Connection>();
            
            services.AddTransient<IDeveloperService, DeveloperService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddControllersWithViews();
            //Configuração Swagger
            services.AddSwaggerGen(d => 
            {
                d.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CadDev",
                    Description = "Api para cadastro de desenvolvedores",
                    Contact = new OpenApiContact
                    {
                        Name = "Silvio Alexandre",
                        Email = "silvio.alexandreos@gmail.com"
                    }
                });
            });
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

            //Configuração Swagger
            app.UseSwagger();
            app.UseSwaggerUI(d =>
            {
                d.SwaggerEndpoint("/swagger/v1/swagger.json", "CadDev");
                d.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "developer_salvar",
                    pattern: "{controller=Developer}/{action=Salvar}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Developer}/{action=Index}/{id?}");
            });
        }
    }
}
