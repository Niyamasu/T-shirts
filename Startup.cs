using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Camisetas.DAL;

namespace Camisetas
{
    public class Startup
    {

        // Properties
        public IConfiguration Configuration {get;set;}

        // Ctor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        } // End of ctor

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AppDbContext>(options => {
                options.UseMySql(
                    Configuration["Data:ConnectionStrings:TShirtDatabase"]
                );
            });

            services.AddTransient<ITshirtRepository, EFTshirtRepository>();
            services.AddTransient<IColorRepository, EFColorRepository>();
            services.AddTransient<ISizeRepository, EFSizeRepository>();
            services.AddTransient<ITypeRepository, EFTypeRepository>();
            services.AddTransient<IClothingRepository,EFClothingRepository>();

        } // End of method ConfigureServices.

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddMvc();  
        } // End of method ConfigureServices.

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        
        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();

            app.UseMvc( routes =>
            {
                routes.MapRoute(
                    name: "clothingListPage",
                    template:"Admin/Clothing/{action=ClothingList}/Page{pageNumber}",
                    new {controller="AdminClothing"}
                );
                routes.MapRoute(
                    name: "clothingList",
                    template:"Admin/Clothing/{action=ClothingList}/{id?}",
                    new { controller="AdminClothing"}
                );
                routes.MapRoute(
                    name: "typeListPage",
                    template:"Admin/Types/{action=TypeList}/Page{pageNumber}",
                    new {controller="AdminType"}
                );
                routes.MapRoute(
                    name: "typeList",
                    template:"Admin/Types/{action=TypeList}/{id?}",
                    new { controller="AdminType"}
                );
                routes.MapRoute(
                    name: "sizeListPage",
                    template:"Admin/Sizes/{action=SizeList}/Page{pageNumber}",
                    new {controller="AdminSize"}
                );
                routes.MapRoute(
                    name: "sizeList",
                    template:"Admin/Sizes/{action=SizeList}/{id?}",
                    new { controller="AdminSize"}
                );
                routes.MapRoute(
                    name: "colorListPage",
                    template:"Admin/Colors/{action=ColorList}/Page{pageNumber}",
                    new {controller="AdminColor"}
                );
                routes.MapRoute(
                    name: "colorList",
                    template:"Admin/Colors/{action=ColorList}/{id?}",
                    new { controller="AdminColor"}
                );
                routes.MapRoute(
                    name: "tshirtPageNumber",
                    template: "Admin/Tshirt/TshirtList/Page{pageNumber}",
                    new {controller= "AdminTshirt", action= "Index"});
                routes.MapRoute(
                    name: "default",
                    template:"{controller=AdminTshirt}/{action=Index}/{id?}");
                
            });

            // SeedData.EnsurePopulated(app);
        } // End of method Configure.
        public void ConfigureProduction(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc( routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template:"{controller=Admin}/{action=Index}/{id?}");
            });

            app.UseExceptionHandler("/Error");
        } // End of method Configure.

    } // End of class Startup.

} // End of namespace Camisetas.
