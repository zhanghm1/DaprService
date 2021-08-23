using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using DaprTest.EFCore;
using Microsoft.EntityFrameworkCore;
using DaprTest.UI.Admin.Data;
using DaprTest.Domain.Entities.Admins;
using DaprTest.Application.AccountServices;
using DaprTest.Domain.Data;

namespace DaprTest.UI.Admin
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
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                // 填跨容器能访问的地址，不要localhost
                options.Authority = Configuration["IdentityServerUrl"];

                options.ClientId = ApplicationClientData.DefaultAdminMangeClientId;
                options.ClientSecret = "secret";
                options.ResponseType = "code";

                options.RequireHttpsMetadata = false;

                options.Scope.Add("orderapi");
                options.Scope.Add("productapi");
                options.Scope.Add("memberapi");

                options.SaveTokens = true;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            string connectionString = Configuration["ConnectionString"];
            Console.WriteLine(connectionString);
            services.AddDbContext<AdminDbContext>(options => {
                options.UseMySql(connectionString, ServerVersion.Parse("8.0"));
            });

            services.AddScoped<IAccountManage<AdminUser, AdminDbContext>, DefaultAccountManage<AdminUser, AdminDbContext>>();
            services.AddSingleton<IPasswordHandler, DefaultPasswordHandler>();
            services.AddScoped<AdminDbSeedData>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapDefaultControllerRoute()
                //   .RequireAuthorization();
            });
        }
    }
}
