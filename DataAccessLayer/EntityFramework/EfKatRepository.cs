using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfKatRepository : GenericRepository<Kat>, IKatDal
    {
        public List<Kat> KatIncKalem()
        {
            using var c = new ParamEmrimdeContext();
            return c.Kats.Include(x => x.Kalem).ToList();
        }

        public List<Kat> KatIncKalemFilter(int? kalem = null)
        {
            using var c = new ParamEmrimdeContext();
            var sorgu = c.Kats.Include(x => x.Kalem).ToList();

            if (kalem != null)
            {
                sorgu = sorgu.Where(x => x.KalemId == kalem).ToList();
            }

            return sorgu.ToList();
        }
    }
}
