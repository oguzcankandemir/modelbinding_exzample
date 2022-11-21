using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//  ____     _  __                  _                   _       
// / __ \   | |/ /                 | |                 (_)      
//| |  | |  | ' /  __ _  _ __    __| |  ___  _ __ ___   _  _ __ 
//| |  | |  |  <  / _` || '_ \  / _` | / _ \| '_ ` _ \ | || '__|
//| |__| |_ | . \| (_| || | | || (_| ||  __/| | | | | || || |   
// \____/(_)|_|\_\\__,_||_| |_| \__,_| \___||_| |_| |_||_||_|   

namespace Model_Binding
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

            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddControllersWithViews();

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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Viewbag_ornek}/{id?}");

            });
        }
    }
}
