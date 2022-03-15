using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IKatService : IGenericService<Kat>
    {
        List<Kat> TKatIncKalem();
        List<Kat> TKatIncKalemFilter(int? kalem = null);
    }
}
