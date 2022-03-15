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
    public class KasaController : Controller
    {
        readonly KatManager katManager = new KatManager(new EfKatRepository());
        readonly KasaManager kasaManager = new KasaManager(new EfKasaRepository());
        readonly KalemManager kalemManager = new KalemManager(new EfKalemRepository());

        public IActionResult Index(DateTime? tarihKucuk = null, DateTime? tarihBuyuk = null, int? kategori = null, string aciklama = null, decimal? price=null, int? kalem=null)
        {
            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 1), "KatId", "KatAdi");
            ViewData["KatGider"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 2), "KatId", "KatAdi");
            ViewData["KatTasarruf"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 3), "KatId", "KatAdi");
            ViewData["KatBorc"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 4), "KatId", "KatAdi");

            ViewData["aciklama"] = aciklama;
            ViewData["price"] = price;
            ViewData["kalem"] = kalem;
            ViewData["kategori"] = kategori;

            ViewData["KatKalem"] = new SelectList(kalemManager.TListe(), "KalemId", "KalemAdi", ViewData["kalem"]);

            ViewData["KategoriList"] = new SelectList(katManager.TListe(), "KatId", "KatAdi", ViewData["kategori"]);           

            var deger = kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price,kalem);
            return View(deger);
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
            return RedirectToAction("Index", "Kasa");
        }

        [HttpGet]
        public IActionResult Getir(int id)
        {
            var deger = kasaManager.TDetay(id);
            return new JsonResult(deger);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, DateTime kasaTarih, int katId, decimal kasaTutar, string kasaAciklama)
        {
            var kasa = kasaManager.TDetay(id);
            kasa.KasaTarih = kasaTarih;
            kasa.KatId = katId;
            kasa.KasaTutar = kasaTutar;
            kasa.KasaAciklama = kasaAciklama;

            kasaManager.TGuncelle(kasa);
            return RedirectToAction("Index", "Kasa");
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var deger = kasaManager.TDetay(id);
            kasaManager.TSil(deger);
            return RedirectToAction("Index", "Kasa");
        }
    }
}
