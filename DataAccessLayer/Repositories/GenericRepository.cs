using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        readonly ParamEmrimdeContext db = new ParamEmrimdeContext();

        public T Detay(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Ekle(T t)
        {
            db.Add(t);
            db.SaveChanges();
        }

        public void Sil(T t)
        {
            db.Remove(t);
            db.SaveChanges();
        }

        public void Guncelle(T t)
        {
            db.Update(t);
            db.SaveChanges();
        }

        public List<T> Liste()
        {
            return db.Set<T>().ToList();
        }
    }
}
