using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("Uyes", Schema = "pem")]
    public class Uye
    {
        [Key]
        public int UyeId { get; set; }

        public string UyeEposta { get; set; }

        public string UyeSifre { get; set; }

        public string UyeAdi { get; set; }

        public string UyeSoyadi { get; set; }

        public bool UyeOnay { get; set; }

        public bool UyeSil { get; set; }
        //
        //
        //Kategoride Listelenecek
        public virtual IList<Kat> Kats { get; set; }
    }
}
