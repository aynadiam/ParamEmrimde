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
    public class UyeManager : IUyeService
    {
        readonly IUyeDal _uyeDal;

        public UyeManager(IUyeDal uyeDal)
        {
            _uyeDal = uyeDal;
        }

        public Uye TDetay(int id)
        {
            return _uyeDal.Detay(id);
        }

        public void TEkle(Uye t)
        {
            _uyeDal.Ekle(t);
        }

        public void TGuncelle(Uye t)
        {
            _uyeDal.Guncelle(t);
        }

        public List<Uye> TListe()
        {
            return _uyeDal.Liste();
        }

        public void TSil(Uye t)
        {
            _uyeDal.Sil(t);
        }
    }
}
