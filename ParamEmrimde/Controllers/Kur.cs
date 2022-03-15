using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ParamEmrimde.Controllers
{
    public class Kur : Controller
    {
        public IActionResult Index()
        {
            XmlDocument xmlVerisi = new XmlDocument();
            xmlVerisi.Load("https://www.tcmb.gov.tr/kurlar/today.xml");

            decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
            decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
            decimal sterlin = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "GBP")).InnerText.Replace('.', ','));

            ViewData["dolar"] = dolar.ToString();
            ViewData["euro"] = euro.ToString();
            ViewData["sterlin"] = sterlin.ToString();

            return View();
        }
    }
}
