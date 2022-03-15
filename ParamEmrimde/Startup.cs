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
            //AddRazorRuntimeCompilation; Sayfa Yenilenince De�i�ikleri G�rmek i�in
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //T�m projeyi �ifreli hale getiriyor
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));

            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                //Authentication olamazsam gidece�im adres Return Url ayar�
                x.LoginPath = "/Login";
                //Yetkim d���ndaki sayfaya gitmek istersem gidece�im adres Return Url ayar�
                x.AccessDeniedPath = "/Hata";
            });
        }
                
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Hata sayfas�na y�nlendir
            app.UseStatusCodePagesWithReExecute("/Hata/Index", "?statusCode={0}");

            app.UseRouting();

            //wwwroot klas�r�ne izin vermek i�in
            app.UseStaticFiles();

            //Authentication (kimlik do�rulama) i�in kulland�m
            app.UseAuthentication();

            //Authorization (yetki) almak i�in kulland�m
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
