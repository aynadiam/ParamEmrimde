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
    public class KatManager : IKatService
    {
        readonly IKatDal _katDal;

        public KatManager(IKatDal katDal)
        {
            _katDal = katDal;
        }

        public List<Kat> TKatIncKalem()
        {
            return _katDal.KatIncKalem();
        }

        public Kat TDetay(int id)
        {
            return _katDal.Detay(id);
        }

        public void TEkle(Kat t)
        {
            _katDal.Ekle(t);
        }

        public void TGuncelle(Kat t)
        {
            _katDal.Guncelle(t);
        }

        public List<Kat> TListe()
        {
            return _katDal.Liste();
        }

        public void TSil(Kat t)
        {
            _katDal.Sil(t);
        }

        public List<Kat> TKatIncKalemFilter(int? kalem = null)
        {
            return _katDal.KatIncKalemFilter(kalem);
        }
    }
}
