using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IKasaService : IGenericService<Kasa>
    {
        List<Kasa> TKasaIncKat();
        List<Kasa> TKasaIncKatFilter(DateTime? tarihKucuk = null, DateTime? tarihBuyuk = null, int? kategori = null, string aciklama = null, decimal? price = null, int? kalem = null, string krediKarti = null, string borcOde = null);
    }
}
