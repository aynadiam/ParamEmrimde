using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IKasaDal : IGenericDal<Kasa>
    {
        List<Kasa> KasaIncKat();

        List<Kasa> KasaIncKatFilter(DateTime? tarihKucuk = null, DateTime? tarihBuyuk = null, int? kategori = null, string aciklama = null, decimal? price = null, int? kalem = null, string krediKarti = null, string borcOde = null);
    }
}
