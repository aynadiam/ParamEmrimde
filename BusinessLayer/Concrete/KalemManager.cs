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
    public class KalemManager : IKalemService
    {
        readonly IKalemDal _kalemDal;

        public KalemManager(IKalemDal kalemDal)
        {
            _kalemDal = kalemDal;
        }

        public Kalem TDetay(int id)
        {
            return _kalemDal.Detay(id);
        }

        public void TEkle(Kalem t)
        {
            _kalemDal.Ekle(t);
        }

        public void TGuncelle(Kalem t)
        {
            _kalemDal.Guncelle(t);
        }

        public List<Kalem> TListe()
        {
            return _kalemDal.Liste();
        }

        public void TSil(Kalem t)
        {
            _kalemDal.Sil(t);
        }
    }
}
