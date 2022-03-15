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
    public class AnasayfaController : Controller
    {
        readonly KatManager katManager = new KatManager(new EfKatRepository());
        readonly KasaManager kasaManager = new KasaManager(new EfKasaRepository());
        readonly KalemManager kalemManager = new KalemManager(new EfKalemRepository());

        public IActionResult Index(DateTime? tarihKucuk = null, DateTime? tarihBuyuk = null, int? kategori = null, string aciklama = null, decimal? price = null, int? kalem = null)
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            ViewData["aciklama"] = aciklama;
            ViewData["price"] = price;
            ViewData["kalem"] = kalem;
            ViewData["tarihKucuk"] = tarihKucuk;
            ViewData["tarihBuyuk"] = tarihBuyuk;
            ViewData["kategori"] = kategori;

            ViewBag.Gelir = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem).Where(x => x.Kat.KalemId == 1 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Gider = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem).Where(x => x.Kat.KalemId == 2 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Tasarruf = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem).Where(x => x.Kat.KalemId == 3 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Borc = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem).Where(x => x.Kat.KalemId == 4 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Kalan = (Convert.ToDouble(ViewBag.Gelir) - (Convert.ToDouble(ViewBag.Gider) + Convert.ToDouble(ViewBag.Tasarruf)));

            ViewData["KatKalem"] = new SelectList(kalemManager.TListe(), "KalemId", "KalemAdi", ViewData["kalem"]);
            ViewData["KategoriList"] = new SelectList(katManager.TListe().Where(x => x.UyeId == uyeidsi), "KatId", "KatAdi", ViewData["kategori"]);

            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 1 && x.UyeId == uyeidsi), "KatId", "KatAdi");
            ViewData["KatGider"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 2 && x.UyeId == uyeidsi), "KatId", "KatAdi");
            ViewData["KatTasarruf"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 3 && x.UyeId == uyeidsi), "KatId", "KatAdi");
            ViewData["KatBorc"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 4 && x.UyeId == uyeidsi), "KatId", "KatAdi");
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(DateTime kasaTarih, int katId, decimal kasaTutar, string kasaAciklama)
        {
            var kasa = new Kasa
            {
                KasaTarih = kasaTarih,
                KatId = katId,
                KasaTutar = kasaTutar,
                KasaAciklama = kasaAciklama
            };

            kasaManager.TEkle(kasa);
            return RedirectToAction("Index", "Anasayfa");
        }

        [HttpGet]
        public IActionResult Getir(int id)
        {
            var deger = kasaManager.TDetay(id);
            return new JsonResult(deger);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, DateTime kasaTarih, int katId, decimal kasaTutar, string kasaAciklama, bool kasaBorcOde, bool kasaKrediKarti)
        {
            var kasa = kasaManager.TDetay(id);
            kasa.KasaKrediKarti = kasaKrediKarti;
            kasa.KasaBorcOde = kasaBorcOde;
            kasa.KasaTarih = kasaTarih;
            kasa.KatId = katId;
            kasa.KasaTutar = kasaTutar;
            kasa.KasaAciklama = kasaAciklama;

            kasaManager.TGuncelle(kasa);
            return RedirectToAction("Index", "Anasayfa");
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var deger = kasaManager.TDetay(id);
            kasaManager.TSil(deger);
            return RedirectToAction("Index", "Anasayfa");
        }

        [HttpPost]
        public IActionResult EkleGelirKat(string katAdi)
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            var kat = new Kat
            {
                UyeId = uyeidsi,
                KalemId = 1,
                KatAdi = katAdi
            };

            katManager.TEkle(kat);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        [HttpPost]
        public IActionResult EkleGiderKat(string katAdi)
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            var kat = new Kat
            {
                UyeId = uyeidsi,
                KalemId = 2,
                KatAdi = katAdi
            };

            katManager.TEkle(kat);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        [HttpPost]
        public IActionResult EkleTasarrufKat(string katAdi)
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            var kat = new Kat
            {
                UyeId = uyeidsi,
                KalemId = 3,
                KatAdi = katAdi
            };

            katManager.TEkle(kat);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        [HttpPost]
        public IActionResult EkleBorcKat(string katAdi)
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            var kat = new Kat
            {
                UyeId = uyeidsi,
                KalemId = 4,
                KatAdi = katAdi
            };

            katManager.TEkle(kat);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        public IActionResult Edit(int id)
        {
            var deger = kasaManager.TDetay(id);
            return View(deger);
        }

        [HttpPost]
        public IActionResult Edit(Kasa kasa)
        {
            kasaManager.TGuncelle(kasa);
            return RedirectToAction("Index", "Anasayfa");
        }
    }
}
