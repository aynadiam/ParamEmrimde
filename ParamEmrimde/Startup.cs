using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //AddControllersWithViews; genel ayar
            //AddRazorRuntimeCompilation; Sayfa Yenilenince Deðiþikleri Görmek için
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //Tüm projeyi þifreli hale getiriyor
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));

            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                //Authentication olamazsam gideceðim adres Return Url ayarý
                x.LoginPath = "/Login";
                //Yetkim dýþýndaki sayfaya gitmek istersem gideceðim adres Return Url ayarý
                x.AccessDeniedPath = "/Hata";
            });
        }
                
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Hata sayfasýna yönlendir
            app.UseStatusCodePagesWithReExecute("/Hata/Index", "?statusCode={0}");

            app.UseRouting();

            //wwwroot klasörüne izin vermek için
            app.UseStaticFiles();

            //Authentication (kimlik doðrulama) için kullandým
            app.UseAuthentication();

            //Authorization (yetki) almak için kullandým
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
