using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde.ViewComponents
{
    public class SolMenuViewComponent : ViewComponent
    {
        readonly KasaManager kasaManager = new KasaManager(new EfKasaRepository());

        public IViewComponentResult Invoke()
        {
            //Üye İdsini aldım
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            ViewBag.VeriSay = kasaManager.TKasaIncKat().Where(x => x.Kat.UyeId == uyeidsi).Count();

            if (ViewBag.VeriSay == 0)
            {
                ViewBag.IlkTarih = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                ViewBag.IlkTarih = kasaManager.TKasaIncKat().Where(x => x.Kat.UyeId == uyeidsi).Min(x => x.KasaTarih).ToString("yyyy-MM-dd");
            }

            if (ViewBag.VeriSay == 0)
            {
                ViewBag.SonTarih = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                ViewBag.SonTarih = Convert.ToDateTime(kasaManager.TKasaIncKat().Where(x => x.Kat.UyeId == uyeidsi).Max(x => x.KasaTarih)).AddDays(1).ToString("yyyy-MM-dd");
            }
            
            return View();
        }
    }
}
