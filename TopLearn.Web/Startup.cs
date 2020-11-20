using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TopLearn.Core.messaging.Interfaces;
using TopLearn.Core.messaging.Services;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.Core.Repository.Interfaces.FilterAttributes;
using TopLearn.Core.Repository.Interfaces.Permission;
using TopLearn.Core.Repository.Interfaces.Role;
using TopLearn.Core.Repository.Interfaces.User;
using TopLearn.Core.Repository.Interfaces.Wallet;
using TopLearn.Core.Repository.Services;
using TopLearn.Core.Repository.Services.Course;
using TopLearn.Core.Repository.Services.FilterAttributes;
using TopLearn.Core.Repository.Services.Permission;
using TopLearn.Core.Services;
using TopLearn.DAL.Context;

namespace TopLearn.Web
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();


            #region  DataBase Context

            services.AddDbContext<TopLearnContext>(options =>
            {

                options.UseSqlServer(Configuration.GetConnectionString("Default_DB"));

            });

            #endregion

            #region IOC

            services.AddScoped<IMessaging, EmailService>();

            //services.AddScoped<IMessaging, SmsService>();


            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRoleUserService, RoleUserService>();

            services.AddScoped<IWalletService, WalletService>();

            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IPermissionService, PermissionService>();

            services.AddScoped<IRolePermissionService, RolePermissionService>();

            services.AddScoped<IFilterAttributeService, FilterAttributesService>();

            services.AddScoped<ICourseGroupService, CourseGroupService>();
            #endregion

            #region Authentication

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
            });

            #endregion

            services.AddRazorPages();


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



            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");



            });
        }
    }
}
