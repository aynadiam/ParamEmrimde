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
    public class KatController : Controller
    {
        readonly KatManager katManager = new KatManager(new EfKatRepository());
        readonly KasaManager kasaManager = new KasaManager(new EfKasaRepository());
        public IActionResult Index(DateTime? tarihKucuk = null, DateTime? tarihBuyuk = null, int? kategori = null, string aciklama = null, decimal? price = null, int? kalem = null, string krediKarti = null, string borcOde = null)
        {
            //Üye İdsini aldım
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            //Filtrelemeleri hafızaya aldım
            ViewData["aciklama"] = aciklama;
            ViewData["price"] = price;
            ViewData["kalem"] = kalem;
            ViewData["tarihKucuk"] = tarihKucuk;
            ViewData["tarihBuyuk"] = tarihBuyuk;
            ViewData["kategori"] = kategori;
            ViewData["krediKarti"] = krediKarti == "on";
            ViewData["borcOde"] = borcOde == "on";

            //Kalem Toplamlarını Aldım
            ViewBag.Gelir = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde).Where(x => x.Kat.KalemId == 1 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Gider = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde).Where(x => x.Kat.KalemId == 2 && x.Kat.UyeId == uyeidsi && x.KasaKrediKarti == false).Sum(x => x.KasaTutar).ToString());
            ViewBag.GiderKredi = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde).Where(x => x.Kat.KalemId == 2 && x.Kat.UyeId == uyeidsi && x.KasaKrediKarti == true).Sum(x => x.KasaTutar).ToString());
            ViewBag.GiderToplam = (Convert.ToDouble(ViewBag.Gider) + Convert.ToDouble(ViewBag.GiderKredi));
            ViewBag.Tasarruf = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde).Where(x => x.Kat.KalemId == 3 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Borc = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde).Where(x => x.Kat.KalemId == 4 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Kalan = (Convert.ToDouble(ViewBag.Gelir) - (Convert.ToDouble(ViewBag.Gider) + Convert.ToDouble(ViewBag.Tasarruf)));

            var degerler = (from s in katManager.TKatIncKalemFilter(kalem).Where(x => x.UyeId == uyeidsi)
                            join o in kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde).Where(x => x.Kat.UyeId == uyeidsi) on s.KatId equals o.KatId into g
                          select new KatToplam
                          {
                              KatId=s.KatId,
                              KalemId=s.KalemId,
                              KatAdi = s.KatAdi,
                              KalemAdi=s.Kalem.KalemAdi,
                              Toplam = g.Sum(x => x.KasaTutar),
                              ToplamDolar = g.Sum(x => x.KasaTutarDolar),
                              ToplamEuro = g.Sum(x => x.KasaTutarEuro)
                          }).ToList();
                         

            return View(degerler);
        }

        [HttpGet]
        public IActionResult Getir(int id)
        {
            var deger = katManager.TDetay(id);
            return new JsonResult(deger);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, string katAdi, int uyeId, int kalemId)
        {
            var kat = katManager.TDetay(id);
            kat.KatAdi = katAdi;
            kat.UyeId = uyeId;
            kat.KalemId = kalemId;

            katManager.TGuncelle(kat);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        [HttpPost]
        public IActionResult EkleKat(string katAdi, int kalemId)
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            var kat = new Kat
            {
                UyeId = uyeidsi,
                KalemId = kalemId,
                KatAdi = katAdi
            };

            katManager.TEkle(kat);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var deger = katManager.TDetay(id);
            katManager.TSil(deger);
            return Redirect(HttpContext.Request.Headers["Referer"]);
        }
    }
}
