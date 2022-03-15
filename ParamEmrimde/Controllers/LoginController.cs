using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ParamEmrimde.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        readonly UyeManager uyeManager = new UyeManager(new EfUyeRepository());

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Uye uye, string returnUrl = "")
        {
            ParamEmrimdeContext db = new ParamEmrimdeContext();

            var deger = db.Uyes.FirstOrDefault(x => x.UyeEposta == uye.UyeEposta && x.UyeSifre == uye.UyeSifre);

            if (deger != null)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,deger.UyeId.ToString())
                };
                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                var props = new AuthenticationProperties
                {
                    IsPersistent = uye.UyeOnay
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal, props);

                if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı veya Şifre Yanlış";
                return View();
            }
        }

        public IActionResult SifremiUnuttum()
        {
            return View();
        }

        public IActionResult UyeOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UyeOl(Uye uye)
        {
            ParamEmrimdeContext db = new ParamEmrimdeContext();
            var kontrol = db.Uyes.FirstOrDefault(x => x.UyeEposta == uye.UyeEposta);

            if (ModelState.IsValid)
            {                
                if (kontrol == null)
                {
                    uye.UyeOnay = true;
                    uye.UyeSil = false;
                    uyeManager.TEkle(uye);
                    TempData["Success"] = "Kaydınız Başarılı Bir Şekilde Yapıldı.";
                    return View();
                }
                else
                {
                    ViewBag.Mesaj = "Bu E-Posta İle Daha Önceden Kayıt Yapılmış";
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
