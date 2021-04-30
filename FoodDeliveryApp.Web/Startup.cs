
using FoodDeliveryApp.DomainModel.Models;
using FoodDeliveryApp.Repository;
using FoodDeliveryApp.Repository.OrderRestaurant;
using FoodDeliveryApp.Repository.RestaurantRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Web
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
            services.AddControllersWithViews();
            //string temp = Configuration.GetConnectionString("User ID =postgres;Password=Qwerty@31;Server=localhost;Port=5432;Database=test1;Integrated Security=true;Pooling=true;");
            services.AddDbContext<DataContext>(opt=>opt.UseNpgsql("User ID =postgres;Password=Qwerty@31;Server=localhost;Port=5432;Database=test1;Integrated Security=true;Pooling=true;"));

            services.AddMvc();
           
            services.AddScoped< IShowOrder ,ShowOrder >();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
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

            app.UseDefaultFiles();
            app.UseStaticFiles();
                   }
    }
}
