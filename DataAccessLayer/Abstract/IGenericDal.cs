using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        T Detay(int id);
        void Ekle(T t);
        void Sil(T t);
        void Guncelle(T t);
        List<T> Liste();
    }
}
