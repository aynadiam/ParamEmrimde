using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ParamEmrimde.ViewComponents
{
    public class UstMenuViewComponent : ViewComponent
    {
        readonly KasaManager kasaManager = new KasaManager(new EfKasaRepository());
        readonly UyeManager uyeManager = new UyeManager(new EfUyeRepository());
        public IViewComponentResult Invoke()
        {
            //Anlık Döviz Kuru Alıyorum
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");
            decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
            decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
            ViewData["dolar"] = dolar.ToString();
            ViewData["euro"] = euro.ToString();

            //Üye İdsini aldım
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            ViewBag.KisiAdi = uyeManager.TDetay(uyeidsi).UyeAdi;
            ViewBag.KisiSoyad = uyeManager.TDetay(uyeidsi).UyeSoyadi;

            //Bildirimde Borçları Listeledim
            var deger = kasaManager.TKasaIncKatFilter().Where(x => x.Kat.KalemId == 4 && x.Kat.UyeId == uyeidsi).OrderBy(x => x.KasaTarih).Take(25);
            return View(deger);
        }
    }
}
