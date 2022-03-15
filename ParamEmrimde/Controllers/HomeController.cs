using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParamEmrimde.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ParamEmrimde.Controllers
{
    public class HomeController : Controller
    {
        readonly KatManager katManager = new KatManager(new EfKatRepository());
        readonly KasaManager kasaManager = new KasaManager(new EfKasaRepository());
        readonly KalemManager kalemManager = new KalemManager(new EfKalemRepository());

        public IActionResult Index(DateTime? tarihKucuk = null, DateTime? tarihBuyuk = null, int? kategori = null, string aciklama = null, decimal? price = null, int? kalem = null, string krediKarti=null, string borcOde = null)
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
            ViewBag.Gider = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde).Where(x => x.Kat.KalemId == 2 && x.Kat.UyeId == uyeidsi && x.KasaKrediKarti==false).Sum(x => x.KasaTutar).ToString());
            ViewBag.GiderKredi = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde).Where(x => x.Kat.KalemId == 2 && x.Kat.UyeId == uyeidsi && x.KasaKrediKarti == true).Sum(x => x.KasaTutar).ToString());
            ViewBag.GiderToplam = (Convert.ToDouble(ViewBag.Gider) + Convert.ToDouble(ViewBag.GiderKredi));
            ViewBag.Tasarruf = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde).Where(x => x.Kat.KalemId == 3 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Borc = Convert.ToDouble(kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde).Where(x => x.Kat.KalemId == 4 && x.Kat.UyeId == uyeidsi).Sum(x => x.KasaTutar).ToString());
            ViewBag.Kalan = (Convert.ToDouble(ViewBag.Gelir) - (Convert.ToDouble(ViewBag.Gider) + Convert.ToDouble(ViewBag.Tasarruf)));

            //Açılır Menüye kategorileri listeledim
            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 1 && x.UyeId == uyeidsi).OrderBy(x=>x.KatAdi), "KatId", "KatAdi");
            ViewData["KatGider"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 2 && x.UyeId == uyeidsi).OrderBy(x => x.KatAdi), "KatId", "KatAdi");
            ViewData["KatTasarruf"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 3 && x.UyeId == uyeidsi).OrderBy(x => x.KatAdi), "KatId", "KatAdi");
            ViewData["KatBorc"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 4 && x.UyeId == uyeidsi).OrderBy(x => x.KatAdi), "KatId", "KatAdi");

            DateTime gununtarihi = DateTime.Now.AddDays(5);

            HareketViewModel hareketViewModel = new HareketViewModel();
            {
                if(tarihKucuk != null || tarihBuyuk != null || kategori != null || aciklama != null || price != null || kalem != null || krediKarti!=null || borcOde != null)
                {
                    hareketViewModel.KasaListeVm = kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde).Where(x=>x.Kat.UyeId== uyeidsi).OrderByDescending(x => x.KasaTarih);
                }
                else
                {
                    hareketViewModel.KasaListeVm = kasaManager.TKasaIncKat().Where(x => x.Kat.UyeId == uyeidsi && x.KasaTarih<gununtarihi).OrderByDescending(x => x.KasaTarih).Take(50);
                }
            }

            return View(hareketViewModel);
        }

        [HttpPost]
        public IActionResult Ekle(HareketViewModel hareketViewModel)
        {
            //Anlık Döviz Kuru Alıyorum
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
            decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));

            hareketViewModel.KasaEkleVm.KasaTutarDolar = hareketViewModel.KasaEkleVm.KasaTutar / dolar;
            hareketViewModel.KasaEkleVm.KasaTutarEuro = hareketViewModel.KasaEkleVm.KasaTutar / euro;

            if (hareketViewModel.KasaEkleVm.KasaAciklama==null)
            {
                hareketViewModel.KasaEkleVm.KasaAciklama = "";
            }

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
            ViewData["kalemIdAl"] = kasaManager.TKasaIncKat().Where(x => x.KasaId == id).Select(x => x.Kat.KalemId).FirstOrDefault();
            ViewData["kalemAdiAl"] = kasaManager.TKasaIncKatFilter().Where(x => x.KasaId == id).Select(x => x.Kat.Kalem.KalemAdi).FirstOrDefault();

            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == Convert.ToInt32(ViewData["kalemIdAl"]) && x.UyeId == uyeidsi).OrderBy(x => x.KatAdi), "KatId", "KatAdi");

            var deger = kasaManager.TDetay(id);
            return PartialView("_DuzenleKasa", deger);
        }

        [HttpPost]
        public IActionResult Duzenle(Kasa kasa)
        {
            //Anlık Döviz Kuru Alıyorum
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
            decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));

            kasa.KasaTutarDolar = kasa.KasaTutar / dolar;
            kasa.KasaTutarEuro = kasa.KasaTutar / euro;

            if (kasa.KasaAciklama == null)
            {
                kasa.KasaAciklama = "";
            }

            kasaManager.TGuncelle(kasa);
            return PartialView("_DuzenleKasa", kasa);
        }

        public IActionResult BorcOde(int id)
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 2 && x.UyeId == uyeidsi).OrderBy(x => x.KatAdi), "KatId", "KatAdi");

            var deger = kasaManager.TDetay(id);
            return PartialView("_BorcOdeKasa", deger);
        }

        [HttpPost]
        public IActionResult BorcOde(Kasa kasa)
        {
            KasaValidator kasaValidator = new KasaValidator();
            ValidationResult result = kasaValidator.Validate(kasa);
            if (result.IsValid)
            {
                //Anlık Döviz Kuru Alıyorum
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
                decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));

                kasa.KasaTutarDolar = kasa.KasaTutar / dolar;
                kasa.KasaTutarEuro = kasa.KasaTutar / euro;

                if (kasa.KasaAciklama == null)
                {
                    kasa.KasaAciklama = "";
                }

                kasaManager.TGuncelle(kasa);
                return PartialView("_BorcOdeKasa", kasa);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

            
        }

        public IActionResult BorcTekrar(int id)
        {
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            ViewData["KatGelir"] = new SelectList(katManager.TListe().Where(x => x.KalemId == 4 && x.UyeId == uyeidsi).OrderBy(x => x.KatAdi), "KatId", "KatAdi");

            var deger = kasaManager.TDetay(id);
            deger.KasaBorcOde = false;
            kasaManager.TGuncelle(deger);

            return PartialView("_BorcTekrarKasa", deger);
        }

        [HttpPost]
        public IActionResult BorcTekrar(Kasa kasa)
        {
            KasaValidator kasaValidator = new KasaValidator();
            ValidationResult result = kasaValidator.Validate(kasa);
            if (result.IsValid)
            {
                //Anlık Döviz Kuru Alıyorum
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
                decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
                decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));

                kasa.KasaTutarDolar = kasa.KasaTutar / dolar;
                kasa.KasaTutarEuro = kasa.KasaTutar / euro;
                kasa.KasaBorcOde = false;
                if (kasa.KasaAciklama == null)
                {
                    kasa.KasaAciklama = "";
                }

                kasaManager.TEkle(kasa);
                return PartialView("_BorcTekrarKasa", kasa);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();            
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
