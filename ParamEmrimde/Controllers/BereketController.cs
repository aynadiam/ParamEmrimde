using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde.Controllers
{
    public class BereketController : Controller
    {
        readonly KatManager katManager = new KatManager(new EfKatRepository());
        readonly KasaManager kasaManager = new KasaManager(new EfKasaRepository());
        public IActionResult Index()
        {
            //Üye İdsini aldım
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            //Kalem Toplamlarını Aldım
            ViewBag.Gelir = Convert.ToDouble(kasaManager.TKasaIncKatFilter().Where(x => x.Kat.KalemId == 1 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Gider = Convert.ToDouble(kasaManager.TKasaIncKatFilter().Where(x => x.Kat.KalemId == 2 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Tasarruf = Convert.ToDouble(kasaManager.TKasaIncKatFilter().Where(x => x.Kat.KalemId == 3 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Borc = Convert.ToDouble(kasaManager.TKasaIncKatFilter().Where(x => x.Kat.KalemId == 4 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Kalan = (Convert.ToDouble(ViewBag.Gelir) - (Convert.ToDouble(ViewBag.Gider) + Convert.ToDouble(ViewBag.Tasarruf)));

            var deger = kasaManager.TKasaIncKat();
            return View(deger);
        }
               
        public IActionResult PartialGelirEkleModal()
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);
            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 1 && x.UyeId == uyeidsi), "KatId", "KatAdi");
            return PartialView();
        }

        public IActionResult PartialGiderEkleModal()
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);
            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 2 && x.UyeId == uyeidsi), "KatId", "KatAdi");
            return PartialView();
        }

        public IActionResult PartialTasarrufEkleModal()
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);
            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 3 && x.UyeId == uyeidsi), "KatId", "KatAdi");
            return PartialView();
        }

        public IActionResult PartialBorcEkleModal()
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);
            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 4 && x.UyeId == uyeidsi), "KatId", "KatAdi");
            return PartialView();
        }

        [HttpPost]
        public IActionResult Ekle(Kasa kasa)
        {
            kasaManager.TEkle(kasa);
            return RedirectToAction("Index", "Bereket");
        }

        public IActionResult PartialGelirDuzenleModal(int id)
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);
            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 1 && x.UyeId == uyeidsi), "KatId", "KatAdi");

            var deger = kasaManager.TDetay(id);

            return PartialView(deger);
        }
    }
}
