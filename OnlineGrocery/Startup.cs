using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineGrocery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace OnlineGrocery
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("GroceryDbConnection")));

            services.AddIdentity<UserModel, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();



            services.AddControllersWithViews();
            services.AddScoped<IProductRepository, SQLProductRepository>();
            services.AddScoped<ICMSIndexRepository, SQLCMSIndexRepository>();
            services.AddScoped<ISupplierRepository, SQLSuppliersRepository>();
            services.AddScoped<IOrderRepository, SQLOrderRepository>();
            services.AddScoped<IOrderItemRepository, SQLOrderItemRepository>();
            services.AddScoped<IUserOrderItemRepository, SQLUserOrderItemRepository>();
            services.AddScoped<IUserOrderRepository, SQLUserOrderRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCartModel.GetCart(sp));

            services.AddSession();
            services.AddMemoryCache();

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
