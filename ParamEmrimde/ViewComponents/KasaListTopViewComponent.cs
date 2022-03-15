using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde.ViewComponents
{
    public class KasaListTopViewComponent : ViewComponent
    {
        readonly KasaManager kasaManager = new KasaManager(new EfKasaRepository());

        public IViewComponentResult Invoke()
        {
            var deger = kasaManager.TKasaIncKat().OrderByDescending(x=>x.KasaTarih).Take(25);
            return View(deger);
        }
    }
}
