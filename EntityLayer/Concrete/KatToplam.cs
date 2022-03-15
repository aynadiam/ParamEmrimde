using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class KatToplam
    {
        public int KatId { get; set; }
        public string KatAdi { get; set; }
        public decimal Toplam { get; set; }
        public decimal ToplamDolar { get; set; }
        public decimal ToplamEuro { get; set; }
        public int KalemId { get; set; }
        public string KalemAdi { get; set; }
    }
}
