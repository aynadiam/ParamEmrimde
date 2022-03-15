using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde.ViewComponents
{
    public class KasaListViewComponent : ViewComponent
    {
        readonly KasaManager kasaManager = new KasaManager(new EfKasaRepository());

        public IViewComponentResult Invoke(DateTime? tarihKucuk = null, DateTime? tarihBuyuk = null, int? kategori = null, string aciklama = null, decimal? price = null, int? kalem = null)
        {
            var deger = kasaManager.TKasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem);
            return View(deger);
        }
    }
}
