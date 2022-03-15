using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IKatDal : IGenericDal<Kat>
    {
        List<Kat> KatIncKalem();
        List<Kat> KatIncKalemFilter(int? kalem = null);
    }
}
