using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde.Controllers
{
    public class KalemController : Controller
    {
        readonly KalemManager km = new KalemManager (new EfKalemRepository());
        public IActionResult Index()
        {
            var deger = km.TListe();
            return View(deger);
        }
    }
}
