using BussinessLogicLayer.Abstract;
using BussinessLogicLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.AdoNet;
using DataAccessLayer.Concreate.Entityframework;
using DataAccessLayer.DBContext;
using DataAccessLayer.DummyData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersHub.API
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
            //Dependency Injection baðýmlýlýk enjekte edici olarak tanýmlanýr ve baðýmlýlýklarý bu þekilde ortadan kaldýrabiliriz. 

            //Dependency Injection Methodlarý
            //(Baðýmlýlýk Enjekte Edici)

            //AddScoped    : Gelen her bir istek için instance oluþturur. Eðer o scope un içerisine daha önceden girmiþse ozaman ayný instance yani örneði kullanýr. Eðer ilk defa girecekse ozamanda yeni bir örnek oluþturur.

            //AddTransient : Her istekte yeni bir instance yani örnek oluþturur.

            //AddSingleton : Uygulama ayaða kaldýrýlýrken gelen ilk istekte hepsinden birer instance yani örnek oluþturur.
            services.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("GamersHubApiDoc", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "GamersHubApiDoc", Version = "V1.0" });
            });

            services.AddScoped<IGameDAL,EfGame>();
            services.AddScoped<ICategoryDAL, EFCategory>();
            services.AddScoped<IGameCategoryDAL, EfGameCategory>();
            services.AddScoped<IimageDAL, EfImage>();
            services.AddScoped<ICartDAL, EfCart>();

            services.AddScoped<IGameService, GameManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IGameCategoryService, GameCategoryManager>();
            services.AddScoped<IimageService, ImageManager>();
            services.AddScoped<ICartService, CartManager>();

            services.AddDbContext<GamersHubContext>();
            //services.AddTransient<>();
            //services.AddSingleton<>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Seed.SeedData();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(x =>
            {
                x.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/GamersHubApiDoc/swagger.json", "GamersHubApiDoc");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
