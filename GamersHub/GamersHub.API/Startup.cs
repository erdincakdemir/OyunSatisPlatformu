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
            //Dependency Injection ba��ml�l�k enjekte edici olarak tan�mlan�r ve ba��ml�l�klar� bu �ekilde ortadan kald�rabiliriz. 

            //Dependency Injection Methodlar�
            //(Ba��ml�l�k Enjekte Edici)

            //AddScoped    : Gelen her bir istek i�in instance olu�turur. E�er o scope un i�erisine daha �nceden girmi�se ozaman ayn� instance yani �rne�i kullan�r. E�er ilk defa girecekse ozamanda yeni bir �rnek olu�turur.

            //AddTransient : Her istekte yeni bir instance yani �rnek olu�turur.

            //AddSingleton : Uygulama aya�a kald�r�l�rken gelen ilk istekte hepsinden birer instance yani �rnek olu�turur.
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
