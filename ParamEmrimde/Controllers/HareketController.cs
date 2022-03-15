using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParamEmrimde.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde.Controllers
{
    public class HareketController : Controller
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

            //Açılır Menüye kategorileri listeledim
            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 1 && x.UyeId == uyeidsi), "KatId", "KatAdi");
            ViewData["KatGider"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 2 && x.UyeId == uyeidsi), "KatId", "KatAdi");
            ViewData["KatTasarruf"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 3 && x.UyeId == uyeidsi), "KatId", "KatAdi");
            ViewData["KatBorc"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 4 && x.UyeId == uyeidsi), "KatId", "KatAdi");


            HareketViewModel hareketViewModel = new HareketViewModel();
            {
                hareketViewModel.KasaListeVm=kasaManager.TKasaIncKat().OrderByDescending(x => x.KasaTarih).Take(25);
            }

            return View(hareketViewModel);
        }

        [HttpPost]
        public IActionResult Ekle(HareketViewModel hareketViewModel)
        {
            kasaManager.TEkle(hareketViewModel.KasaEkleVm);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        [HttpPost]
        public IActionResult EkleKat(HareketViewModel hareketViewModel)
        {
            katManager.TEkle(hareketViewModel.KatEkleVm);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        public IActionResult Duzenle(int id)
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);
            var kalemIdAl = kasaManager.TKasaIncKat().Where(x => x.KasaId == id).Select(x => x.Kat.KalemId).FirstOrDefault();

            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == kalemIdAl && x.UyeId == uyeidsi), "KatId", "KatAdi");            

            var deger = kasaManager.TDetay(id);
            return PartialView("_DuzenleKasa", deger);
        }

        [HttpPost]
        public IActionResult Duzenle(Kasa kasa)
        {
            kasaManager.TGuncelle(kasa);
            return PartialView("_DuzenleKasa", kasa);
        }

        public IActionResult BorcOde(int id)
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 2 && x.UyeId == uyeidsi), "KatId", "KatAdi");

            var deger = kasaManager.TDetay(id);
            return PartialView("_BorcOdeKasa", deger);
        }

        [HttpPost]
        public IActionResult BorcOde(Kasa kasa)
        {
            kasaManager.TGuncelle(kasa);
            return PartialView("_BorcOdeKasa", kasa);
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var deger = kasaManager.TDetay(id);
            kasaManager.TSil(deger);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }
    }
}
