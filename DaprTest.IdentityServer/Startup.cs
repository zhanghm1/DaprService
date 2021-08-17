using DaprTest.Application.MemberServices;
using DaprTest.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
            services.AddControllersWithViews();
            services.AddIdentityServer(option => {
                option.Authentication.CookieSameSiteMode = SameSiteMode.Lax;
                
            })
                .AddInMemoryClients(Config.Clients(Configuration))
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
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
            string connectionString = Configuration["ConnectionString"];
            Console.WriteLine(connectionString);
            services.AddDbContext<MemberDbContext>(options => {
                options.UseMySql(connectionString, ServerVersion.Parse("8.0"));
            });
            services.AddScoped<IMemberAccountManage, DefaultMemberAccountManage>();
            services.AddScoped<IPasswordHandler, DefaultPasswordHandler>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
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
            app.UseRouting();

            app.UseCookiePolicy();

            app.UseCors("any");

            //app.UseAuthorization();
            app.UseIdentityServer();//UseIdentityServer 包含UseAuthorization
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
