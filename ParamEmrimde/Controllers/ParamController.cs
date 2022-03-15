using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde.Controllers
{
    public class ParamController : Controller
    {
        readonly KasaManager kasaManager = new KasaManager(new EfKasaRepository());

        public IActionResult Index()
        {
            var deger = kasaManager.TKasaIncKat();
            return View(deger);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Kasa kasa = new Kasa();
            return PartialView("_EmployeeModelPartial", kasa);
        }

        [HttpPost]
        public IActionResult Create(Kasa kasa)
        {
            kasaManager.TEkle(kasa);
            return PartialView("_EmployeeModelPartial", kasa);
        }

        public IActionResult Edit(int id)
        {
            var deger = kasaManager.TDetay(id);
            return PartialView("_EditEmployeeModelPartial", deger);
        }

        [HttpPost]
        public IActionResult Edit(Kasa kasa)
        {
            kasaManager.TGuncelle(kasa);
            return PartialView("_EditEmployeeModelPartial", kasa);
        }

        public IActionResult Details(int id)
        {
            var deger = kasaManager.TDetay(id);
            return PartialView("_DetailEmployeeModelPartial", deger);
        }

        public IActionResult Delete(int id)
        {
            var deger = kasaManager.TDetay(id);
            return PartialView("_DeleteEmployeeModelPartial", deger);
        }

        [HttpPost]
        public IActionResult Delete(Kasa kasa)
        {
            var deger = kasaManager.TDetay(kasa.KasaId);
            kasaManager.TSil(deger);
            return PartialView("_DeleteEmployeeModelPartial", kasa);
        }
    }
}
