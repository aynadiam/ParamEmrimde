using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParamEmrimde.ViewModels
{
    public class HareketViewModel
    {
        public Kasa KasaEkleVm { get; set; }
        public Kat KatEkleVm { get; set; }
        public IEnumerable<Kasa> KasaListeVm { get; set; }
    }
}
