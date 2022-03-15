using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class KasaManager : IKasaService
    {
        readonly IKasaDal _kasaDal;

        public KasaManager(IKasaDal kasaDal)
        {
            _kasaDal = kasaDal;
        }

        public Kasa TDetay(int id)
        {
            return _kasaDal.Detay(id);
        }

        public void TEkle(Kasa t)
        {
            _kasaDal.Ekle(t);
        }

        public void TGuncelle(Kasa t)
        {
            _kasaDal.Guncelle(t);
        }

        public List<Kasa> TKasaIncKat()
        {
            return _kasaDal.KasaIncKat();
        }

        public List<Kasa> TKasaIncKatFilter(DateTime? tarihKucuk = null, DateTime? tarihBuyuk = null, int? kategori = null, string aciklama = null, decimal? price = null, int? kalem = null, string krediKarti = null, string borcOde = null)
        {
            return _kasaDal.KasaIncKatFilter(tarihKucuk, tarihBuyuk, kategori, aciklama, price, kalem, krediKarti, borcOde);
        }

        public List<Kasa> TListe()
        {
            return _kasaDal.Liste();
        }

        public void TSil(Kasa t)
        {
            _kasaDal.Sil(t);
        }
    }
}

