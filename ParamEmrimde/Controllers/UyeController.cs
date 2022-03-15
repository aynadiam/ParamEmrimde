using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde.Controllers
{
    public class UyeController : Controller
    {
        readonly UyeManager uyeManager = new UyeManager(new EfUyeRepository());

        public IActionResult Index()
        {
            //Üye İdsini aldım
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            var deger = uyeManager.TDetay(uyeidsi);

            return View(deger);
        }

        [HttpPost]
        public IActionResult Index(Uye uye)
        {
            uyeManager.TGuncelle(uye);
            TempData["Tamam"] = "Güncellemeniz Başarılı Bir Şekilde Yapıldı.";
            return View();
        }

        public IActionResult Liste()
        {
            //Üye İdsini aldım
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            if (uyeidsi != 1)
            {
                return NotFound();
            }
            else
            {
                var deger = uyeManager.TListe();
                return View(deger);
            }
        }
    }
}
