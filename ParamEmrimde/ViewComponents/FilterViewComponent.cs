using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde.ViewComponents
{
    public class FilterViewComponent : ViewComponent
    {
        readonly KatManager katManager = new KatManager(new EfKatRepository());
        readonly KalemManager kalemManager = new KalemManager(new EfKalemRepository());
        public IViewComponentResult Invoke()
        {
            //Üye İdsini aldım
            int uyeidsi = Convert.ToInt32(User.Identity.Name);

            //Filtrelemede listeledim
            ViewData["KatKalem"] = new SelectList(kalemManager.TListe(), "KalemId", "KalemAdi", ViewData["kalem"]);

            ViewData["KategoriList"] = new SelectList((from s in katManager.TKatIncKalem().Where(x => x.UyeId == uyeidsi).Where(x=>x.KalemId == Convert.ToInt32(ViewBag.kalem)).OrderBy(x => x.KalemId).ThenBy(x => x.KatAdi)
                                                       select new
                                                       {
                                                           katId = s.KatId,
                                                           FullName = s.Kalem.KalemAdi + " - " + s.KatAdi
                                                       }),
                                                       "katId",
                                                       "FullName",
                                                       ViewData["kategori"]);
            return View();
        }
    }
}
