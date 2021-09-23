using DaprTest.Application.AccountServices;
using DaprTest.Domain.Entities.Admins;
using DaprTest.Domain.Entities.Members;
using DaprTest.Domain.Entities.Tenants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaprTest.IdentityServer
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
            services.AddControllersWithViews().AddDapr();
            services.AddIdentityServer(option => {
                option.Authentication.CookieSameSiteMode = SameSiteMode.Lax;
                
            })
                //.AddInMemoryClients(Config.Clients(Configuration))
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddClientStore<ClientStore>()
                .AddProfileService<ProfileService>()
                
                .AddDeveloperSigningCredential();

            //设置cookie 共享
            //services.AddDataProtection()
            //.PersistKeysToFileSystem("{PATH TO COMMON KEY RING FOLDER}")
            //.SetApplicationName("SharedCookieApp");

            services.AddAuthentication();

            // 添加跨域
            services.AddCors(options=> {
                options.AddPolicy("any", policy => {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                    
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
            }
            app.UseStaticFiles();
            app.UseCors("any");
            app.UseIdentityServer();//UseIdentityServer 包含UseAuthorization

            //eShopDapr的解决方案，cookie在Routing 之前
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
            app.UseRouting();
            
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
