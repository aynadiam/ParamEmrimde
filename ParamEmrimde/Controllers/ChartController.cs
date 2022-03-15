using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<KalemToplam> list = new List<KalemToplam>
            {
                new KalemToplam
                {
                    categoryName = "Teknoloji",
                    categoryCount = 10
                },
                new KalemToplam
                {
                    categoryName = "Yazılım",
                    categoryCount = 14
                },
                new KalemToplam
                {
                    categoryName = "Spor",
                    categoryCount = 5
                }
            };

            return Json(new { jsonlist = list });
        }
    }
}
