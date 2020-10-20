using System.Text;
using Business.Repository.Base;
using Business.Repository.Service.Developer;
using Business.Repository.Service.User;
using CadFuncionario;
using Database.Domain.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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
            services.AddCors();
            services.AddDbContext<Connection>();

            //O serviço é criado a cada vez que é solicitado.
            //O serviço é descartado ao final de cada solicitação.
            services.AddTransient<IDeveloperService, DeveloperService>();
            services.AddTransient<IUserService, UserService>();

            //o serviço é criado uma vez por cliente (conexão);
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUserRepository<>), typeof(UserRepository<>));

            services.AddControllersWithViews();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

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
            //app.UseAuthorization();

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

            //Configuração Swagger
            app.UseSwagger();
            app.UseSwaggerUI(d =>
            {
                d.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Only Development");
                d.RoutePrefix = string.Empty;
            });

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //     name: "Developer",
                //     pattern: "{controller=Developer}/{action=GetWihtId}/{id?}");

                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "{controller=User}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Developer}/{action=Index}/{id?}");
            });

            
        }
    }
}
